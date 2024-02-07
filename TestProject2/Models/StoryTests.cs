
using TaskBoard.Models;
using TasksBoard.Models.Enums;

namespace TaskBoard.Tests.Models
{
    [TestClass]
    public class StoryTests
    {
        [TestMethod]
        public void Story_Constructor_ShouldInitializeProperties()
        {
            // Arrange
            string title = "Test Story";
            string description = "Test Description";
            Priority priority = Priority.Medium;
            Size size = Size.Medium;

            // Act
            Story story = new Story(title, description, priority, size);

            // Assert
            Assert.AreEqual(title, story.Title);
            Assert.AreEqual(description, story.Description);
            Assert.AreEqual(priority, story.Priority);
            Assert.AreEqual(StoryStatus.NotDone, story.Status);
            Assert.AreEqual(size, story.Size);
            Assert.AreEqual("Unassigned", story.Assignee);
        }

        [TestMethod]
        public void Story_AdvanceStatus_ShouldIncrementStatus()
        {
            // Arrange
            Story story = new Story("Test Story", "Test Description", Priority.High, Size.Small);

            // Act
            story.AdvanceStatus();

            // Assert
            Assert.AreEqual(StoryStatus.InProgress, story.Status);
        }

        [TestMethod]
        public void Story_RevertStatus_ShouldDecrementStatus()
        {
            // Arrange
            Story story = new Story("Test Story", "Test Description", Priority.High, Size.Small);
            story.AdvanceStatus();

            // Act
            story.RevertStatus();

            // Assert
            Assert.AreEqual(StoryStatus.NotDone, story.Status);
        }

        [TestMethod]
        public void Story_AdvancePriority_ShouldIncrementPriority()
        {
            // Arrange
            Story story = new Story("Test Story", "Test Description", Priority.Low, Size.Small);

            // Act
            story.AdvancePriority();

            // Assert
            Assert.AreEqual(Priority.Medium, story.Priority);
        }

        [TestMethod]
        public void Story_RevertPriority_ShouldDecrementPriority()
        {
            // Arrange
            Story story = new Story("Test Story", "Test Description", Priority.Medium, Size.Small);

            // Act
            story.RevertPriority();

            // Assert
            Assert.AreEqual(Priority.Low, story.Priority);
        }

        [TestMethod]
        public void Story_IncreaseSize_ShouldIncrementSize()
        {
            // Arrange
            Story story = new Story("Test Story", "Test Description", Priority.Low, Size.Medium);

            // Act
            story.IncreaseSize();

            // Assert
            Assert.AreEqual(Size.Large, story.Size);
        }

        [TestMethod]
        public void Story_DecreaseSize_ShouldDecrementSize()
        {
            // Arrange
            Story story = new Story("Test Story", "Test Description", Priority.Low, Size.Large);

            // Act
            story.DecreaseSize();

            // Assert
            Assert.AreEqual(Size.Medium, story.Size);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Story_AdvanceStatus_AtFinalStatus_ShouldThrowException()
        {
            // Arrange
            Story story = new Story("Test Story", "Test Description", Priority.Low, Size.Small);
            story.AdvanceStatus();
            story.AdvanceStatus();

            // Act
            story.AdvanceStatus();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Story_RevertStatus_AtInitialStatus_ShouldThrowException()
        {
            // Arrange
            Story story = new Story("Test Story", "Test Description", Priority.Low, Size.Small);

            // Act
            story.RevertStatus();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Story_AdvancePriority_AtFinalPriority_ShouldThrowException()
        {
            // Arrange
            Story story = new Story("Test Story", "Test Description", Priority.Medium, Size.Small);
            story.AdvancePriority();

            // Act
            story.AdvancePriority();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Story_RevertPriority_AtInitialPriority_ShouldThrowException()
        {
            // Arrange
            Story story = new Story("Test Story", "Test Description", Priority.Low, Size.Small);

            // Act
            story.RevertPriority();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Story_IncreaseSize_AtMaximalSize_ShouldThrowException()
        {
            // Arrange
            Story story = new Story("Test Story", "Test Description", Priority.Low, Size.Large);

            // Act
            story.IncreaseSize();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Story_DecreaseSize_AtMinimalSize_ShouldThrowException()
        {
            // Arrange
            Story story = new Story("Test Story", "Test Description", Priority.Low, Size.Small);

            // Act
            story.DecreaseSize();
        }
    }
}