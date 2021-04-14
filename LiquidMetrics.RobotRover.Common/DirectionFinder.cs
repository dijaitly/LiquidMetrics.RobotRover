using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidMetrics.RobotRover.Common
{
    internal class DirectionFinder
    {
        internal DirectionFinder(string orignalDirectionSymbol, string directionSymbol, string resultDirectionSymbol)
        {
            this.OrignalDirectionSymbol = orignalDirectionSymbol;
            this.DirectionSymbol = directionSymbol;
            this.ResultDirectionSymbol = resultDirectionSymbol;
        }
        public string OrignalDirectionSymbol { get; }

        public string DirectionSymbol { get;  }

        public string ResultDirectionSymbol { get; }

    }
}
