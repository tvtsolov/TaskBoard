

using TaskBoard.Models;
using TaskBoard.Tests.Helpers;
using TasksBoard.Core.Contracts;
using TasksBoard.TaskBoard.Commands;
using TasksBoard.TaskBoard.Exceptions;

namespace TaskBoard.Tests.Commands
{
    [TestClass]
    public class CreateNewPersonTests 
    {
        private IRepository repository;

        [TestInitialize]
        public void Setup()
        {
            repository = TestHelpers.GetTestRepository();
        }

        [TestMethod]
        [DataRow(CreateNewPersonCommand.ExpectedNumberOfArguments - 1)]
        [DataRow(CreateNewPersonCommand.ExpectedNumberOfArguments + 1)]
        public void Execute_Should_Throw_When_ArgumentCountDifferentThanExpected(int testValue)
        {
            //Arrange
            var commandParameters = TestHelpers.GetListWithSize(testValue);
            var command = new CreateNewPersonCommand(commandParameters, repository);
            //Act, Assert
            Assert.ThrowsException<InvalidUserInputException>(() => command.ExecuteCommand());
        }

        [TestMethod]
        [DataRow("smal")]
        [DataRow("way way way way way way too big for a name")]
        public void Execute_Should_Throw_When_NameSizeDoesNotMatch(string name)
        {
            //Arrange
            var commandParameters = new string[] { name }.ToList();
            var command = new CreateNewPersonCommand(commandParameters, repository);
            //Act, Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => command.ExecuteCommand());
        }

        [TestMethod]
        [DataRow("TestName3426543")]
        public void Execute_Should_Create_New_Person_WhenParamsAreValid(string value)
        {
            //Arrange
            var commandParameters = new string[] { value }.ToList();
            var command = new CreateNewPersonCommand(commandParameters, repository);
            //Act
            command.ExecuteCommand();
            var testMember = new Member(value);
            var sut = repository.GetMember(value);
            //Assert
            Assert.AreEqual(testMember.Name, sut.Name);
            Assert.AreEqual(testMember.Tasks.Count, sut.Tasks.Count);
        }

        [TestMethod]
        [DataRow("Test Name")]

        public void Execute_Should_Throw_When_MamberAlreasyExists(string value)
        {
            //Arrange
            var commandParameters = new string[] { value }.ToList();
            var sut = new CreateNewPersonCommand(commandParameters, repository);
            //Act, Assert
            sut.ExecuteCommand();
            Assert.ThrowsException<InvalidUserInputException>(() => sut.ExecuteCommand(), "A person with that name already exists");
        }


        //[TestMethod]
        //public void Execute_Should_ThrowException_When_()
        //{
        //Arrange
        //Act
        //Assert
        //}
        //[TestMethod]
        //public void Execute_Should_ThrowException_When_()
        //{
        //Arrange
        //Act
        //Assert
        //}
        //[TestMethod]
        //public void Execute_Should_ThrowException_When_()
        //{
        //Arrange
        //Act
        //Assert
        //}
    }
}
