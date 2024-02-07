using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksBoard.Models.Enums;

namespace TasksBoard.Models.Contracts
{
    public interface IBug : ITask
    {
        List<string> StepsToReproduce { get; }
        Priority Priority { get; }
        Severity Severity { get; }
        BugStatus Status { get; }


        public void AdvanceStatus();
        public void RevertStatus();
        public void AdvancePriority();
        public void RevertPriority();
        public void AdvanceSeverity();
        public void RevertSeverity();
        public void AddStepsToReproduce(List<string> stepsToReproduce);
    }
}
