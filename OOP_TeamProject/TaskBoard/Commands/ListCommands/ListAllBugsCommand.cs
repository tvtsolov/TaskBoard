
using System.Text;
using TasksBoard.Commands;
using TasksBoard.Core.Contracts;
using TasksBoard.Models.Contracts;

namespace TasksBoard.TaskBoard.Commands.ListCommands
{
    public class ListAllBugsCommand : BaseCommand
    {
        public ListAllBugsCommand(IRepository repository) : base(repository)
        {
        }

        public override string ExecuteCommand()
        {
            List<IBug> bugs = this.Repository.Tasks.OfType<IBug>().ToList();
            var sb = new StringBuilder();
            foreach (var bug in bugs)
            {
                sb.AppendLine($"ID: {bug.Id} - {bug.Title}: {bug.Description}");
            }
            return sb.ToString();
        }
    }
}
