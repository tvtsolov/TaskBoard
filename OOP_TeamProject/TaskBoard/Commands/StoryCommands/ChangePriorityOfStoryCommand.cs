using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoard;
using TaskBoard.Models;
using TasksBoard.Commands;
using TasksBoard.Core.Contracts;
using TasksBoard.Models.Contracts;
using TasksBoard.TaskBoard.Exceptions;

namespace TasksBoard.TaskBoard.Commands.StoryCommands
{
    public class ChangePriorityOfStoryCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2; // [0]"advance" or "revert" [1]story ID

        public ChangePriorityOfStoryCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository) { }

        public override string ExecuteCommand()
        {
            ValidationHelper.ValidateNumberOfArguments(ExpectedNumberOfArguments, CommandParameters.Count);

            string action = CommandParameters[0].ToLower().Trim(); ;
            int storyId = ParseIntParameter(CommandParameters[1], "Story ID");
            IStory story = Repository.GetStory(storyId);
            switch (action)
            {
                case "advance":
                    story.AdvancePriority();
                    story.AddLog($"Story with ID: {story.Id} - priority changed to {story.Priority}");
                    break;
                case "revert":
                    story.RevertPriority();
                    story.AddLog($"Story with ID: {story.Id} - priority changed to {story.Priority}");
                    break;
                default:
                    throw new InvalidUserInputException($"Invalid action: {action}, priority change can be either Advance or Revert");
            }
            return $"Priority of story with ID {story.Id} was changed to {story.Priority}";
        }
    }
}
