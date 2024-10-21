using task_management_tekhnelogos.Data.Models;

namespace task_management_tekhnelogos.Data.Interfaces
{
    public interface ITaskRepository : IRepository<TaskItem>
    {
        Task<IEnumerable<TaskItem>> GetTasksByUserIdAsync(int userId);
    }
}
