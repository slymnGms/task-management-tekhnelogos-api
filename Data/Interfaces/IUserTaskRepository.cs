using task_management_tekhnelogos.Data.Models;
namespace task_management_tekhnelogos.Data.Interfaces
{
    public interface IUserTaskRepository : IRepository<UserTask>
    {
        Task<IEnumerable<UserTask>> GetUserTasksByUserIdAsync(int userId);
        Task AssignTasksToUsersAsync(int[] taskIds, int[] userIds);
        Task<IEnumerable<UserTask>> GetAttendedTasksByUserIdAsync(int userId);
        Task DeleteUserTaskAsync(int userId, int taskId);
    }
}