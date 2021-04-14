using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidMetrics.RobotRover.Rover
{
    internal class Command
    {
        internal string RotateDirection { get; set; }

        internal long NumberOfUnitstoMove { get; set; }
    }
}
