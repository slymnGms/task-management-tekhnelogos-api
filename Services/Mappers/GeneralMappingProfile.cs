using AutoMapper;
using task_management_tekhnelogos.Data.Models;
using task_management_tekhnelogos.Services.Models.DTO;

namespace task_management_tekhnelogos.Services.Mappers
{
    public class GeneralMappingProfile : Profile
    {
        public GeneralMappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<TaskItem, TaskDto>().ReverseMap();
            CreateMap<UserTask, UserTaskDto>();
        }
    }
}
