using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksBoard.Models.Contracts;

namespace TaskBoard.Models
{
    public abstract class Task : ITask
    {
        private string title;
        public int TaskTitleMinLength = 10;
        private const int TaskTitleMaxLength = 50;

        private string description;
        private const int TaskDescriptionMinLength = 10;
        private const int TaskDescriptionMaxLength = 500;

        private List<IComment> comments = new List<IComment>();
        private List<EventLog> activityHistory = new List<EventLog>();
        private static int counter = 0;

        public Task(string title, string description) 
        {
            Title = title;
            Description = description;
            Id = ++counter;
        }
        public string Title
        {
            get => title;
            private set
            {
                ValidationHelper.ValidateStringLength(value, TaskTitleMinLength, TaskTitleMaxLength, "Title"); 
                title = value;
            }
        }

        public string Description
        {
            get => description;
            private set
            {
                ValidationHelper.ValidateStringLength(value, TaskDescriptionMinLength, TaskDescriptionMaxLength, "description"); 
                description = value;
            }
        }
        public int Id { get; private set; }
        public string Assignee { get; set; } //todo to add some validation here, also Feedbacks cannot have Assignee (Tomi)
                                                        
        public List<IComment> Comments
        {
            get => new List<IComment>(comments);
        }
        public List<EventLog> ActivityHistory
        {
            get => new List<EventLog>(activityHistory);
        }

        public void AddLog(string description)
        {
            EventLog log = new EventLog(description);
            activityHistory.Add(log);
        }
        public string ShowActivityHistory()
        {
            var sb = new StringBuilder();
            foreach (var activity in activityHistory)
            {
                sb.AppendLine(activity.ToString());
            }
            return sb.ToString().Trim();
        }

        public void AddComment(IComment comment)
        {
            comments.Add(comment);
        }

        public void AssignTask(string memberName)
        {
            if (Assignee == memberName)
            {
                throw new InvalidOperationException($"Assignee is already {memberName}");
            }
            Assignee = memberName;
        }

        public void UnassignTask(string memberName)
        {
            if (Assignee == memberName)
            {
                throw new InvalidOperationException($"The task {Id} is not assigned to {memberName}");
            }
            Assignee = "Unassigned";
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Title);
            sb.AppendLine(Description);
            return sb.ToString();
        }
    }
}
