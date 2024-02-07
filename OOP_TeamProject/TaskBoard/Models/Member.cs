using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TasksBoard.Models.Contracts;

namespace TaskBoard.Models
{
    public class Member : IMember
    {
        private const int MinMemberNameLength = 5;
        private const int MaxMemberNameLength = 15;

        private string name;
        private List<ITask> tasks = new List<ITask>();
        private List<EventLog> activityHistory = new List<EventLog>();

        public Member(string name)
        {
            Name = name;
        }
        public string Name
        {
            get => name;
            private set
            {
                ValidationHelper.ValidateStringLength(value, MinMemberNameLength, MaxMemberNameLength, "Member name");
                name = value;
            }
        }

        public List<ITask> Tasks
        {
            get => new List<ITask>(tasks);
        }

        public List<EventLog> ActivityHistory
        {
            get => new List<EventLog>(activityHistory);
        }

        public void AddTask(ITask task)
        {
            tasks.Add(task);
        }
        public void RemoveTask(ITask task)
        {
            tasks.Remove(task);
        }

        public void AddLog(string description)
        {
            EventLog eventLog = new EventLog(description);
            activityHistory.Add(eventLog);
        }

        public string ShowActivityHistory()
        {
            var sb = new StringBuilder();
            foreach (var activity in activityHistory)
            {
                sb.AppendLine(activity.ToString());
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            return this.Name.ToString();
        }
    }
}
