﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksBoard.Commands.Contracts
{
    public interface ICommand
    {
        string ExecuteCommand();
    }
}
