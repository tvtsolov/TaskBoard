using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoard;
using TasksBoard.Commands;
using TasksBoard.Core.Contracts;
using TasksBoard.Models.Contracts;
using TasksBoard.TaskBoard.Exceptions;

namespace TasksBoard.TaskBoard.Commands 
{
    public class AddPersonToTeamCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2; // [0]person's name [1]team's name
        public AddPersonToTeamCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository) { }

        public override string ExecuteCommand()
        {
            ValidationHelper.ValidateNumberOfArguments(ExpectedNumberOfArguments, CommandParameters.Count);

            string personName = CommandParameters[0];
            string teamName = CommandParameters[1];

            IMember member = Repository.GetMember(personName);
            ITeam team = Repository.GetTeam(teamName);

            team.AddMemberToTeam(member);
            member.AddLog($"Member {member.Name} was added to team {team.Name}");

            return $"Member {member.Name} was added to team {team.Name}";
        }
    }
}
