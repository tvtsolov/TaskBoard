using Program.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoard;
using TaskBoard.Models;
using TasksBoard.Commands;
using TasksBoard.Core.Contracts;

namespace TasksBoard.TaskBoard.Commands.BugCommands
{
    public class AddStepsToReproduceToBugCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2; // [0] steps [1] bugId

        public AddStepsToReproduceToBugCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository) { }

        public override string ExecuteCommand()
        {
            ValidationHelper.ValidateNumberOfArguments(ExpectedNumberOfArguments, CommandParameters.Count);
            string steps = CommandParameters[0];
            int bugId = ParseIntParameter(CommandParameters[1], "Bug ID");
            var bug = Repository.GetBug(bugId);
            List<string> stepsList = steps.Split("; ").ToList();
            bug.AddStepsToReproduce(stepsList);
            bug.AddLog($"A list of steps to reproduce were added to bug {bugId}");

            return $"A list of steps to reproduce were added to bug with id {bugId}";
        }
    }
}
