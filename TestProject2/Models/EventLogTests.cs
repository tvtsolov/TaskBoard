using System.Text;
using TaskBoard.Models;
using TasksBoard.Models.Enums;

namespace TaskBoard.Tests.Models
{
    [TestClass]
    public class EventLogTest
    {
        [TestMethod]
        public void EventLog_Constructor_Should_Initialize_Properties()
        {   
            //Arrange
            string testDescription = "Describing the EventLog";
            EventLog eventLog = new EventLog(testDescription);
                
            //Assert
            Assert.IsNotNull(eventLog);
            Assert.AreEqual(eventLog.Description, testDescription);
            Assert.IsNotNull(eventLog.DateTime);
        }
        [TestMethod]
        public void EventLog_ToString_Should_Return_The_Proper_Value()
        {
            string testDescription = "Describing the EventLog";
            EventLog eventLog = new EventLog(testDescription);

            DateTime dateTime = eventLog.DateTime;
            var sb = new StringBuilder();
            string expectedReturn = $"{dateTime}: {testDescription}";
            sb.AppendLine(expectedReturn);
            Assert.AreEqual(eventLog.ToString(), sb.ToString());
        }
    }
}
