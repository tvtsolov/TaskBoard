using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksBoard.Models.Contracts
{
    public interface ITeam
    {
        string Name { get; }
        List<IMember> Members { get; }
        List<IBoard> Boards { get; }
        void AddMemberToTeam(IMember member);
        void AddBoard(IBoard board);
        string ListAllTeamMembers();
        public string ShowAllTeamBoards();

        public IBoard GetBoard(string name);
    }
}
