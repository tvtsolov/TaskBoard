using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TasksBoard.Core.Contracts;
using TasksBoard.Core;

namespace TasksBoard
{
    public class Startup
    {
        public static void Main()
        {
            IRepository repository = new Repository();
            ICommandFactory commandFactory = new CommandFactory(repository);
            IEngine engine = new Core.Engine(commandFactory);
            engine.Start();
        }
    }
}
