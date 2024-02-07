using TasksBoard.Commands;
using TasksBoard.Core.Contracts;
using TasksBoard.Models.Contracts;

namespace TasksBoard.TaskBoard.Commands.ListCommands
{
    public class ShowPersonActivityCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1; //[0] person's name

        public ShowPersonActivityCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository) { }

        public override string ExecuteCommand()
        {
            string personName = CommandParameters[0];
            IMember member = Repository.GetMember(personName);
            string output = member.ShowActivityHistory();
            return output;
        }
    }
}
