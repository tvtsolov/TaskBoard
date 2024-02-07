using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoard.Models;
using TasksBoard.Models.Enums;

namespace TaskBoard.Tests.Models
{
    [TestClass]
    public class FeedbackTests
    {
        [TestMethod]
        public void Feedback_Constructor_ShouldInitializeProperties()
        {
            // Arrange
            string title = "Test Feedback";
            string description = "Test Description";
            int rating = 5;

            // Act
            Feedback feedback = new Feedback(title, description, rating);

            // Assert
            Assert.AreEqual(title, feedback.Title);
            Assert.AreEqual(description, feedback.Description);
            Assert.AreEqual(rating, feedback.Rating);
            Assert.AreEqual(FeedbackStatus.New, feedback.Status);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Feedback_Constructor_InvalidRating_ShouldThrowException()
        {
            // Arrange
            string title = "Test Feedback";
            string description = "Test Description";
            int invalidRating = 0;

            // Act
            Feedback feedback = new Feedback(title, description, invalidRating);
        }

        [TestMethod]
        public void Feedback_AdvanceStatus_ShouldChangeStatus()
        {
            // Arrange
            Feedback feedback = new Feedback("Test Feedback", "Test Description", 5);

            // Act
            feedback.AdvanceStatus();

            // Assert
            Assert.AreEqual(FeedbackStatus.Unscheduled, feedback.Status);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Feedback_AdvanceStatus_AlreadyDone_ShouldThrowException()
        {
            // Arrange
            Feedback feedback = new Feedback("Test Feedback", "Test Description", 5);
            feedback.AdvanceStatus();
            feedback.AdvanceStatus();
            feedback.AdvanceStatus();

            // Act
            feedback.AdvanceStatus();
        }

        [TestMethod]
        public void Feedback_RevertStatus_ShouldChangeStatus()
        {
            // Arrange
            Feedback feedback = new Feedback("Test Feedback", "Test Description", 5);
            feedback.AdvanceStatus();

            // Act
            feedback.RevertStatus();

            // Assert
            Assert.AreEqual(FeedbackStatus.New, feedback.Status);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Feedback_RevertStatus_AlreadyNew_ShouldThrowException()
        {
            // Arrange
            Feedback feedback = new Feedback("Test Feedback", "Test Description", 5);

            // Act
            feedback.RevertStatus();
        }

        [TestMethod]
        public void Feedback_ChangeRating_ShouldChangeRating()
        {
            // Arrange
            Feedback feedback = new Feedback("Test Feedback", "Test Description", 5);

            // Act
            feedback.ChangeRating(8);

            // Assert
            Assert.AreEqual(8, feedback.Rating);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Feedback_ChangeRating_SameRating_ShouldThrowException()
        {
            // Arrange
            Feedback feedback = new Feedback("Test Feedback", "Test Description", 5);

            // Act
            feedback.ChangeRating(5);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Feedback_ChangeRating_InvalidRating_ShouldThrowException()
        {
            // Arrange
            Feedback feedback = new Feedback("Test Feedback", "Test Description", 5);

            // Act
            feedback.ChangeRating(0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Feedback_ChangeRating_InvalidRatingRange_ShouldThrowException()
        {
            // Arrange
            Feedback feedback = new Feedback("Test Feedback", "Test Description", 5);

            // Act
            feedback.ChangeRating(11);
        }
    }
}
