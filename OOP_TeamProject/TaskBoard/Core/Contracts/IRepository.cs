using TasksBoard.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskBoard.Models;
using TasksBoard.Models.Contracts;

//using Task = TaskBoard.Models.Task;

namespace TasksBoard.Core.Contracts
{
    public interface IRepository
    {
        List<ITeam> Teams { get; }
        List<IMember> Members { get; }
        IList<ITask> Tasks { get; }
        public IMember CreateMember(string name);
        public IMember GetMember(string name);
        public ITeam CreateTeam(string name);
        public void AddTeam(ITeam team);
        public ITeam GetTeam(string name);
        public bool TeamExist(string name);
        public void AddMember(IMember member);
        public bool MemberExist(string name);
        public IBoard CreateBoard(string name);
        public IBoard GetBoard(string boardName, string teamName);
        public IBug CreateBug(string title, string description, Priority priority, Severity severity);
        public IStory CreateStory(string title, string description, Priority priority, Size size);
        public IFeedback CreateFeedback(string title, string description, int rating);
        public void AddTask(ITask task);
        public bool TaskExist(int id);
        public bool TaskExist(string taskTitle);
        public IBug GetBug(string title);
        public IBug GetBug(int id);
        public IStory GetStory(string title);
        public IStory GetStory(int id);
        public IFeedback GetFeedback(string title);
        public IFeedback GetFeedback(int id);
        public IComment CreateComment(string content, string author);
        public ITask GetTask(int id);
        public ITask GetTask(string name);

        public string ShowAllPeople();

        public string ShowAllTeams();
    }
}
