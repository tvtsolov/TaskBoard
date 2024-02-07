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

namespace TasksBoard.TaskBoard.Commands.BugCommands
{
    public class ChangeStatusOfBugCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2; // [0]"advance" or "revert" [1]bug ID
        public ChangeStatusOfBugCommand(IList<string> commandParameters, IRepository repository) 
            : base(commandParameters, repository) {}

        public override string ExecuteCommand()
        {
            ValidationHelper.ValidateNumberOfArguments(ExpectedNumberOfArguments, CommandParameters.Count);
            
            string action = CommandParameters[0].ToLower().Trim(); ;
            int bugId = ParseIntParameter(CommandParameters[1], "Bug ID");
            IBug bug = Repository.GetBug(bugId);
            switch(action)
            {
                case "advance":
                    bug.AdvanceStatus();
                    bug.AddLog($"Bug with ID: {bug.Id} - status changed to {bug.Status}");
                    break;
                case "revert":
                    bug.RevertStatus();
                    bug.AddLog($"Bug with ID: {bug.Id} - status changed to {bug.Status}");
                    break;
                default:
                    throw new InvalidUserInputException($"Invalid action: {action}, status change can be either Advance or Revert");
            }
            return $"Status of bug with ID {bug.Id} was changed to {bug.Status}";
        }
    }
}
