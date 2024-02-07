﻿using TaskBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace TasksBoard.Models.Contracts
{
    public interface IMember : IHasTasks, IHasLog
    {
        string Name { get; }
        string ToString();
    }
}
