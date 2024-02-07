using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskBoard;
using TasksBoard.Commands;
using TasksBoard.Core.Contracts;
using TasksBoard.Models.Contracts;
using TasksBoard.TaskBoard.Exceptions;

namespace TasksBoard.TaskBoard.Commands.BugCommands
{
    public class ChangeSeverityOfBugCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2; // [0]"advance" or "revert" [1]bug ID
        public ChangeSeverityOfBugCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository) {}

        public override string ExecuteCommand()
        {
            ValidationHelper.ValidateNumberOfArguments(ExpectedNumberOfArguments, CommandParameters.Count);

            string action = CommandParameters[0].ToLower().Trim(); ;
            int bugId = ParseIntParameter(CommandParameters[1], "bug ID");
            IBug bug = Repository.GetBug(bugId);
            switch (action)
            {
                case "advance":
                    bug.AdvanceSeverity();
                    bug.AddLog($"Bug with ID: {bug.Id} - severity changed to {bug.Severity}");
                    break;
                case "revert":
                    bug.RevertSeverity();
                    bug.AddLog($"Bug with ID: {bug.Id} - severity changed to {bug.Severity}");
                    break;
                default:
                    throw new InvalidUserInputException($"Invalid action: {action}, severity change can be either Advance or Revert");
            }
            return $"Severity of bug with ID {bug.Id} was changed to {bug.Severity}";
        }
    }
}
