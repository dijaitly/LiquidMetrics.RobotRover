using System;
using LiquidMetrics.RobotRover.Common;
using LiquidMetrics.RobotRover.Rover;

namespace LiquidMetrics.RobotRover
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to Land Rover");
                var robotRover = new Rover.RobotRover();
                RoverCommandExecuteStatus rcES = robotRover.SetPosition(10, 10, "N");
                if(rcES !=null && rcES.HasCommandExecutedSuccessfully  )
                {
                    
                    Console.WriteLine($"My Current Postion is  [{robotRover.CurrentPosition.X},{robotRover.CurrentPosition.Y},{robotRover.CurrentPosition.Direction.Symbol}]");
                    while (true)
                    {

                        Console.WriteLine("Please Enter your command");
                        string command = Console.ReadLine();

                        RoverCommandExecuteStatus executeCommandStatus = robotRover.ExecuteCommand(command);
                        if (executeCommandStatus == null) Console.WriteLine("Rover didn't return the status of the command");
                        if (! executeCommandStatus.HasCommandExecutedSuccessfully)
                        {
                            Console.WriteLine($"{executeCommandStatus.Message}");
                        }
                       
                        string directionSymbol = robotRover.CurrentPosition.Direction != null ? robotRover.CurrentPosition.Direction.Symbol : "Not Set";
                        Console.WriteLine($"My Current Postion is  [{robotRover.CurrentPosition.X},{robotRover.CurrentPosition.Y},{directionSymbol}]");
                        Console.WriteLine(" Do you want to Continue Y for Yes and N for No");
                        string answer = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(answer) && answer.ToUpper() == "N")
                        {
                            Console.WriteLine("Good bye from LandRover ");
                            break;
                        }

                    }
                }
                else
                {
                    Console.WriteLine($"{rcES.Message}");
                    Console.WriteLine("Good bye from LandRover ");
                }

               
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
