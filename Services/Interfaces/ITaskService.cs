using task_management_tekhnelogos.Services.Models.DTO;
namespace task_management_tekhnelogos.Services.Interfaces
{
    public interface ITaskService
    {
        Task<TaskDto> CreateTaskAsync(TaskDto taskDto);
        Task<IEnumerable<TaskDto>> GetTasksAsync();
        Task<IEnumerable<UserTaskDto>> GetAllAssignmentsAsync();
        Task AssignTasksToUsersAsync(int[] taskIds, int[] userIds);
        Task DeleteUserTaskAsync(int userId, int taskId);
        Task<IEnumerable<UserTaskDto>> GetTasksByUserIdAsync(int userId);
        Task<IEnumerable<TaskWithUsersDto>> GetTasksGroupedByUsersAsync();
        Task<IEnumerable<TaskDto>> GetAttendedTasksByUserIdAsync(int userId);
    }
}