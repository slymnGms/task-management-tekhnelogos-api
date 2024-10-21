using Microsoft.EntityFrameworkCore;
using task_management_tekhnelogos.Data.Interfaces;
using task_management_tekhnelogos.Data.Models;

namespace task_management_tekhnelogos.Data.Refactories
{
    public class TaskRepository(ApplicationDbContext context) : Repository<TaskItem>(context), ITaskRepository
    {
        public async Task<IEnumerable<TaskItem>> GetTasksByUserIdAsync(int userId)
        {
            return await dbSet
                .Include(t => t.UserTasks)
                .Where(t => t.UserTasks.Any(ut => ut.UserId == userId))
                .ToListAsync();
        }
    }
}
