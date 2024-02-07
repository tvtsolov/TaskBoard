using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TasksBoard.Models.Contracts;

namespace TaskBoard.Models
{
    public class Board : IBoard
    {
        private const int BoardNameMinLength = 5;
        private const int BoardNameMaxLength = 10;
        private string name;
        private readonly List<ITask> tasks = new List<ITask>();
        private readonly List<EventLog> activityHistory = new List<EventLog>();

        public Board(string name)
        {
            Name = name;
        }

        public string Name
        {
            get => name;
            private set
            {
                ValidationHelper.ValidateStringLength(value, BoardNameMinLength, BoardNameMaxLength, "Board Name"); //todo needs a check for null (Tomi)
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

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var issue in tasks)
            {
                sb.Append(issue.ToString());
            }
            return sb.ToString();
        }

        public string ShowActivityHistory()
        {
            var sb = new StringBuilder();
            foreach (var log in activityHistory)
            {
                sb.AppendLine(log.ToString());
            }
            foreach (var task in tasks)
            {
                sb.AppendLine(task.ShowActivityHistory());
            }
            return sb.ToString().Trim();
        }

        public void RemoveTask(ITask issue)
        {
            throw new NotImplementedException();
        }

        public void AddLog(string description)
        {
            EventLog log = new EventLog(description);
            activityHistory.Add(log);
        }
    }
}
