
using TaskBoard.Models;
using TasksBoard.Models.Enums;

namespace TaskBoard.Tests.Models
{
    [TestClass]
    public class BugTests
    {
        [TestMethod]
        public void Bug_Constructor_ShouldInitializeProperties()
        {
            // Arrange
            string title = "TestBugName";
            string description = "Test Description";
            Priority priority = Priority.Medium;
            Severity severity = Severity.Major;

            // Act
            Bug bug = new Bug(title, description, priority, severity);

            // Assert
            Assert.AreEqual(title, bug.Title);
            Assert.AreEqual(description, bug.Description);
            Assert.AreEqual(priority, bug.Priority);
            Assert.AreEqual(severity, bug.Severity);
            Assert.AreEqual(BugStatus.Active, bug.Status);
            Assert.AreEqual("Unassigned", bug.Assignee);
            Assert.IsNotNull(bug.StepsToReproduce);
        }

        [TestMethod]
        public void Bug_AddStepsToReproduce_ShouldSetStepsToReproduce()
        {
            // Arrange
            Bug bug = new Bug("TestBugName", "Test Description", Priority.Medium, Severity.Major);
            List<string> stepsToReproduce = new List<string>
        {
            "Step 1",
            "Step 2",
            "Step 3"
        };

            // Act
            bug.AddStepsToReproduce(stepsToReproduce);

            // Assert
            CollectionAssert.AreEqual(stepsToReproduce, bug.StepsToReproduce.ToList());
        }

        [TestMethod]
        public void Bug_AdvanceStatus_ShouldChangeStatus()
        {
            // Arrange
            Bug bug = new Bug("TestBugName", "Test Description", Priority.Medium, Severity.Major);

            // Act
            bug.AdvanceStatus();

            // Assert
            Assert.AreEqual(BugStatus.Fixed, bug.Status);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Bug_AdvanceStatus_AlreadyFixed_ShouldThrowException()
        {
            // Arrange
            Bug bug = new Bug("TestBugName", "Test Description", Priority.Medium, Severity.Major);
            bug.AdvanceStatus();
            bug.AdvanceStatus();
            bug.AdvanceStatus();
            bug.AdvanceStatus();

            // Act
            bug.AdvanceStatus();
        }
        [TestMethod]
        public void Bug_RevertStatus_ShouldChangeStatus()
        {
            // Arrange
            Bug bug = new Bug("TestBugName", "Test Description", Priority.Medium, Severity.Major);
            bug.AdvanceStatus();

            // Act
            bug.RevertStatus();

            // Assert
            Assert.AreEqual(BugStatus.Active, bug.Status);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Bug_RevertStatus_AlreadyActive_ShouldThrowException()
        {
            // Arrange
            Bug bug = new Bug("TestBugName", "Test Description", Priority.Medium, Severity.Major);

            // Act
            bug.RevertStatus();
        }

        [TestMethod]
        public void Bug_AdvancePriority_ShouldChangePriority()
        {
            // Arrange
            Bug bug = new Bug("TestBugName", "Test Description", Priority.Medium, Severity.Major);

            // Act
            bug.AdvancePriority();

            // Assert
            Assert.AreEqual(Priority.High, bug.Priority);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Bug_AdvancePriority_AlreadyHigh_ShouldThrowException()
        {
            // Arrange
            Bug bug = new Bug("TestBugName", "Test Description", Priority.High, Severity.Major);

            // Act
            bug.AdvancePriority();
        }

        [TestMethod]
        public void Bug_RevertPriority_ShouldChangePriority()
        {
            // Arrange
            Bug bug = new Bug("TestBugName", "Test Description", Priority.Medium, Severity.Major);

            // Act
            bug.RevertPriority();

            // Assert
            Assert.AreEqual(Priority.Low, bug.Priority);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Bug_RevertPriority_AlreadyLow_ShouldThrowException()
        {
            // Arrange
            Bug bug = new Bug("TestBugName", "Test Description", Priority.Low, Severity.Major);

            // Act
            bug.RevertPriority();
        }
        [TestMethod]
        public void Bug_AdvanceSeverity_ShouldChangeSeverity()
        {
            // Arrange
            Bug bug = new Bug("TestBugName", "Test Description", Priority.Medium, Severity.Major);

            // Act
            bug.AdvanceSeverity();

            // Assert
            Assert.AreEqual(Severity.Critical, bug.Severity);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Bug_AdvanceSeverity_AlreadyCritical_ShouldThrowException()
        {
            // Arrange
            Bug bug = new Bug("TestBugName", "Test Description", Priority.Medium, Severity.Critical);

            // Act
            bug.AdvanceSeverity();
        }

        [TestMethod]
        public void Bug_RevertSeverity_ShouldChangeSeverity()
        {
            // Arrange
            Bug bug = new Bug("TestBugName", "Test Description", Priority.Medium, Severity.Major);

            // Act
            bug.RevertSeverity();

            // Assert
            Assert.AreEqual(Severity.Minor, bug.Severity);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Bug_RevertSeverity_AlreadyHigh_ShouldThrowException()
        {
            // Arrange
            Bug bug = new Bug("TestBugName", "Test Description", Priority.Medium, Severity.Minor);

            // Act
            bug.RevertSeverity();
        }

    }
}
