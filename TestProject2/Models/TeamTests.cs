using Program.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoard.Models;
using TasksBoard.Models.Contracts;
using TasksBoard.TaskBoard.Exceptions;

namespace TaskBoard.Tests.Models
{
    [TestClass]
    public class TeamTests
    {
        [TestMethod]
        public void Team_Constructor_ShouldInitializeProperties()
        {
            // Arrange
            string teamName = "Test Team";

            // Act
            Team team = new Team(teamName);

            // Assert
            Assert.AreEqual(teamName, team.Name);
            CollectionAssert.AreEqual(new List<IMember>(), team.Members);
            CollectionAssert.AreEqual(new List<IBoard>(), team.Boards);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementAlreadyExistsException))]
        public void Team_AddBoard_AlreadyExists_ShouldThrowException()
        {
            // Arrange
            Team team = new Team("Test Team");
            IBoard board1 = new Board("Board1");
            team.AddBoard(board1);

            // Act
            team.AddBoard(board1);
        }

        [TestMethod]
        public void Team_GetBoard_Exists_ShouldReturnBoard()
        {
            // Arrange
            Team team = new Team("Test Team");
            IBoard board1 = new Board("Board1");
            team.AddBoard(board1);

            // Act
            IBoard retrievedBoard = team.GetBoard("Board1");

            // Assert
            Assert.AreEqual(board1, retrievedBoard);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementAlreadyExistsException))]
        public void Team_GetBoard_NotExists_ShouldThrowException()
        {
            // Arrange
            Team team = new Team("Test Team");
            IBoard board1 = new Board("Board1");

            // Act
            team.GetBoard("Board1");
        }

        [TestMethod]
        public void Team_AddMemberToTeam_ShouldAddMember()
        {
            // Arrange
            Team team = new Team("Test Team");
            IMember member1 = new Member("Member1");

            // Act
            team.AddMemberToTeam(member1);

            // Assert
            CollectionAssert.AreEqual(new List<IMember> { member1 }, team.Members);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementAlreadyExistsException))]
        public void Team_AddMemberToTeam_AlreadyExists_ShouldThrowException()
        {
            // Arrange
            Team team = new Team("Test Team");
            IMember member1 = new Member("Member1");
            team.AddMemberToTeam(member1);

            // Act
            team.AddMemberToTeam(member1);
        }
    }
}
