using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksBoard.Models.Enums;
using TasksBoard.Models.Contracts;
using TasksBoard.TaskBoard.Commands;

namespace TaskBoard.Models
{
    public class Bug : Task, IBug
    {
        private List<string> stepsToReproduce = new List<string>();

        public Bug(string title, string description, Priority priority, Severity severity) 
            : base(title, description)
        {
            Priority = priority;
            Severity = severity;
            Status = BugStatus.Active;
            Assignee = "Unassigned";
        }

        public List<string> StepsToReproduce
        {
            get { return new List<string>(stepsToReproduce); }
        }

        public Priority Priority { get; private set; }

        public Severity Severity { get; private set; }

        public BugStatus Status { get; private set; }

        public void AddStepsToReproduce(List<string> stepsToReproduce)
        {
            this.stepsToReproduce = stepsToReproduce;
        }

        public void AdvanceStatus()
        {
            if (Status == BugStatus.Fixed)
            {
                throw new InvalidOperationException($"Status is already {BugStatus.Fixed}");
            }
            Status++;
        }
        public void RevertStatus()
        {
            if (Status == BugStatus.Active)
            {
                throw new InvalidOperationException($"Status is already {BugStatus.Active}");
            }
            Status--;
        }

        public void AdvancePriority()
        {
            if (Priority == Priority.High)
                throw new InvalidOperationException($"Priority is already set to High");
            Priority++;
        }

        public void RevertPriority()
        {
            if (Priority == Priority.Low)
                throw new InvalidOperationException($"Priority is already set to Low");
            Priority--;
        }

        public void AdvanceSeverity()
        {
            if (Severity == Severity.Critical)
                throw new InvalidOperationException($"Severity is already set to Critical");
            Severity++;
        }

        public void RevertSeverity()
        {
            if (Severity == Severity.Minor)
                throw new InvalidOperationException($"Severity is already set to Minor");
            Severity--;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("--Bug--");
            sb.Append(base.ToString());
            sb.AppendLine($"Priority: {Priority}");
            sb.AppendLine($"Severity: {Severity}");
            return sb.ToString();
        }
    }
}
