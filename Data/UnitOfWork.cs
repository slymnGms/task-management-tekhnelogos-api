using task_management_tekhnelogos.Data.Interfaces;
using task_management_tekhnelogos.Data.Models;
using task_management_tekhnelogos.Data.Refactories;
namespace task_management_tekhnelogos.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IUserRepository Users { get; }
        public ITaskRepository Tasks { get; }
        public IUserTaskRepository UserTasks { get; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Users = new UserRepository(context);
            Tasks = new TaskRepository(context);
            UserTasks = new UserTaskRepository(context);
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}