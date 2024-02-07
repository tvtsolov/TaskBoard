using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoard;
using TaskBoard.Models;
using TasksBoard.Commands;
using TasksBoard.Core.Contracts;
using TasksBoard.Models.Contracts;

namespace TasksBoard.TaskBoard.Commands.FeedbackCommands
{
    public class ChangeRatingOfFeedbackCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2; // [0]new value [1]feedback ID
        public ChangeRatingOfFeedbackCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository) { }

        public override string ExecuteCommand()
        {
            ValidationHelper.ValidateNumberOfArguments(ExpectedNumberOfArguments, CommandParameters.Count);
            int targetValue = ParseIntParameter(CommandParameters[0], "new rating");
            int feedbackId = ParseIntParameter(CommandParameters[1], "feedback ID");
            IFeedback feedback = Repository.GetFeedback(feedbackId);
            feedback.ChangeRating(targetValue);
            feedback.AddLog($"Feedback with ID: {feedback.Id} - Rating changed to {feedback.Rating}");
            return $"Rating was changed to {targetValue}";
        }
    }
}
