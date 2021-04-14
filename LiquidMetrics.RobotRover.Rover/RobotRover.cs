using LiquidMetrics.RobotRover.Common;
using System;
using System.Collections.Generic;

namespace LiquidMetrics.RobotRover.Rover
{
    public class RobotRover
    {
        private CurrentPosition currentPosition;
        public RobotRover()
        {
            currentPosition = new CurrentPosition();
            currentPosition.SetPosition(0, 0, "N");
        }

       public CurrentPosition CurrentPosition
        {
            get
            {
                return currentPosition;
            }
        }

        public RoverCommandExecuteStatus SetPosition(long x, long y,string directionSymbol)
        {
            return currentPosition.SetPosition(x, y, directionSymbol);
        }

        public RoverCommandExecuteStatus ExecuteCommand (string command )
        {
            RoverCommandExecuteStatus roverCommandExecuteStatus = new RoverCommandExecuteStatus();
            roverCommandExecuteStatus.HasCommandExecutedSuccessfully = false;
           if (string.IsNullOrWhiteSpace(command)) { roverCommandExecuteStatus.HasCommandExecutedSuccessfully = false; roverCommandExecuteStatus.Message = "Command is null or Empty"; return roverCommandExecuteStatus; }
           CommandParserStatus  commandParserStatus= CommandParser.ParseCommand(command);
            if(commandParserStatus ==null) { roverCommandExecuteStatus.HasCommandExecutedSuccessfully = false; roverCommandExecuteStatus.Message = "Command not parsed "; return roverCommandExecuteStatus; }
            if (!commandParserStatus.IsCommandSuccesfullyParsed) { roverCommandExecuteStatus.HasCommandExecutedSuccessfully = false; roverCommandExecuteStatus.Message = commandParserStatus.Message; return roverCommandExecuteStatus; } 
            if(commandParserStatus.Commands ==null ) { roverCommandExecuteStatus.HasCommandExecutedSuccessfully = false; roverCommandExecuteStatus.Message = "No command found in the string "; return roverCommandExecuteStatus; }
            foreach (Command cmd in commandParserStatus.Commands)
           {
                if (cmd == null && string.IsNullOrWhiteSpace(cmd.RotateDirection)) { roverCommandExecuteStatus.HasCommandExecutedSuccessfully = false; roverCommandExecuteStatus.Message = "Command not correctly formed "; return roverCommandExecuteStatus; }
                RoverCommandExecuteStatus rCESRotate = currentPosition.Rotate(cmd.RotateDirection);
                if (rCESRotate == null || !rCESRotate.HasCommandExecutedSuccessfully) return rCESRotate;
                RoverCommandExecuteStatus rCESMove = currentPosition.Move(cmd.NumberOfUnitstoMove);
                if (rCESMove == null || !rCESMove.HasCommandExecutedSuccessfully) return rCESMove;
            }


            roverCommandExecuteStatus.HasCommandExecutedSuccessfully = true;
            roverCommandExecuteStatus.Message = "SUCCESS";
            return roverCommandExecuteStatus;
        }

    }
}
