using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TasksBoard.Commands.Contracts;

namespace TasksBoard.Core.Contracts
{
    public interface ICommandFactory
    {
        ICommand Create(string commandLine);
    }
}
