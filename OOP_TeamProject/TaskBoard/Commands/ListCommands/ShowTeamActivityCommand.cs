using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksBoard.Commands;
using TasksBoard.Core.Contracts;
using TasksBoard.TaskBoard.Exceptions;

namespace TasksBoard.TaskBoard.Commands.ListCommands
{
    public class ShowTeamActivityCommand : BaseCommand
    {
        public ShowTeamActivityCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }

        public override string ExecuteCommand()
        {
            if (this.CommandParameters.Count != 1)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: 1, Received: {this.CommandParameters.Count}");
            }
            string teamName = CommandParameters[0];
            return this.ShowTeamActivity(teamName);
        }
        private string ShowTeamActivity(string teamName)
        {
            var team = Repository.GetTeam(teamName);
            var sb = new StringBuilder();
            foreach (var member in team.Members)
            {
                sb.AppendLine(member.ShowActivityHistory());
            }
            return sb.ToString();
        }
    }
}
