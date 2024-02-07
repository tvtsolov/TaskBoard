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
    public class ShowBoardActivityCommand : BaseCommand
    {
        public ShowBoardActivityCommand(IList<string> commandParameters, IRepository repository) 
            : base(commandParameters, repository)
        { }

        public override string ExecuteCommand()
        {
            if (this.CommandParameters.Count != 2)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: 2, Received: {this.CommandParameters.Count}");
            }
            string boardName = CommandParameters[0];
            string teamName = CommandParameters[1];
            return this.ShowBoardActivity(boardName, teamName);
        }

        private string ShowBoardActivity(string boardName, string teamName)
        {
            var board = this.Repository.GetBoard(boardName, teamName);
            var sb = new StringBuilder();
            sb.AppendLine($"Activity of board {board.Name} in team {teamName}:");
            sb.AppendLine(board.ShowActivityHistory());
            return sb.ToString();
        }
    }
}
