using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidMetrics.RobotRover.Common
{
    public  class WestDirection:Direction
    {
        public override string Symbol { get { return "W"; } }

        public override RoverCommandExecuteStatus Move(CurrentPosition pos, long numberOfUnits)
        {
            RoverCommandExecuteStatus rcES = new RoverCommandExecuteStatus();
            if (pos.X - numberOfUnits >= 0 && pos.Direction != null)
            {
                return pos.SetPosition(pos.X - numberOfUnits, pos.Y, pos.Direction.Symbol);
            }
            else
            {
                rcES.HasCommandExecutedSuccessfully = false;
                rcES.Message = " Rover will fall off plateau";
                return rcES;
            }
        }
    }
}
