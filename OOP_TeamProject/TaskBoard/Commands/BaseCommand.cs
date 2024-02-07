using System.Data;
using TasksBoard.Commands.Contracts;
using TasksBoard.Core.Contracts;
using TasksBoard.TaskBoard.Exceptions;
using TasksBoard.Models.Enums;
using TaskBoard.Models;

namespace TasksBoard.Commands
{
    abstract public class BaseCommand : ICommand
    {
        protected BaseCommand(IRepository repository)
            : this(new List<string>(), repository)
        {}

        protected BaseCommand(IList<string> commandParameters, IRepository repository)
        {
            this.CommandParameters = commandParameters;
            this.Repository = repository;
        }
        
        protected IRepository Repository { get; }
        protected IList<string> CommandParameters { get; }

        public abstract string ExecuteCommand();
        public int ParseIntParameter(string value, string parameterName)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}. Should be an integer number.");
        }

        public Priority ParsePriorityParameter(string value)
        {
            if (Enum.TryParse(value, true, out Priority result))
                return result;
            throw new InvalidUserInputException($"Invalid value for Priority. Should be either High, Medium or Low.");
        }

        public Severity ParseSeverityParameter(string value)
        {
            if (Enum.TryParse(value, true, out Severity result))
                return result;
            throw new InvalidUserInputException($"Invalid value for Severity. Should be either Critical, Major or Minor.");
        }
        public Size ParseSizeParameter(string value, string parameterName)
        {
            if (Enum.TryParse(value, true, out Size result))
                return result;
            throw new InvalidUserInputException($"Invalid value for {parameterName}. Should be either Large, Medium or Small.");
        }

        //commented out as they are never used in the current version of the project (Tomi)

        //protected List<string> ParseListOfStrings(string input)
        //{
        //    return input.Split('_').ToList();
        //}

        //protected BugStatus ParseBugStatusParameter(string value, string parameterName)
        //{
        //    if (Enum.TryParse(value, true, out BugStatus result))
        //        return result;
        //    throw new InvalidUserInputException($"Invalid value for {parameterName}. Should be either Active or Fixed.");
        //}

        //protected FeedbackStatus ParseFeedbackStatusParameter(string value, string parameterName)
        //{
        //    if (Enum.TryParse(value, true, out FeedbackStatus result))
        //        return result;
        //    throw new InvalidUserInputException($"Invalid value for {parameterName}. Should be either New, Unscheduled, Scheduled or Done.");
        //}

        //protected StoryStatus ParseStoryParameter(string value, string parameterName)
        //{
        //    if (Enum.TryParse(value, true, out StoryStatus result))
        //        return result;
        //    throw new InvalidUserInputException($"Invalid value for {parameterName}. Should be either NotDone, InProgress or Done.");
        //}
    }
}
