using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidMetrics.RobotRover.Common
{
    public class CurrentPosition
    {

        public CurrentPosition()
        {
            AvailableDirections = new List<Direction>();
            AvailableDirections.Add(new NorthDirection());
            AvailableDirections.Add(new EastDirection());
            AvailableDirections.Add(new WestDirection());
            AvailableDirections.Add(new SouthDirection()); 
        }

        private List<Direction> AvailableDirections { get;  }

        private long xpos;
        private long ypos;
        public long X { get { return xpos; } }

        public long Y { get { return ypos; } }

        public Direction Direction { get; set; }

        public RoverCommandExecuteStatus SetPosition(long x, long y, string directionSymbol)
        {
            RoverCommandExecuteStatus rcES = new RoverCommandExecuteStatus();
            if (x < 0) { rcES.HasCommandExecutedSuccessfully = false; rcES.Message = "X is less than 0 in Set Position "; return rcES; }
            if (y < 0) { rcES.HasCommandExecutedSuccessfully = false; rcES.Message = "Y is less than 0 in Set Position "; return rcES; }
            if (string.IsNullOrWhiteSpace(directionSymbol)) { rcES.HasCommandExecutedSuccessfully = false; rcES.Message = "Direction is null or Empty in Set Position "; return rcES; }
            Direction dir = AvailableDirections.SingleOrDefault(x => x.Symbol == directionSymbol);
            if(dir ==null)
            {
                rcES.HasCommandExecutedSuccessfully = false; rcES.Message = "Direction not available in Set Position "; return rcES;
            }
            xpos = x;
            ypos = y;
            this.Direction = dir;
            rcES.HasCommandExecutedSuccessfully = true;
            rcES.Message = "SUCCESS";
            return rcES;;
        }

        public RoverCommandExecuteStatus Rotate(string rotateDirection)
        {
            return this.Direction.Rotate(this, rotateDirection);
        }


        public RoverCommandExecuteStatus Move(long numberOfUnits)
        {
            return this .Direction.Move(this, numberOfUnits);
        }
    }
}
