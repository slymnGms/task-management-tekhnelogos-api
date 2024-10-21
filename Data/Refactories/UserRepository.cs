using Microsoft.EntityFrameworkCore;
using task_management_tekhnelogos.Data.Interfaces;
using task_management_tekhnelogos.Data.Models;
namespace task_management_tekhnelogos.Data.Refactories
{
    public class UserRepository(ApplicationDbContext context) : Repository<User>(context), IUserRepository
    {
        public async Task<User> GetByUsernameAsync(string username)
        {
            return await dbSet.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
