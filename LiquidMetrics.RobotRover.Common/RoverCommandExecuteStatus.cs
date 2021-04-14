using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidMetrics.RobotRover.Common
{
    public class RoverCommandExecuteStatus
    {
        public bool HasCommandExecutedSuccessfully { get; set; }
        public string Message { get; set; }
    }
}
