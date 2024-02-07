using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksBoard.Commands;
using TasksBoard.Core.Contracts;
using TasksBoard.Models.Contracts;

namespace TasksBoard.TaskBoard.Commands.ListCommands
{
    public class ListAllStoriesCommand : BaseCommand
    {
        public ListAllStoriesCommand(IRepository repository) : base(repository)
        {
        }

        public override string ExecuteCommand()
        {
            List<IStory> stories = this.Repository.Tasks.OfType<IStory>().ToList();
            var sb = new StringBuilder();
            foreach (var story in stories)
            {
                sb.AppendLine($"ID: {story.Id} - {story.Title}: {story.Description}");
            }
            return sb.ToString();
        }
    }
}
