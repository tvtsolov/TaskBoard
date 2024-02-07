using System;
using TaskBoard.Models;
using TasksBoard.Models.Enums;

namespace TaskBoard.Tests.Models
{
    [TestClass]
    public class MemberTest
    {
        [TestMethod]
        public void Member_Constructor_Should_Initialize_Properties()
        {   
            //Arrange
            string testName = "AFineName";
            Member member = new Member(testName);
                
            //Assert
            Assert.IsNotNull(member);
            Assert.AreEqual(member.Name, testName);
            
        }
        [TestMethod]
        public void Member_ToString_Should_Return_The_Proper_Value()
        {
            //Arrange
            string testName = "AFineName";
            Member member = new Member(testName);

            //Assert
            Assert.IsNotNull(member);
            Assert.AreEqual(member.ToString(), testName);
        }
        [TestMethod]    
        public void Member_Should_Throw_Exception_When_Name_Is_TooShort()
        {
            //Arrange
            string testName = string.Empty;

            //Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(()=> new Member(testName));
        }

        [TestMethod]
        public void Member_Should_Throw_Exception_When_Name_Is_Too_Long()
        {
            //Arrange
            string testName = "A very very very very long name that no one would read";

            //Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Member(testName));
        }
    }
}
