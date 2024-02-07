using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using Newtonsoft.Json.Linq;
using System;
using TaskBoard.Models;
using TaskBoard.Tests.Helpers;
using TasksBoard.Commands;
using TasksBoard.Core;
using TasksBoard.Core.Contracts;
using TasksBoard.Models.Enums;
using TasksBoard.TaskBoard.Commands;
using TasksBoard.TaskBoard.Commands.BugCommands;
using TasksBoard.TaskBoard.Exceptions;


namespace TaskBoard.Tests.Commands
{
    [TestClass]
    public class AddPersonToTeamTest
    {


        [TestMethod]
        public void AddPersonToTeam_Should_Add_The_Member_To_A_Team()
        {
            Repository repository = new Repository();
            repository.CreateMember("Ivaan");
            repository.CreateTeam("MenInBlack");
            IList<string> paramsList = new List<string> { "Ivaan", "MenInBlack" };

            var command = new AddPersonToTeamCommand(paramsList, repository);
            command.ExecuteCommand();
            var team = repository.GetTeam("MenInBlack");
            var member = repository.GetMember("Ivaan");
            Assert.AreEqual(1, team.Members.Count);
            IList<string> memberList = new List<string> {"Ivaan"};
            Assert.AreEqual(member, team.Members[0]);
        }
        [TestMethod]
        public void ShouldThrow_Exception_When_Wrong_Team_Is_Given()
        {
            Repository repository = new Repository();
            repository.CreateMember("Ivaan");
            repository.CreateTeam("MenInBlack");
            IList<string> paramsList = new List<string> { "Ivaan", "WomenInBlack" };
            var command = new AddPersonToTeamCommand(paramsList, repository);
            Assert.ThrowsException<EntityNotFoundException>(() => command.ExecuteCommand());
        }
        [TestMethod]
        public void ShouldThrow_Exception_When_Too_Many_Arguments_Are_Given()
        {
            Repository repository = new Repository();
            repository.CreateMember("Ivaan");
            repository.CreateTeam("MenInBlack");
            IList<string> paramsList = new List<string> { "Ivaan", "MenINBldalfl", "Sleepy" };
            var command = new AddPersonToTeamCommand(paramsList, repository);
            Assert.ThrowsException<InvalidUserInputException>(() => command.ExecuteCommand());
        }
    }
}
