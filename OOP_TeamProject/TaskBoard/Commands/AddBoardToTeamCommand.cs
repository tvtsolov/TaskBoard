using TaskBoard;
using TasksBoard.Commands;
using TasksBoard.Core.Contracts;
using TasksBoard.Models.Contracts;

namespace TasksBoard.TaskBoard.Commands
{
    public class AddBoardToTeamCommand : BaseCommand

    {
        public const int ExpectedNumberOfArguments = 2; // [0]name of board [1]name of team
        public AddBoardToTeamCommand(IList<string> commandParameters, IRepository repository) 
            : base(commandParameters, repository) { }

        public override string ExecuteCommand()
        {
            ValidationHelper.ValidateNumberOfArguments(ExpectedNumberOfArguments, CommandParameters.Count);

            string boardName = this.CommandParameters[0];
            string teamName = this.CommandParameters[1];
            ITeam team = Repository.GetTeam(teamName);
            IBoard board = Repository.CreateBoard(boardName);
            team.AddBoard(board);
            board.AddLog($"Board {board.Name} added to team {team.Name}");

            return $"A board with name \"{board.Name}\" has been added to team {team.Name} successfully!";
        }
    }
}
