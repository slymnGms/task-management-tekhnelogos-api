using AutoMapper;
using task_management_tekhnelogos.Data.Interfaces;
using task_management_tekhnelogos.Data.Models;
using task_management_tekhnelogos.Services.Interfaces;
using task_management_tekhnelogos.Services.Models.DTO;
namespace task_management_tekhnelogos.Services.Providers
{
    public class UserService(IUnitOfWork unitOfWork, IAuthenticationService authService, IMapper mapper) : IUserService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IAuthenticationService _authService = authService;
        private readonly IMapper _mapper = mapper;
        public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
        {
            var user = _mapper.Map<User>(registerDto);
            user.PasswordHash = HashPassword(registerDto.Password);
            await _unitOfWork.Users.InsertAsync(user);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<UserDto>(user);
        }
        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            var user = await _unitOfWork.Users.GetByUsernameAsync(loginDto.Username);
            if (user == null || !VerifyPassword(loginDto.Password, user.PasswordHash)) return null;
            return await _authService.GenerateJwtToken(user);
        }
        private string HashPassword(string password)
        {
            // hash the password
            return password;
        }
        private bool VerifyPassword(string password, string hashedPassword)
        {
            // password verification
            return password == hashedPassword;
        }
        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }
    }
}