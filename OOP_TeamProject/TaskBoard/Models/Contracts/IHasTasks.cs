using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoard.Models;

namespace TasksBoard.Models.Contracts
{
    public interface IHasTasks
    {
        List<ITask> Tasks { get; }
        void AddTask(ITask task);
        public void RemoveTask(ITask issue);

    }
}
