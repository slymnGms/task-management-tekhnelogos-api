using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using task_management_tekhnelogos.Services.Interfaces;
using task_management_tekhnelogos.Services.Models.DTO;
namespace task_management_tekhnelogos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TasksController(ITaskService taskService) : ControllerBase
    {
        private readonly ITaskService _taskService = taskService;
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskDto taskDto)
        {
            var task = await _taskService.CreateTaskAsync(taskDto);
            return Ok(task);
        }
        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await _taskService.GetTasksAsync();
            return Ok(tasks);
        }
        [HttpPost("assign")]
        public async Task<IActionResult> AssignTasksToUsers([FromBody] AssignTasksDto assignTasksDto)
        {
            try
            {
                await _taskService.AssignTasksToUsersAsync(assignTasksDto.TaskIds, assignTasksDto.UserIds);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("mytasks")]
        public async Task<IActionResult> GetMyTasks()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var tasks = await _taskService.GetTasksByUserIdAsync(userId);
            return Ok(tasks);
        }
        [HttpGet("tasks-by-users")]
        public async Task<IActionResult> GetTasksGroupedByUsers()
        {
            var tasksWithUsers = await _taskService.GetTasksGroupedByUsersAsync();
            return Ok(tasksWithUsers);
        }
        [HttpGet("attended-tasks")]
        public async Task<IActionResult> GetAttendedTasks()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var tasks = await _taskService.GetAttendedTasksByUserIdAsync(userId);
            return Ok(tasks);
        }
        [HttpGet("assignments")]
        public async Task<IActionResult> GetAllAssignments()
        {
            var assignments = await _taskService.GetAllAssignmentsAsync();
            return Ok(assignments);
        }
        [HttpDelete("assignments/{userId}/{taskId}")]
        public async Task<IActionResult> DeleteUserTaskAssignment(int userId, int taskId)
        {
            try
            {
                await _taskService.DeleteUserTaskAsync(userId, taskId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}