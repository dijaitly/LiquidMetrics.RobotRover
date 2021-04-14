using System;
using System.Collections.Generic;
using System.Linq;

namespace LiquidMetrics.RobotRover.Common
{
    public abstract class Direction
    {
        private List<DirectionFinder> directionFinders;

        public Direction()
        {
            this.directionFinders = new List<DirectionFinder>();
            this.directionFinders.Add(new DirectionFinder("N","R","E"));
            this.directionFinders.Add(new DirectionFinder("N", "L", "W"));
            this.directionFinders.Add(new DirectionFinder("S", "R", "W"));
            this.directionFinders.Add(new DirectionFinder("S", "L", "E"));
            this.directionFinders.Add(new DirectionFinder("E", "L", "N"));
            this.directionFinders.Add(new DirectionFinder("E", "R", "S"));
            this.directionFinders.Add(new DirectionFinder("W", "L", "S"));
            this.directionFinders.Add(new DirectionFinder("W", "R", "N"));
        }

        public abstract string Symbol { get;  }

        public virtual RoverCommandExecuteStatus Rotate(CurrentPosition pos, string rotateDirection)
        {
            RoverCommandExecuteStatus rcES = new RoverCommandExecuteStatus();
            var directionFinder = this.directionFinders.SingleOrDefault(x => x.OrignalDirectionSymbol == this.Symbol && x.DirectionSymbol == rotateDirection);
            if (directionFinder != null)
            {
                return pos.SetPosition(pos.X, pos.Y, directionFinder.ResultDirectionSymbol);
            }
            else
            {
                rcES.HasCommandExecutedSuccessfully = false;
                rcES.Message = $"Could not rotate {rotateDirection} for the rover facing {pos.Direction.Symbol }";
                return rcES;
            }
        }


        public abstract RoverCommandExecuteStatus Move(CurrentPosition pos, long numberOfUnits);
        
    }
}
