using System.Text;
using TasksBoard.Commands;
using TasksBoard.Core.Contracts;
using TasksBoard.Models.Contracts;

namespace TasksBoard.TaskBoard.Commands.ListCommands
{
    public class ShowAllMembersInTeamCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2; // [0]team name

        public ShowAllMembersInTeamCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository) { }

        public override string ExecuteCommand()
        {
            string teamName = CommandParameters[0];
            ITeam team = Repository.GetTeam(teamName);
            StringBuilder sb = new();
            sb.AppendLine("=====================");
            team.Members.ForEach(member => sb.AppendLine(member.ToString()));
            return sb.ToString();
        }
    }
}
