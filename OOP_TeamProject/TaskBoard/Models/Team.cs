using TaskBoard;
using TaskBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TasksBoard.Models.Contracts;
using TasksBoard.TaskBoard.Exceptions;

namespace Program.Models
{
    public class Team : ITeam
    {
        private const int TeamNameMinLength = 5;
        private const int TeamNameMaxLength = 15;
        private readonly IList<IMember> members = new List<IMember>();
        private readonly IList<IBoard> boards = new List<IBoard>();
        private string name;
        public Team(string name)
        {
            Name = name;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                ValidationHelper.ValidateStringLength(value, TeamNameMinLength, TeamNameMaxLength, "Team Name");
                name = value;
            }
        }

        public List<IMember> Members
        {
            get => new List<IMember>(members);
        }

        public List<IBoard> Boards
        {
            get => new List<IBoard>(boards);
        }

        public void AddBoard(IBoard board)
        {
            if (BoardExist(board.Name))
                throw new ElementAlreadyExistsException($"A board with name {board.Name} already exists in theam {this.Name}");
            boards.Add(board);
        }

        public IBoard GetBoard(string name) 
        {
            if (!BoardExist(name))
                throw new ElementAlreadyExistsException($"Board with title {name} doesn't exist in this team");
            return boards.First(board => board.Name == name);
        }
        public bool BoardExist(string boardName)
        {
            return Boards.Any(board => board.Name == boardName);
        }
        public void AddMemberToTeam(IMember member)
        {
            if(members.Any(mem => mem == member))
                throw new ElementAlreadyExistsException($"Member {member.Name} already is part of team {this.Name}");
            members.Add(member);
        }

        public string ListAllTeamMembers()
        {
            var sb = new StringBuilder();
            int next = 1;
            foreach (var member in members)
            {
                sb.AppendLine($"{next}. {member.Name}");
                next++;
            }
            return sb.ToString();
        }

        public string ShowAllTeamBoards()
        {
            var sb = new StringBuilder();
            int next = 1;
            foreach (var board in boards)
            {
                sb.AppendLine($"Board #{next}");
                sb.AppendLine(board.ToString());
                next++;
            }
            return sb.ToString().Trim();
        }

        public override string ToString()
        {
            return this.Name.ToString();
        }
    }
}
