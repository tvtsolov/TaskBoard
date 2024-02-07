using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaskBoard;
using TasksBoard.Commands;
using TasksBoard.Core.Contracts;
using TasksBoard.Models.Contracts;
using TasksBoard.Models.Enums;

namespace TasksBoard.TaskBoard.Commands.FeedbackCommands
{
    public class CreateFeedbackInBoardCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 5;  // [0]title     [1]description 
                                                         // [2]rating    [3]team name
                                                         // [4]board name
        public CreateFeedbackInBoardCommand(IList<string> commandParameters, IRepository repository) 
            : base(commandParameters, repository)
        { }

        public override string ExecuteCommand()
        {
            ValidationHelper.ValidateNumberOfArguments(ExpectedNumberOfArguments, CommandParameters.Count);

            string feedbackTitle = CommandParameters[0];
            string feedbackDescription = CommandParameters[1];
            int rating = ParseIntParameter(CommandParameters[2], "rating");
            string teamName = CommandParameters[3];
            string boardName = CommandParameters[4];

            IFeedback feedback = Repository.CreateFeedback(feedbackTitle, feedbackDescription, rating);
            ITeam team = Repository.GetTeam(teamName);
            IBoard board = team.GetBoard(boardName);
            board.AddTask(feedback);
            feedback.AddLog($"Feedback with ID: {feedback.Id} created and successfully added to board {board.Name}!");
            return $"Feedback with ID: {feedback.Id} was successfully added to board {board.Name}";
        }
    }
}
