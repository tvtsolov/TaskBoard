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

namespace TasksBoard.TaskBoard.Commands
{
    public class UnassignTaskFromPersonCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 3; // [0]task ID
                                                         // [1]name of person/assignee to unassign from
                                                         // [2]team name

        public UnassignTaskFromPersonCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository) { }

        public override string ExecuteCommand()
        {
            ValidationHelper.ValidateNumberOfArguments(ExpectedNumberOfArguments, CommandParameters.Count);

            int taskId = ParseIntParameter(CommandParameters[0], "task ID");
            string personName = CommandParameters[1];
            string teamName = CommandParameters[2];

            IMember person = Repository.GetMember(personName);
            ITeam team = Repository.GetTeam(teamName);  

            if (!team.Boards.Any(board => board.Tasks.Any(Task => Task.Id == taskId)))  // check if this task is really in any of the boards in that team
                throw new InvalidUserInputException($"Team {teamName} does not have a board with this task ID: {taskId}");

            ITask task = Repository.GetTask(taskId);

            if (task is Feedback)
                throw new InvalidUserInputException("Feeback cannot be assigned/unassigned");

            person.RemoveTask(task);
            task.UnassignTask(personName); //removes assignee, maybe we should call it removeAssignee? (Tomi)
            task.AddLog($"Task with ID: {task.Id} unassigned from {person.Name}");

            return $"{task.GetType().Name} {task.Id} \"{task.Title}\" was unassigned from {person.Name}.";
        }
    }
}
