using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TasksBoard.Commands;
using TasksBoard.Core.Contracts;

namespace TasksBoard.TaskBoard.Commands.ListCommands
{
    public class ShowAllTeamsCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 0;
        public ShowAllTeamsCommand(IRepository repository)
            : base(repository) {}

        public override string ExecuteCommand()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("============");
            sb.AppendLine($"{Repository.ShowAllTeams()}");
            return sb.ToString();
        }
    }
}
