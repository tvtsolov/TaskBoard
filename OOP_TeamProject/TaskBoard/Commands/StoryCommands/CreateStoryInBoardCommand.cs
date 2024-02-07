using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TaskBoard;
using TaskBoard.Models;
using TasksBoard.Commands;
using TasksBoard.Core.Contracts;
using TasksBoard.Models.Contracts;
using TasksBoard.Models.Enums;

namespace TasksBoard.TaskBoard.Commands.StoryCommands
{
    public class CreateStoryInBoardCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 6; // [0]title     [1]description 
                                                        // [2]priority  [3]size
                                                        // [4]team name [5]board name
        public CreateStoryInBoardCommand(IList<string> commandParameters, IRepository repository) :
            base(commandParameters, repository)
        { }

        public override string ExecuteCommand()
        {
            ValidationHelper.ValidateNumberOfArguments(ExpectedNumberOfArguments, CommandParameters.Count);
            string storyTitle = CommandParameters[0];
            string storyDescription = CommandParameters[1];
            Priority priority = ParsePriorityParameter(CommandParameters[2]);
            Size size = ParseSizeParameter(CommandParameters[3], "story size");
            string teamName = CommandParameters[4];
            string boardName = CommandParameters[5];

            ITeam team = Repository.GetTeam(teamName);
            IBoard board = team.GetBoard(boardName);
            IStory story = Repository.CreateStory(storyTitle, storyDescription, priority, size);
            board.AddTask(story);
            story.AddLog($"Story with ID: {story.Id} - created and added to board {board.Name}!");

            return $"Story with ID \"{story.Id}\" was successfully added to board {board.Name}";
        }
    }
}
