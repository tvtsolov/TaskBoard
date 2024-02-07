using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoard;
using TasksBoard.Commands;
using TasksBoard.Core.Contracts;
using TasksBoard.Models.Contracts;
using TasksBoard.TaskBoard.Exceptions;

namespace TasksBoard.TaskBoard.Commands.FeedbackCommands
{
    public class ChangeStatusOfFeedbackCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2; // [0]"advance" or "revert" [1]feedback ID
        public ChangeStatusOfFeedbackCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository) { }
        public override string ExecuteCommand()
        {
            ValidationHelper.ValidateNumberOfArguments(ExpectedNumberOfArguments, CommandParameters.Count);

            string action = CommandParameters[0].ToLower().Trim(); ;
            int feedbackId = ParseIntParameter(CommandParameters[1], "feedback ID");
            IFeedback feedback = Repository.GetFeedback(feedbackId);
            switch (action)
            {
                case "advance":
                    feedback.AdvanceStatus();
                    feedback.AddLog($"Feedback with ID: {feedback.Id} - status changed to {feedback.Status}");
                    break;
                case "revert":
                    feedback.RevertStatus();
                    feedback.AddLog($"Feedback with ID: {feedback.Id} - status changed to {feedback.Status}");
                    break;
                default:
                    throw new InvalidUserInputException($"Invalid action: {action}, status change can be either Advance or Revert");
            }
            return $"Status of feedback with ID {feedback.Id} was changed to {feedback.Status}";
        }
    }
}
