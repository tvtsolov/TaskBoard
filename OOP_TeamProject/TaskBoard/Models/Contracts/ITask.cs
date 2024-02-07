using TaskBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TasksBoard.Models.Contracts
{
    public interface ITask : IHasLog
    {
        string Title { get; }
        string Description { get; }
        string Assignee { get; }
        int Id { get; }
        List<IComment> Comments { get; }
        public void AddComment(IComment comment);
        public void AssignTask(string memberName);
        public void UnassignTask(string memberName);
    }
}
