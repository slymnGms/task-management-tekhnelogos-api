using task_management_tekhnelogos.Data.Models;

namespace task_management_tekhnelogos.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> GenerateJwtToken(User user);
        Task<User> Authenticate(string username, string password);
    }
}
