using TasksBoard.Core.Contracts;
using TasksBoard.Core;
using TaskBoard.Models;
using TasksBoard.Models.Contracts;
using TasksBoard.Models.Enums;
using TasksBoard.TaskBoard.Commands;

namespace TaskBoard.Tests.Helpers
{
    public class TestHelpers
    {
        public static IRepository GetTestRepository()
        {
            return new Repository();
        }
        public static List<string> GetListWithSize(int size)
        {
            return new string[size].ToList();
        }
        public static ITask GetTestTask()
        {
            return new Bug(
                    title: "Title_test",
                    description: "Description_test",
                    priority: Priority.Low,
                    severity: Severity.Minor);
        }
        public static IBug GetTestBug()
        {
            {
                return new Bug(
                        title: "Title_test",
                        description: "Description_test",
                        priority: Priority.Low,
                        severity: Severity.Minor);
            }
        }
        public static IStory GetTestStory()
        {
            {
                return new Story(
                        title: "Title_test",
                        description: "Description_test",
                        priority: Priority.Low,
                        size: Size.Small);
            }
        }
        public static IFeedback GetTestFeedback()
        {
            {
                return new Feedback(
                        title: "Title_test",
                        description: "Description_test",
                        rating: 1);
            }
        }
        public static string GetStringWithSize(int size)
        {
            return new string('x', size);
        }

        public static CreateNewPersonCommand GetTestCommand()
        {
            var repoTest = GetTestRepository();
            List<string> parameters = new string[] { "Test_Name" }.ToList();
            var newTestCommand = new CreateNewPersonCommand(parameters, repoTest);

            return newTestCommand;
        } 
        /*
        public static List<string> GetValidParametersFor_CreateNewPersonCommand 
        public static List<string> GetValidParametersFor_ShowAllPeopleCommand
        public static List<string> GetValidParametersFor_ShowPersonActivityCommand  
        public static List<string> GetValidParametersFor_CreateTeamCommand
        public static List<string> GetValidParametersFor_ShowAllTeamsCommand
        public static List<string> GetValidParametersFor_ShowTeamActivityCommand
        public static List<string> GetValidParametersFor_AddPersonToTeamCommand
        public static List<string> GetValidParametersFor_ShowAllMembersInTeamCommand
        public static List<string> GetValidParametersFor_ShowAllTeamBoardsCommand
        public static List<string> GetValidParametersFor_ShowBoardActivityCommand
        public static List<string> GetValidParametersFor_CreateStoryCommand
        public static List<string> GetValidParametersFor_AddBoardToTeamCommand
        public static List<string> GetValidParametersFor_CreateBugCommand
        public static List<string> GetValidParametersFor_CreateFeedbackCommand
        public static List<string> GetValidParametersFor_CreateBugInBoardCommand
        public static List<string> GetValidParametersFor_CreateStoryInBoardCommand
        public static List<string> GetValidParametersFor_CreateFeedbackInBoardCommand
        public static List<string> GetValidParametersFor_ChangePriorityOfBugCommand
        public static List<string> GetValidParametersFor_ChangeSeverityOfBugCommand
        public static List<string> GetValidParametersFor_ChangeStatusOfBugCommand
        public static List<string> GetValidParametersFor_ChangePriorityOfStoryCommand
        public static List<string> GetValidParametersFor_ChangeSizeOfStoryCommand
        public static List<string> GetValidParametersFor_ChangeStatusOfStoryCommand
        public static List<string> GetValidParametersFor_ChangeRatingOfFeedbackCommand
        public static List<string> GetValidParametersFor_ChangeStatusOfFeedbackCommand
        public static List<string> GetValidParametersFor_AssignTaskToPersonCommand
        public static List<string> GetValidParametersFor_UnassignTaskFromPersonCommand
        public static List<string> GetValidParametersFor_AddCommentToTaskCommand
        public static List<string> GetValidParametersFor_ListAllTasksCommand
        public static List<string> GetValidParametersFor_ListAllStoriesCommand
        public static List<string> GetValidParametersFor_ListAllBugsCommand
        public static List<string> GetValidParametersFor_ListAllFeedbacksCommand
        public static List<string> GetValidParametersFor_ListAssigneeTasksCommand
        */

    }
}
