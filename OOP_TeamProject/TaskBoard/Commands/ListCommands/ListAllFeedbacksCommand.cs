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
    public class ListAllFeedbacksCommand : BaseCommand
    {
        public ListAllFeedbacksCommand(IRepository repository) : base(repository)
        {
        }

        public override string ExecuteCommand()
        {
            List<IFeedback> feedbacks = this.Repository.Tasks.OfType<IFeedback>().ToList();
            var sb = new StringBuilder();
            foreach (var feedback in feedbacks)
            {
                sb.AppendLine($"ID: {feedback.Id} - {feedback.Title}: {feedback.Description}");
            }
            return sb.ToString();
        }
    }
}
