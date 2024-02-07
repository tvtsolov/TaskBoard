using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksBoard.Models.Enums;

namespace TasksBoard.Models.Contracts
{
    public interface IFeedback : ITask
    {
        int Rating { get; }
        FeedbackStatus Status { get; }
        public void AdvanceStatus();
        public void RevertStatus();
        public void ChangeRating(int targetRating);
    }
}
