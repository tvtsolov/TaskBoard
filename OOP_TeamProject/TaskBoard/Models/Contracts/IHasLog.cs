using TaskBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksBoard.Models.Contracts
{
    public interface IHasLog
    {
        List<EventLog> ActivityHistory { get; }
        void AddLog(string description);
        string ShowActivityHistory();

    }
}
