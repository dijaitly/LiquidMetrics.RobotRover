using NUnit.Framework;
using LiquidMetrics.RobotRover.Common;


namespace LiquidMetrics.RobotRover.UnitTest
{
    public class RobotRover_Moving_Test
    {        

        [Test]
        public void Setting_Invalid_X_Position()
        {
            LiquidMetrics.RobotRover.Rover.RobotRover rr = new LiquidMetrics.RobotRover.Rover.RobotRover();
            LiquidMetrics.RobotRover.Common.RoverCommandExecuteStatus rrs =  rr.SetPosition(-1, 1, "N");
            Assert.IsFalse(rrs.HasCommandExecutedSuccessfully);
        }

        [Test]
        public void Setting_InvalidY_Position()
        {
            LiquidMetrics.RobotRover.Rover.RobotRover rr = new LiquidMetrics.RobotRover.Rover.RobotRover();
            LiquidMetrics.RobotRover.Common.RoverCommandExecuteStatus rrs = rr.SetPosition(0, -1, "N");
            Assert.IsFalse(rrs.HasCommandExecutedSuccessfully);
        }

        [Test]
        public void Setting_Invalid_Direction()
        {
            LiquidMetrics.RobotRover.Rover.RobotRover rr = new LiquidMetrics.RobotRover.Rover.RobotRover();
            LiquidMetrics.RobotRover.Common.RoverCommandExecuteStatus rrs = rr.SetPosition(0, -1, "NW");
            Assert.IsFalse(rrs.HasCommandExecutedSuccessfully);
        }

        [Test]
        public void Setting_Valid_Position()
        {
            LiquidMetrics.RobotRover.Rover.RobotRover rr = new LiquidMetrics.RobotRover.Rover.RobotRover();
            LiquidMetrics.RobotRover.Common.RoverCommandExecuteStatus rrs = rr.SetPosition(10, 20, "N");
            Assert.True(rrs.HasCommandExecutedSuccessfully);
            Assert.AreEqual(10, rr.CurrentPosition.X);
            Assert.AreEqual(20, rr.CurrentPosition.Y);
            Assert.AreEqual("N", rr.CurrentPosition.Direction.Symbol);
        }

        [Test]
        public void Setting_Valid_Position_North_And_Rotating_Right_Two_Units()
        {
            LiquidMetrics.RobotRover.Rover.RobotRover rr = new LiquidMetrics.RobotRover.Rover.RobotRover();
            LiquidMetrics.RobotRover.Common.RoverCommandExecuteStatus rrs = rr.SetPosition(10, 20, "N");
            rr.ExecuteCommand("R2");
            Assert.True(rrs.HasCommandExecutedSuccessfully);
            Assert.AreEqual(12, rr.CurrentPosition.X);
            Assert.AreEqual(20, rr.CurrentPosition.Y);
            Assert.AreEqual("E", rr.CurrentPosition.Direction.Symbol);
        }

        [Test]
        public void Setting_Valid_Position_North_And_Rotating_Left_Two_Units()
        {
            LiquidMetrics.RobotRover.Rover.RobotRover rr = new LiquidMetrics.RobotRover.Rover.RobotRover();
            LiquidMetrics.RobotRover.Common.RoverCommandExecuteStatus rrs = rr.SetPosition(10, 20, "N");
            rr.ExecuteCommand("L2");
            Assert.True(rrs.HasCommandExecutedSuccessfully);
            Assert.AreEqual(8, rr.CurrentPosition.X);
            Assert.AreEqual(20, rr.CurrentPosition.Y);
            Assert.AreEqual("W", rr.CurrentPosition.Direction.Symbol);
        }


        [Test]
        public void Setting_Valid_Position_South_And_Rotating_Right_Two_Units()
        {
            LiquidMetrics.RobotRover.Rover.RobotRover rr = new LiquidMetrics.RobotRover.Rover.RobotRover();
            LiquidMetrics.RobotRover.Common.RoverCommandExecuteStatus rrs = rr.SetPosition(10, 20, "S");
            rr.ExecuteCommand("R2");
            Assert.True(rrs.HasCommandExecutedSuccessfully);
            Assert.AreEqual(8, rr.CurrentPosition.X);
            Assert.AreEqual(20, rr.CurrentPosition.Y);
            Assert.AreEqual("W", rr.CurrentPosition.Direction.Symbol);
        }

        [Test]
        public void Setting_Valid_Position_South_And_Rotating_Left_Two_Units()
        {
            LiquidMetrics.RobotRover.Rover.RobotRover rr = new LiquidMetrics.RobotRover.Rover.RobotRover();
            LiquidMetrics.RobotRover.Common.RoverCommandExecuteStatus rrs = rr.SetPosition(10, 20, "S");
            rr.ExecuteCommand("L2");
            Assert.True(rrs.HasCommandExecutedSuccessfully);
            Assert.AreEqual(12, rr.CurrentPosition.X);
            Assert.AreEqual(20, rr.CurrentPosition.Y);
            Assert.AreEqual("E", rr.CurrentPosition.Direction.Symbol);
        }


        [Test]
        public void Setting_Valid_Position_East_And_Rotating_Left_Two_Units()
        {
            LiquidMetrics.RobotRover.Rover.RobotRover rr = new LiquidMetrics.RobotRover.Rover.RobotRover();
            LiquidMetrics.RobotRover.Common.RoverCommandExecuteStatus rrs = rr.SetPosition(10, 20, "E");
            rr.ExecuteCommand("L2");
            Assert.True(rrs.HasCommandExecutedSuccessfully);
            Assert.AreEqual(10, rr.CurrentPosition.X);
            Assert.AreEqual(22, rr.CurrentPosition.Y);
            Assert.AreEqual("N", rr.CurrentPosition.Direction.Symbol);
        }

        [Test]
        public void Setting_Valid_Position_East_And_Rotating_Right_Two_Units()
        {
            LiquidMetrics.RobotRover.Rover.RobotRover rr = new LiquidMetrics.RobotRover.Rover.RobotRover();
            LiquidMetrics.RobotRover.Common.RoverCommandExecuteStatus rrs = rr.SetPosition(10, 20, "E");
            rr.ExecuteCommand("R2");
            Assert.True(rrs.HasCommandExecutedSuccessfully);
            Assert.AreEqual(10, rr.CurrentPosition.X);
            Assert.AreEqual(18, rr.CurrentPosition.Y);
            Assert.AreEqual("S", rr.CurrentPosition.Direction.Symbol);
        }

        [Test]
        public void Setting_Valid_Position_West_And_Rotating_Left_Two_Units()
        {
            LiquidMetrics.RobotRover.Rover.RobotRover rr = new LiquidMetrics.RobotRover.Rover.RobotRover();
            LiquidMetrics.RobotRover.Common.RoverCommandExecuteStatus rrs = rr.SetPosition(10, 20, "W");
            rr.ExecuteCommand("L2");
            Assert.True(rrs.HasCommandExecutedSuccessfully);
            Assert.AreEqual(10, rr.CurrentPosition.X);
            Assert.AreEqual(18, rr.CurrentPosition.Y);
            Assert.AreEqual("S", rr.CurrentPosition.Direction.Symbol);
        }

        [Test]
        public void Setting_Valid_Position_West_And_Rotating_Right_Two_Units()
        {
            LiquidMetrics.RobotRover.Rover.RobotRover rr = new LiquidMetrics.RobotRover.Rover.RobotRover();
            LiquidMetrics.RobotRover.Common.RoverCommandExecuteStatus rrs = rr.SetPosition(10, 20, "W");
            rr.ExecuteCommand("R2");
            Assert.True(rrs.HasCommandExecutedSuccessfully);
            Assert.AreEqual(10, rr.CurrentPosition.X);
            Assert.AreEqual(22, rr.CurrentPosition.Y);
            Assert.AreEqual("N", rr.CurrentPosition.Direction.Symbol);
        }

        [Test]
        public void Setting_Valid_Position_Executing_Complex_Command()
        {
            LiquidMetrics.RobotRover.Rover.RobotRover rr = new LiquidMetrics.RobotRover.Rover.RobotRover();
            LiquidMetrics.RobotRover.Common.RoverCommandExecuteStatus rrs = rr.SetPosition(10, 10, "N");
            rr.ExecuteCommand("R1R3L2L1");
            Assert.True(rrs.HasCommandExecutedSuccessfully);
            Assert.AreEqual(13, rr.CurrentPosition.X);
            Assert.AreEqual(8, rr.CurrentPosition.Y);
            Assert.AreEqual("N", rr.CurrentPosition.Direction.Symbol);
        }

        [Test]
        public void Setting_Valid_Position_Execution_Wrong_Complex_Command()
        {
            LiquidMetrics.RobotRover.Rover.RobotRover rr = new LiquidMetrics.RobotRover.Rover.RobotRover();
            LiquidMetrics.RobotRover.Common.RoverCommandExecuteStatus rrs = rr.SetPosition(10, 10, "N");
            RoverCommandExecuteStatus executeCommandStatus =  rr.ExecuteCommand("RR");
            Assert.False(executeCommandStatus.HasCommandExecutedSuccessfully);          
        }

        [Test]
        public void Setting_Valid_Position_Execution_Second_Wrong_Complex_Command()
        {
            LiquidMetrics.RobotRover.Rover.RobotRover rr = new LiquidMetrics.RobotRover.Rover.RobotRover();
            LiquidMetrics.RobotRover.Common.RoverCommandExecuteStatus rrs = rr.SetPosition(10, 10, "N");
            RoverCommandExecuteStatus executeCommandStatus = rr.ExecuteCommand("R@R");
            Assert.False(executeCommandStatus.HasCommandExecutedSuccessfully);
        }

        [Test]
        public void Setting_Valid_Position_Execution_Rotating_Two_Rights()
        {
            LiquidMetrics.RobotRover.Rover.RobotRover rr = new LiquidMetrics.RobotRover.Rover.RobotRover();
            LiquidMetrics.RobotRover.Common.RoverCommandExecuteStatus rrs = rr.SetPosition(10, 10, "N");
            RoverCommandExecuteStatus executeCommandStatus = rr.ExecuteCommand("R0R0");
            Assert.True(executeCommandStatus.HasCommandExecutedSuccessfully);
            Assert.AreEqual(10, rr.CurrentPosition.X);
            Assert.AreEqual(10, rr.CurrentPosition.Y);
            Assert.AreEqual("S", rr.CurrentPosition.Direction.Symbol);
        }
    }
}