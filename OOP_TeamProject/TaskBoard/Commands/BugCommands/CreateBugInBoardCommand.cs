using TaskBoard;
using TaskBoard.Models;
using TasksBoard.Commands;
using TasksBoard.Core.Contracts;
using TasksBoard.Models.Contracts;
using TasksBoard.Models.Enums;
using TasksBoard.TaskBoard.Exceptions;

namespace TasksBoard.TaskBoard.Commands.BugCommands
{
    public class CreateBugInBoardCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 6;  // [0]title     [1]description 
                                                         // [2]priority  [3]severity
                                                         // [4]team name [5]board name
        public CreateBugInBoardCommand(IList<string> commandParameters, IRepository repository) :
            base(commandParameters, repository)
        { }

        public override string ExecuteCommand()
        {
            ValidationHelper.ValidateNumberOfArguments(ExpectedNumberOfArguments, CommandParameters.Count);
            string bugTitle = CommandParameters[0];
            string bugDescription = CommandParameters[1];
            Priority priority = ParsePriorityParameter(CommandParameters[2]);
            Severity severity = ParseSeverityParameter(CommandParameters[3]);
            string teamName = CommandParameters[4];
            string boardName = CommandParameters[5];

            ITeam team = Repository.GetTeam(teamName);
            IBoard board = team.GetBoard(boardName);
            IBug bug = Repository.CreateBug(bugTitle, bugDescription, priority, severity);
            board.AddTask(bug);

            return $"Bug with ID \"{bug.Id}\" was successfully added to board {board.Name}";
        }
    }
}
