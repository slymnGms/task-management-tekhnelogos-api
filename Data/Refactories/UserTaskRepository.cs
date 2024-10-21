using Microsoft.EntityFrameworkCore;
using task_management_tekhnelogos.Data.Interfaces;
using task_management_tekhnelogos.Data.Models;
namespace task_management_tekhnelogos.Data.Refactories
{
    public class UserTaskRepository(ApplicationDbContext context) : Repository<UserTask>(context), IUserTaskRepository
    {
        public async Task<IEnumerable<UserTask>> GetUserTasksByUserIdAsync(int userId)
        {
            return await dbSet
                .Include(ut => ut.TaskItem)
                .Include(ut => ut.User)
                .Where(ut => ut.UserId == userId)
                .ToListAsync();
        }
        public async Task AssignTasksToUsersAsync(int[] taskIds, int[] userIds)
        {
            foreach (var userId in userIds)
            {
                foreach (var taskId in taskIds)
                {
                    var userTask = new UserTask
                    {
                        UserId = userId,
                        TaskItemId = taskId,
                        IsAttended = true
                    };
                    await dbSet.AddAsync(userTask);
                }
            }
        }
        public async Task<IEnumerable<UserTask>> GetAttendedTasksByUserIdAsync(int userId)
        {
            return await dbSet
                .Include(ut => ut.TaskItem)
                .Where(ut => ut.UserId == userId && ut.IsAttended && ut.TaskItem.DueDate.Date == DateTime.Now.Date)
                .ToListAsync();
        }
        public async Task DeleteUserTaskAsync(int userId, int taskId)
        {
            var userTask = await dbSet.SingleOrDefaultAsync(ut => ut.UserId == userId && ut.TaskItemId == taskId);
            if (userTask != null)
            {
                dbSet.Remove(userTask);
            }
        }
    }
}