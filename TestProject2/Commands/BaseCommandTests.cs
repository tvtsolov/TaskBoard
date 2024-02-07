
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using Newtonsoft.Json.Linq;
using System;
using TaskBoard.Models;
using TaskBoard.Tests.Helpers;
using TasksBoard.Commands;
using TasksBoard.Core.Contracts;
using TasksBoard.Models.Enums;
using TasksBoard.TaskBoard.Commands;
using TasksBoard.TaskBoard.Commands.BugCommands;
using TasksBoard.TaskBoard.Exceptions;

namespace TaskBoard.Tests.Commands
{
    [TestClass]
    public class BaseCommandTests
    {
        public IRepository repository;

        [TestInitialize]
        virtual public void Setup()
        {
            repository = TestHelpers.GetTestRepository();
        }


        [TestMethod]
        [DataRow("1")]
        [DataRow("100000")]
        public void ParseIntParameter_Should_ReturnIntWhenInputIsValid(string value)
        {
            //Arrange
            var sut = TestHelpers.GetTestCommand();
            //Act
            int resultInt = sut.ParseIntParameter(value, "Test parameter");
            //Assert
            Assert.AreEqual(int.Parse(value), resultInt);
        }

        [TestMethod]
        [DataRow("O")]
        [DataRow("@")]
        [DataRow(" ")]
        [DataRow("xv")]
        public void ParseIntParameter_Should_Throw_When_InputIsNotANumber (string value)
        {
            //Arrange
            List<string> commandParams =  new string[] { "advance", value }.ToList();
            var bug = repository.CreateBug(title: "Title_test",
                    description: "Description_test",
                    priority: Priority.Low,
                    severity: Severity.Minor);
            //Act & Assert
            var sut = new ChangePriorityOfBugCommand(commandParams, repository);
            Assert.ThrowsException<InvalidUserInputException>(() => sut.ExecuteCommand(), $"Invalid value for Bug ID. Should be an integer number.");
        }

        [TestMethod]
        [DataRow("Status")]
        [DataRow("Priorit")]
        public void ParsePriorityParameter_Should_Throw_When_InputIsNotValid(string value)
        {
            //Arrange
            var sut = TestHelpers.GetTestCommand();
            //Act & Assert
            Assert.ThrowsException< InvalidUserInputException>( () => 
                        sut.ParsePriorityParameter(value), ("Invalid value for Priority. Should be either High, Medium or Low."));
        }


        [TestMethod]
        [DataRow("Status")]
        [DataRow("WrongStatus")]
        public void ParseSeverityParameter_Should_Throw_When_InputIsNotValid(string value)
        {
            //Arrange
            var sut = TestHelpers.GetTestCommand();
            //Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() =>
                        sut.ParseSeverityParameter(value), ("Invalid value for Severity. Should be either Critical, Major or Minor."));
        }

        [TestMethod]
        [DataRow("Tiny")]
        [DataRow("Huge")]
        [DataRow("Big")]
        [DataRow("   ")]
        public void ParseSizeParameter_Should_Throw_When_InputIsNotValid(string value)
        {
            //Arrange
            var sut = TestHelpers.GetTestCommand();
            //Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() =>
                        sut.ParseSizeParameter(value, "test size"), ($"Invalid value for test size. Should be either Large, Medium or Small."));
        }





        [TestMethod]
        [DataRow("Small", Size.Small)]
        [DataRow("Medium", Size.Medium)]
        [DataRow("Large", Size.Large)]
        public void ParseSizeParameter_Should_Parse_When_InputIsValid(string value, Size expected)
        {
            //Arrange
            var sut = TestHelpers.GetTestCommand();
            //Act
            var result = sut.ParseSizeParameter(value, "test parameter");
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        [DataRow("Major", Severity.Major)]
        [DataRow("Minor", Severity.Minor)]
        [DataRow("Critical", Severity.Critical)]
        public void ParseSeverityParameter_Should_Parse_When_InputIsValid(string value, Severity expected)
        {
            //Arrange
            var sut = TestHelpers.GetTestCommand();
            //Act
            var result = sut.ParseSeverityParameter(value);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("Low", Priority.Low)]
        [DataRow("Medium", Priority.Medium)]
        [DataRow("High", Priority.High)]
        public void ParsePriorityParameter_Should_Parse_When_InputIsValid(string value, Priority expected)
        {
            //Arrange
            var sut = TestHelpers.GetTestCommand();
            //Act
            var result = sut.ParsePriorityParameter(value);
            Assert.AreEqual(expected, result);
        }

        //[TestMethod]
        //public void Constructor_Should_CreateNewInstance(string value, Priority expected)
        //{
        //    //Arrange
        //    //Act
        //    //Assert
        //}

    }
}
