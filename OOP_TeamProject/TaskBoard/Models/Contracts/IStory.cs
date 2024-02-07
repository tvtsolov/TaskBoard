using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksBoard.Models.Enums;

namespace TasksBoard.Models.Contracts
{
    public interface IStory: ITask
    {
        Priority Priority { get; }
        Size Size { get; }
        StoryStatus Status { get; }
        public void AdvanceStatus();
        public void RevertStatus();
        public void AdvancePriority();
        public void RevertPriority();
        public void IncreaseSize();
        public void DecreaseSize();

    }
}
