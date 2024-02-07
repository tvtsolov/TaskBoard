using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksBoard.Commands;
using TasksBoard.Core.Contracts;
using TasksBoard.Models.Contracts;
using TasksBoard.TaskBoard.Exceptions;

namespace TasksBoard.TaskBoard.Commands.ListCommands
{
    public class ListAssigneeTasksCommand : BaseCommand
    {
        public ListAssigneeTasksCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }

        public override string ExecuteCommand()
        {
            if (this.CommandParameters.Count != 1)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: 1, Received: {this.CommandParameters.Count}");
            }
            string assignee = CommandParameters[0];
            return this.ListTasksByAssignee(assignee);
        }
        private string ListTasksByAssignee(string assignee)
        {
            var sb = new StringBuilder();
            foreach (var task in this.Repository.Tasks)
            {
                if (task.Assignee == assignee)
                {
                    sb.AppendLine($"{task.Id}: {task.Title}");
                }
            }
            return sb.ToString();
        }
    }
}
