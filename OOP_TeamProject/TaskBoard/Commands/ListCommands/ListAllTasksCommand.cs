using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksBoard.Commands;
using TasksBoard.Core.Contracts;

namespace TasksBoard.TaskBoard.Commands.ListCommands
{
    public class ListAllTasksCommand : BaseCommand
    {
        public ListAllTasksCommand(IRepository repository) : base(repository)
        {
        }

        public override string ExecuteCommand()
        {
            var sb = new StringBuilder();
            foreach (var task in this.Repository.Tasks)
            {
                sb.AppendLine($"ID: {task.Id} - {task.Title}: {task.Description}");
            }
            return sb.ToString();
        }
    }
}
