using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksBoard.Models.Enums;
using TasksBoard.Models.Contracts;

namespace TaskBoard.Models
{
    public class Story : Task, IStory
    {
        private const StoryStatus InitialStatus = StoryStatus.NotDone;
        private const StoryStatus FinalStatus = StoryStatus.Done;
        private const Priority InitialPriority = Priority.Low;
        private const Priority FinalPriority = Priority.High;
        private const Size MinimalSize = Size.Small;
        private const Size MaximalSize = Size.Large;

        public Story(string title, string description, Priority priority, Size size) : base(title, description)
        {
            Priority = priority;
            Status = StoryStatus.NotDone;
            Size = size;
            Assignee = "Unassigned";
        }

        public Priority Priority { get; private set; }
        public Size Size { get; private set; }

        public StoryStatus Status { get; private set; }

        public void AdvanceStatus()
        {
            if (Status == FinalStatus)
                throw new InvalidOperationException($"Status is already set to {FinalStatus}");
            Status++;
        }
        public void RevertStatus()
        {
            if (Status == InitialStatus)
                throw new InvalidOperationException($"Status is already set to {InitialStatus}");
            Status--;
        }

        public void AdvancePriority()
        {
            if (Priority == FinalPriority)
                throw new InvalidOperationException($"Priority is already set to {FinalPriority}");
            Priority++;
        }
        public void RevertPriority()
        {
            if (Priority == InitialPriority)
                throw new InvalidOperationException($"Priority is already set to {InitialPriority}");
            Priority--;
        }

        public void IncreaseSize()
        {
            if (Size == MaximalSize)
                throw new InvalidOperationException($"Size is already set to {MaximalSize}");
            Size++;
        }

        public void DecreaseSize()
        {
            if (Size == MinimalSize)
                throw new InvalidOperationException($"Size is already set to {MinimalSize}");
            Size--;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("--Story--");
            sb.Append(base.ToString());
            sb.AppendLine($"Priority: {Priority}");
            return sb.ToString();
        }
    }
}
