using TaskBoard;
using TasksBoard.Commands;
using TasksBoard.Core.Contracts;
using TasksBoard.Models.Contracts;

namespace TasksBoard.TaskBoard.Commands
{
    public class CreateTeamCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1; // [0] the name of the Team

        public CreateTeamCommand(IList<string> commandParameters, IRepository repository) : 
            base (commandParameters, repository) {}
        
 
        public override string ExecuteCommand()
        {
            ValidationHelper.ValidateNumberOfArguments(ExpectedNumberOfArguments, CommandParameters.Count);

            string teamName = this.CommandParameters[0];

            ITeam team = Repository.CreateTeam(teamName);
            return $"A team with name {teamName} has been created successfully!";
        }
    }
}
