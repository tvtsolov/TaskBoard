using Program.Models;
using System.Text;
using System.Xml.Linq;
using TaskBoard.Models;
using TasksBoard.Core.Contracts;
using TasksBoard.Models;
using TasksBoard.Models.Contracts;
using TasksBoard.Models.Enums;
using TasksBoard.TaskBoard.Exceptions;

namespace TasksBoard.Core
{
    public class Repository : IRepository
    {
        private readonly List<ITeam> teams = new List<ITeam>();
        private readonly List<IMember> members = new List<IMember>();
        private readonly IList<ITask> tasks = new List<ITask>();

        public List<ITeam> Teams
        {
            get => new List<ITeam>(teams);
        }

        public List<IMember> Members
        {
            get => new List<IMember>(members);
        }

        public IList<ITask> Tasks
        {
            get => new List<ITask>(tasks);
        }

        public void AddTask(ITask task)
        {
            tasks.Add(task);
        }

        public void AddMember(IMember member)
        {
            members.Add(member);
        }

        public void AddTeam(ITeam team)
        {
            teams.Add(team);
        }

        public IMember CreateMember(string name)
        {
            IMember member = new Member(name);
            AddMember(member);
            return member;
        }
        public IBoard CreateBoard(string name)
        {
            IBoard board = new Board(name);
            return board;
        }

        public IBug CreateBug(string title, string description, Priority priority, Severity severity)
        {
            IBug bug =  new Bug(title, description, priority, severity);
            AddTask(bug);
            return bug;
        }

        public IFeedback CreateFeedback(string title, string description, int rating)
        {
            IFeedback feedback = new Feedback(title, description, rating);
            AddTask(feedback);
            return feedback;
        }

        public IStory CreateStory(string title, string description, Priority priority, Size size)
        {
            IStory story = new Story(title, description, priority, size);
            AddTask(story);
            return story;
        }

        public IComment CreateComment(string content, string author)
        {
            return new Comment(content, author);
        }

        public ITeam CreateTeam(string name)
        {
            if (TeamExist(name))
                throw new InvalidUserInputException($"A team with name {name} already exists");
            ITeam team = new Team(name);
            AddTeam(team);
            return team;
        }

        public ITask GetTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
                return task;

            throw new EntityNotFoundException($"There is no task with ID: {id}!");
        }
        public ITask GetTask(string title) 
        {
            var task = tasks.FirstOrDefault(t => t.Title == title);
            if (task != null)
                return task;

            throw new EntityNotFoundException($"There is no task with Title: {title}!");
        }

        public IStory GetStory(string title)
        {
            var story = tasks.FirstOrDefault(task => task.Title.Equals(title, StringComparison.InvariantCultureIgnoreCase) && task is IStory) as IStory;
            if (story != null)
                return story;

            throw new EntityNotFoundException($"There is no story with name {title}!");
        }
        public IStory GetStory(int id)
        {
            var story = tasks.FirstOrDefault(task => task.Id.Equals(id) && task is Story) as Story;
            if (story != null)
                return story;
            throw new EntityNotFoundException($"There is no story with ID {id}!");
        }
        public IBug GetBug(string title)
        {
            var bug = tasks.FirstOrDefault(task => task.Title.Equals(title, StringComparison.InvariantCultureIgnoreCase) && task is IBug) as IBug;
            if (bug != null) 
                return bug;
            throw new EntityNotFoundException($"There is no bug with title {title}!");
        }
        public IBug GetBug(int id)
        {
            var bug = tasks.FirstOrDefault(task => task.Id.Equals(id) && task is IBug) as IBug;
            if (bug != null) 
                return bug;
            throw new EntityNotFoundException($"There is no bug with title {id}!");
        }

        public IFeedback GetFeedback(string title)
        {
            var feedback = tasks.FirstOrDefault(task => task.Title.Equals(title) && task is IFeedback) as IFeedback;
            if (feedback != null)
                return feedback;
            throw new EntityNotFoundException($"There is no feedback with title {title}!");
        }

        public IFeedback GetFeedback(int id)
        {
            var feedback = tasks.FirstOrDefault(task => task.Id.Equals(id) && task is IFeedback) as IFeedback;
            if (feedback != null)
                return feedback;
            throw new EntityNotFoundException($"There is no feedback with title {id}!");
        }
        public IMember GetMember(string name)
        {
            var member = members.FirstOrDefault(member => member.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
            if (member != null)
                return member;
            
            throw new EntityNotFoundException($"There is no member with name {name}!");
        }


        public ITeam GetTeam(string name)
        {
            var team = teams.FirstOrDefault(team =>  team.Name.Equals(name,StringComparison.InvariantCultureIgnoreCase));
            if (team != null) 
                return team;

            throw new EntityNotFoundException($"There is no team with name {name}!");
        }

        public bool TaskExist(int id) 
        {
            return tasks.Any(task => task.Id == id); 
        }

        public bool TaskExist(string taskTitle) 
        {
            return tasks.Any(task => task.Title == taskTitle);
        }

        public bool MemberExist(string name)
        {
            return members.Any(member => member.Name == name);
        }

        public bool TeamExist(string name)
        {
            return teams.Any(team => team.Name == name);
        }

        public string ShowAllPeople()
        {
            StringBuilder sb = new StringBuilder();
            members.ForEach(member => sb.AppendLine(member.ToString()));
            return sb.ToString();
        }

        public string ShowAllTeams()
        {
            StringBuilder sb = new StringBuilder();
            teams.ForEach(team => sb.AppendLine(team.ToString()));
            return sb.ToString();
        }

        public IBoard GetBoard(string boardName, string teamName)
        {
            var team = GetTeam(teamName);
            var board = team.Boards.FirstOrDefault(board => board.Name == boardName);   
            if (board != null) 
                return board;
            
            throw new EntityNotFoundException($"There is no board with name {boardName} in team {team.Name}!");
        }
    }
}
