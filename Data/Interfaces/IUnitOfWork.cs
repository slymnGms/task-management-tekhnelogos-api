using task_management_tekhnelogos.Data.Models;
namespace task_management_tekhnelogos.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ITaskRepository Tasks { get; }
        IUserTaskRepository UserTasks { get; }
        Task SaveAsync();
    }
}