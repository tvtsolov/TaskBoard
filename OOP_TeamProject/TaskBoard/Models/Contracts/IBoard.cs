using TaskBoard.Models;

namespace TasksBoard.Models.Contracts
{
    public interface IBoard : IHasTasks, IHasLog
    {
        string Name { get; }
    }
}