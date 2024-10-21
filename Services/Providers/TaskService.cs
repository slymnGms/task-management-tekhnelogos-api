using AutoMapper;
using task_management_tekhnelogos.Data.Interfaces;
using task_management_tekhnelogos.Data.Models;
using task_management_tekhnelogos.Services.Interfaces;
using task_management_tekhnelogos.Services.Models.DTO;
namespace task_management_tekhnelogos.Services.Providers
{
    public class TaskService(IUnitOfWork unitOfWork, IMapper mapper) : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        public async Task<TaskDto> CreateTaskAsync(TaskDto taskDto)
        {
            var task = _mapper.Map<TaskItem>(taskDto);
            await _unitOfWork.Tasks.InsertAsync(task);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<TaskDto>(task);
        }
        public async Task<IEnumerable<TaskDto>> GetTasksAsync()
        {
            var tasks = await _unitOfWork.Tasks.GetAllAsync();
            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }
        public async Task AssignTasksToUsersAsync(int[] taskIds, int[] userIds)
        {
            await _unitOfWork.UserTasks.AssignTasksToUsersAsync(taskIds, userIds);
            await _unitOfWork.SaveAsync();
        }
        public async Task<IEnumerable<UserTaskDto>> GetTasksByUserIdAsync(int userId)
        {
            var userTasks = await _unitOfWork.UserTasks.GetUserTasksByUserIdAsync(userId);
            // Console.WriteLine(userTasks);
            var tasks = userTasks.Select(ut => new UserTaskDto
            {
                TaskItemId = ut.TaskItemId,
                TaskTitle = ut.TaskItem.Title,
                TaskDescription = ut.TaskItem.Description,
                TaskDueDate = ut.TaskItem.DueDate,
                UserUsername = ut.User.Username,
                UserEmail = ut.User.Email,
            });
            return tasks;
        }
        public async Task<IEnumerable<TaskWithUsersDto>> GetTasksGroupedByUsersAsync()
        {
            var tasks = await _unitOfWork.Tasks.GetAllAsync();
            Console.WriteLine(tasks.Count());
            var userTasks = await _unitOfWork.UserTasks.GetAllAsync();
            var tasksWithUsers = tasks.Select(task => new TaskWithUsersDto
            {
                TaskId = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Users = userTasks.Where(ut => ut.TaskItemId == task.Id).Select(ut => new UserDto
                {
                    Id = ut.UserId,
                    Username = ut.User?.Username ?? string.Empty,
                }).ToList()
            });
            return tasksWithUsers;
        }
        public async Task<IEnumerable<TaskDto>> GetAttendedTasksByUserIdAsync(int userId)
        {
            var userTasks = await _unitOfWork.UserTasks.GetAttendedTasksByUserIdAsync(userId);
            var tasks = userTasks.Select(ut => ut.TaskItem).OrderBy(t => t.DueDate);
            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }
        public async Task DeleteUserTaskAsync(int userId, int taskId)
        {
            await _unitOfWork.UserTasks.DeleteUserTaskAsync(userId, taskId);
            await _unitOfWork.SaveAsync();
        }
        public async Task<IEnumerable<UserTaskDto>> GetAllAssignmentsAsync()
        {
            var userTasks = await _unitOfWork.UserTasks.GetAllAsync();
            return _mapper.Map<IEnumerable<UserTaskDto>>(userTasks);
        }
    }
}