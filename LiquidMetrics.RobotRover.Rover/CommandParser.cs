using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LiquidMetrics.RobotRover.Rover
{
    internal class CommandParser
    {
        internal static CommandParserStatus ParseCommand(string command )
        {
            string trimmedCommand = command.Trim();
            int currentPosition = 0;
            List<Command> commands = new List<Command>();
            CommandParserStatus commandParserStatus = new CommandParserStatus();
            commandParserStatus.IsCommandSuccesfullyParsed = false;

            while (currentPosition < trimmedCommand.Length)
            {
                Command cmd = new Command();
                cmd.RotateDirection = trimmedCommand.Substring(currentPosition, 1).ToUpper();
                currentPosition = currentPosition + 1;
                if (currentPosition >= trimmedCommand.Length) { commandParserStatus.IsCommandSuccesfullyParsed = false; commandParserStatus.Message = "Command Not succesfully parsed "; return commandParserStatus; };
                StringBuilder sb = new StringBuilder();
                while(true)
                {
                    string s1 = trimmedCommand.Substring(currentPosition, 1);
                    sb.Append(s1);
                    currentPosition = currentPosition + 1;
                    if(currentPosition == trimmedCommand.Length ||(Regex.Matches(trimmedCommand.Substring(currentPosition,1), @"[a-zA-Z]").Count() ==1) )
                    {
                        break;
                    }
                }
                string move = sb.ToString();
                if(string.IsNullOrWhiteSpace(move))
                {
                     commandParserStatus.IsCommandSuccesfullyParsed = false;
                     commandParserStatus.Message = "Command Not succesfully parsed "; 
                     return commandParserStatus; 
                }
                int numberOfUnits;
                if (!int.TryParse(move, out numberOfUnits)) { commandParserStatus.IsCommandSuccesfullyParsed = false; commandParserStatus.Message = "Command Not succesfully parsed "; return commandParserStatus; }; 
                cmd.NumberOfUnitstoMove = numberOfUnits;
                commands.Add(cmd);
            }
            commandParserStatus.IsCommandSuccesfullyParsed = true;
            commandParserStatus.Commands = commands;
            return commandParserStatus;
        }
    }
}
