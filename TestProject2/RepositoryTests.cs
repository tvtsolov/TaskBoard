using System.Diagnostics.Metrics;
using System.Reflection;
using TaskBoard.Models;
using TasksBoard.Core;
using TasksBoard.Models.Contracts;
using TasksBoard.Models.Enums;
using TasksBoard.TaskBoard.Exceptions;

namespace TestProject2
{
    [TestClass]
    public class RepositoryTests
    {
        private Repository repository;

        [TestInitialize]
        public void Initialize()
        {
            repository = new Repository();
        }

        [TestMethod]
        public void GetMember_ExistingMember_ShouldReturnMember()
        {
            // Arrange
            string memberName = "John Doe";
            IMember member = repository.CreateMember(memberName);
            repository.AddMember(member);

            // Act
            IMember result = repository.GetMember(memberName);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(memberName, result.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void GetMember_NonExistingMember_ShouldThrowEntityNotFoundException()
        {
            // Arrange and Act
            repository.GetMember("NonExistingMember");
        }

        [TestMethod]
        public void GetStory_ExistingStory_ShouldReturnStory()
        {
            // Arrange
            string storyTitle = "TestStoryName";
            IStory story = repository.CreateStory(storyTitle, "Description", Priority.Medium, Size.Small);
            repository.AddTask(story);

            // Act
            IStory result = repository.GetStory(storyTitle);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(storyTitle, result.Title);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void GetStory_NonExistingStory_ShouldThrowEntityNotFoundException()
        {
            // Arrange and Act
            repository.GetStory("NonExistingStory");
        }

        [TestMethod]
        public void GetTeam_ExistingTeam_ShouldReturnTeam()
        {
            // Arrange
            string teamName = "TestTeam";
            ITeam team = repository.CreateTeam(teamName);
            repository.AddTeam(team);

            // Act
            ITeam result = repository.GetTeam(teamName);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(teamName, result.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void GetTeam_NonExistingTeam_ShouldThrowEntityNotFoundException()
        {
            // Arrange and Act
            repository.GetTeam("NonExistingTeam");
        }

        [TestMethod]
        public void TaskExist_ExistingTask_ShouldReturnTrue()
        {
            // Arrange
            string taskTitle = "TestTaskTitle";
            IStory story = repository.CreateStory(taskTitle, "Description", Priority.Medium, Size.Small);
            repository.AddTask(story);

            // Act
            bool result = repository.TaskExist(taskTitle);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IssueExist_NonExistingTask_ShouldReturnFalse()
        {
            // Arrange and Act
            bool result = repository.TaskExist("NonExistingTask");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MemberExist_ExistingMember_ShouldReturnTrue()
        {
            // Arrange
            string memberName = "John Doe";
            IMember member = repository.CreateMember(memberName);
            repository.AddMember(member);

            // Act
            bool result = repository.MemberExist(memberName);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MemberExist_NonExistingMember_ShouldReturnFalse()
        {
            // Arrange and Act
            bool result = repository.MemberExist("NonExistingMember");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void CreateBoard_ShouldCreateBoard()
        {
            // Arrange
            string boardName = "TestBoard";

            // Act
            IBoard board = repository.CreateBoard(boardName);

            // Assert
            Assert.IsNotNull(board);
            Assert.AreEqual(boardName, board.Name);
        }

        [TestMethod]
        public void CreateBug_ShouldCreateBugAndAddToTasks()
        {
            // Arrange
            string title = "TestBugName";
            string description = "Bug description";
            Priority priority = Priority.High;
            Severity severity = Severity.Major;

            // Act
            IBug bug = repository.CreateBug(title, description, priority, severity);

            // Assert
            Assert.IsNotNull(bug);
            Assert.AreEqual(title, bug.Title);
            Assert.AreEqual(description, bug.Description);
            Assert.AreEqual(priority, bug.Priority);
            Assert.AreEqual(severity, bug.Severity);

            Assert.IsTrue(repository.Tasks.Contains(bug));
        }

        [TestMethod]
        public void CreateFeedback_ShouldCreateFeedbackAndAddToTasks()
        {
            // Arrange
            string title = "TestFeedback";
            string description = "Feedback description";
            int rating = 5;

            // Act
            IFeedback feedback = repository.CreateFeedback(title, description, rating);

            // Assert
            Assert.IsNotNull(feedback);
            Assert.AreEqual(title, feedback.Title);
            Assert.AreEqual(description, feedback.Description);
            Assert.AreEqual(rating, feedback.Rating);

            Assert.IsTrue(repository.Tasks.Contains(feedback));
        }
        [TestMethod]
        public void CreateComment_ShouldCreateComment()
        {
            // Arrange
            string content = "Test comment";
            string author = "John Doe";

            // Act
            IComment comment = repository.CreateComment(content, author);

            // Assert
            Assert.IsNotNull(comment);
            Assert.AreEqual(content, comment.Content);
            Assert.AreEqual(author, comment.Author);
        }

        [TestMethod]
        public void GetTask_ExistingTaskById_ShouldReturnTask()
        {
            // Arrange
            ITask task = CreateTestTask();
            int taskId = task.Id;

            // Act
            ITask result = repository.GetTask(taskId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(task.Id, result.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void GetTask_NonExistingTaskById_ShouldThrowEntityNotFoundException()
        {
            // Arrange and Act
            repository.GetTask(123);
        }

        [TestMethod]
        public void GetTask_ExistingTaskByName_ShouldReturnTask()
        {
            // Arrange
            ITask task = CreateTestTask();
            string taskName = task.Title;

            // Act
            ITask result = repository.GetTask(taskName);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(task.Title, result.Title);
        }

        [TestMethod]
        public void GetBug_ExistingBug_ShouldReturnBug()
        {
            // Arrange
            IBug bug = CreateTestBug();
            string bugTitle = bug.Title;

            // Act
            IBug result = repository.GetBug(bugTitle);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(bug.Title, result.Title);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void GetBug_NonExistingBug_ShouldThrowEntityNotFoundException()
        {
            // Arrange and Act
            repository.GetBug("NonExistingBug");
        }

        private ITask CreateTestTask()
        {
            ITask task = repository.CreateStory("TestTaskName", "Description", Priority.Medium, Size.Small);
            repository.AddTask(task);
            return task;
        }

        private IBug CreateTestBug()
        {
            IBug bug = repository.CreateBug("TestBugName", "Description", Priority.High, Severity.Major);
            repository.AddTask(bug);
            return bug;
        }
        [TestMethod]
        public void GetBug_ExistingBugById_ShouldReturnBug()
        {
            // Arrange
            IBug bug = repository.CreateBug("TestBugName", "Description", Priority.High, Severity.Major);
            repository.AddTask(bug);
            int bugId = bug.Id;

            // Act
            IBug result = repository.GetBug(bugId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(bug.Id, result.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void GetBug_NonExistingBugById_ShouldThrowEntityNotFoundException()
        {
            // Arrange and Act
            repository.GetBug(123);
        }

        [TestMethod]
        public void GetFeedback_ExistingFeedback_ShouldReturnFeedback()
        {
            // Arrange
            IFeedback feedback = repository.CreateFeedback("TestFeedback", "Description", 5);
            repository.AddTask(feedback);
            string feedbackTitle = feedback.Title;

            // Act
            IFeedback result = repository.GetFeedback(feedbackTitle);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(feedback.Title, result.Title);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void GetFeedback_NonExistingFeedback_ShouldThrowEntityNotFoundException()
        {
            // Arrange and Act
            repository.GetFeedback("NonExistingFeedback");
        }
        [TestMethod]
        public void TeamExist_ExistingTeam_ShouldReturnTrue()
        {
            // Arrange
            string teamName = "TestTeam";
            ITeam team = repository.CreateTeam(teamName);
            repository.AddTeam(team);

            // Act
            bool teamExists = repository.TeamExist(teamName);

            // Assert
            Assert.IsTrue(teamExists);
        }

        [TestMethod]
        public void TeamExist_NonExistingTeam_ShouldReturnFalse()
        {
            // Arrange
            string teamName = "NonExistingTeam";

            // Act
            bool teamExists = repository.TeamExist(teamName);

            // Assert
            Assert.IsFalse(teamExists);
        }
    }

}