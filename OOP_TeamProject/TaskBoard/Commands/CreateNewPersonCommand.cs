using TaskBoard;
using TasksBoard.Commands;
using TasksBoard.Core.Contracts;
using TasksBoard.Models.Contracts;
using TasksBoard.TaskBoard.Exceptions;

namespace TasksBoard.TaskBoard.Commands
{
    public class CreateNewPersonCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1;  //[0] person name

        public CreateNewPersonCommand(IList<string> commandParameters, IRepository repository)
            :base(commandParameters, repository)
        { }

        public override string ExecuteCommand()
        {
            ValidationHelper.ValidateNumberOfArguments(ExpectedNumberOfArguments, CommandParameters.Count);

            string name = this.CommandParameters[0];
            if (Repository.MemberExist(name))
            {
                throw new InvalidUserInputException("A person with that name already exists");
            }

            IMember member = Repository.CreateMember(name);
            return $"A person with name {name} has been created successfully!";
        }
    }
}
