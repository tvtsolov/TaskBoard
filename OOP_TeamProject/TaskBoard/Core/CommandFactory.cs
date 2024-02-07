using TasksBoard.Commands.Contracts;
using TasksBoard.Core.Contracts;
using TasksBoard.TaskBoard.Commands;
using TasksBoard.TaskBoard.Commands.BugCommands;
using TasksBoard.TaskBoard.Commands.Enums;
using TasksBoard.TaskBoard.Commands.FeedbackCommands;
using TasksBoard.TaskBoard.Commands.ListCommands;
using TasksBoard.TaskBoard.Commands.StoryCommands;
using TasksBoard.TaskBoard.Exceptions;

namespace TasksBoard.Core
{
    public class CommandFactory : ICommandFactory
    {
        private const string SplitCommandBy = ", ";

        private readonly IRepository repository;
        public CommandFactory(IRepository repository)
        {
            this.repository = repository;
        }
        public ICommand Create(string commandLine)
        {
            CommandType commandType = ParseCommandType(commandLine);
            List<string> commandParameters = this.ExtractCommandParameters(commandLine); //trim 

            switch (commandType)
            {
                case CommandType.CreateNewPerson:
                    return new CreateNewPersonCommand(commandParameters, repository);
                case CommandType.ShowAllPeople:
                    return new ShowAllPeopleCommand(repository);
                case CommandType.ShowPersonActivity:
                    return new ShowPersonActivityCommand(commandParameters, repository);
                case CommandType.CreateTeam:
                    return new CreateTeamCommand(commandParameters,repository);
                case CommandType.ShowAllTeams:
                    return new ShowAllTeamsCommand(repository);
                case CommandType.ShowTeamActivity:
                    return new ShowTeamActivityCommand(commandParameters, repository);
                case CommandType.AddPersonToTeam:
                    return new AddPersonToTeamCommand(commandParameters, repository);
                case CommandType.ShowAllMembersInTeam:
                    return new ShowAllMembersInTeamCommand(commandParameters, repository);
                //case CommandType.ShowAllTeamBoards:
                //    return new ShowAllTeamBoardsCommand(commandParameters, repository);
                case CommandType.ShowBoardActivity:
                    return new ShowBoardActivityCommand(commandParameters, repository);
                case CommandType.AddStepsToReproduceToBug:
                    return new AddStepsToReproduceToBugCommand(commandParameters, repository);
                case CommandType.CreateBugInBoard:
                    return new CreateBugInBoardCommand(commandParameters, repository);
                case CommandType.ChangePriorityOfBug:
                    return new ChangePriorityOfBugCommand(commandParameters, repository);
                case CommandType.ChangeSeverityOfBug:
                    return new ChangeSeverityOfBugCommand(commandParameters, repository);
                case CommandType.ChangeStatusOfBug:
                    return new ChangeStatusOfBugCommand(commandParameters, repository);
                case CommandType.CreateStoryInBoard:
                    return new CreateStoryInBoardCommand(commandParameters, repository);
                case CommandType.CreateFeedbackInBoard:
                    return new CreateFeedbackInBoardCommand(commandParameters, repository);
                case CommandType.ChangePriorityOfStory:
                    return new ChangePriorityOfStoryCommand(commandParameters, repository);
                case CommandType.ChangeSizeOfStory:
                    return new ChangeSizeOfStoryCommand(commandParameters, repository);
                case CommandType.ChangeStatusOfStory:
                    return new ChangeStatusOfStoryCommand(commandParameters, repository);
                case CommandType.ChangeRatingOfFeedback:
                    return new ChangeRatingOfFeedbackCommand(commandParameters, repository);
                case CommandType.ChangeStatusOfFeedback:
                    return new ChangeStatusOfFeedbackCommand(commandParameters, repository);
                case CommandType.AssignTaskToPerson:
                    return new AssignTaskToPersonCommand(commandParameters, repository);
                case CommandType.UnassignTaskFromPerson:
                    return new UnassignTaskFromPersonCommand(commandParameters, repository);
                case CommandType.AddCommentToTask:
                    return new AddCommentToTaskCommand(commandParameters, repository);
                case CommandType.AddBoardToTeam:
                    return new AddBoardToTeamCommand(commandParameters, repository);
                case CommandType.ListAllTasks:
                    return new ListAllTasksCommand(repository);
                case CommandType.ListAllStories:
                    return new ListAllStoriesCommand(repository);
                case CommandType.ListAllBugs:
                    return new ListAllBugsCommand(repository);
                case CommandType.ListAllFeedbacks:
                    return new ListAllFeedbacksCommand(repository);
                case CommandType.ListAssigneeTasks:
                    return new ListAssigneeTasksCommand(commandParameters, repository);

                default:
                    throw new Exception($"Command with name: {commandType} doesn't exist!");
            }
        }
        private CommandType ParseCommandType(string commandLine)
        {
            string commandName = commandLine.Split(SplitCommandBy)[0];
            if (Enum.TryParse(commandName, true, out CommandType result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Command with name: {commandLine} doesn't exist!");
        }
        private List<string> ExtractCommandParameters(string commandLine)
        {
            List<string> parameters = new List<string>();
            parameters = commandLine.Split(SplitCommandBy).Skip(1).ToList();
            return parameters;
        }
    }
}