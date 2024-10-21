using task_management_tekhnelogos.Data.Models;

namespace task_management_tekhnelogos.Data.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByUsernameAsync(string username);
    }
}
