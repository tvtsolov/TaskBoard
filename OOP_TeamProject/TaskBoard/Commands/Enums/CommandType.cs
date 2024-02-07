using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksBoard.TaskBoard.Commands.Enums
{
    public enum CommandType
    {
        CreateNewPerson,
        ShowAllPeople,
        ShowPersonActivity,
        CreateTeam,
        ShowAllTeams,
        ShowTeamActivity,
        AddPersonToTeam,
        ShowAllMembersInTeam,
        ShowAllTeamBoards,
        ShowBoardActivity,
        CreateStory,
        AddBoardToTeam,
        CreateBug,
        CreateFeedback,
        CreateBugInBoard,
        CreateStoryInBoard,
        CreateFeedbackInBoard,
        ChangePriorityOfBug,
        ChangeSeverityOfBug,
        ChangeStatusOfBug,
        ChangePriorityOfStory,
        ChangeSizeOfStory,
        ChangeStatusOfStory,
        ChangeRatingOfFeedback,
        ChangeStatusOfFeedback,
        AssignTaskToPerson,
        UnassignTaskFromPerson,
        AddCommentToTask,
        AddStepsToReproduceToBug,
        ListAllTasks,
        ListAllStories,
        ListAllBugs,
        ListAllFeedbacks,
        ListAssigneeTasks
    }

}
