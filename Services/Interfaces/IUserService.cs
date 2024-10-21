using task_management_tekhnelogos.Services.Models.DTO;
namespace task_management_tekhnelogos.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> RegisterAsync(RegisterDto userDto);
        Task<string> LoginAsync(LoginDto loginDto); 
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
    }
}