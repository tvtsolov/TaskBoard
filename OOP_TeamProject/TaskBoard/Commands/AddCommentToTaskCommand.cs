using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using TaskBoard;
using TasksBoard.Commands;
using TasksBoard.Core.Contracts;
using TasksBoard.Models.Contracts;
using TasksBoard.TaskBoard.Exceptions;

namespace TasksBoard.TaskBoard.Commands 
{
    
    public class AddCommentToTaskCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 3; // [0] comment to add 
                                                        // [1] task ID
                                                        // [2] author name
        public AddCommentToTaskCommand(IList<string> commandParameters, IRepository repository) :
            base(commandParameters, repository)
        { }


        public override string ExecuteCommand()
        {
            ValidationHelper.ValidateNumberOfArguments(ExpectedNumberOfArguments, CommandParameters.Count);

            string comment = this.CommandParameters[0];
            int taskId = ParseIntParameter(CommandParameters[1], "task ID");
            string authorName = this.CommandParameters[2];

            ITask task = Repository.GetTask(taskId);

            if (!Repository.MemberExist(authorName))
                throw new EntityNotFoundException($"No member with name {authorName} was found");
            
            IComment commentObj = Repository.CreateComment(comment, authorName);
            task.AddComment(commentObj);
            task.AddLog($"{authorName} added comment to task with ID: {task.Id}");

            return $"A comment was added to Task {taskId} successfully.";
        }



    }
}
