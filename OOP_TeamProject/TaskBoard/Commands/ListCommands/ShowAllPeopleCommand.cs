using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TaskBoard;
using TasksBoard.Commands;
using TasksBoard.Core.Contracts;

namespace TasksBoard.TaskBoard.Commands.ListCommands
{
    public class ShowAllPeopleCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 0;
        public ShowAllPeopleCommand(IRepository repository)
            : base(repository) { }

        public override string ExecuteCommand()
        {
            ValidationHelper.ValidateNumberOfArguments(ExpectedNumberOfArguments, CommandParameters.Count);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=============");
            sb.AppendLine($"{Repository.ShowAllPeople()}");
            return sb.ToString();
        }
    }
}
