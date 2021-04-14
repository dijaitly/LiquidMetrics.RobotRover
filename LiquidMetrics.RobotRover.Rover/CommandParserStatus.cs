using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiquidMetrics.RobotRover.Rover;

namespace LiquidMetrics.RobotRover.Rover
{
    internal class CommandParserStatus
    {
        internal bool IsCommandSuccesfullyParsed { get; set; }

        internal List<Command> Commands { get; set; }

        internal string Message { get; set; }
    }
}
