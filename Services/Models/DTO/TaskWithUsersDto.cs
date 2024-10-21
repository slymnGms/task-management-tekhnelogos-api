namespace task_management_tekhnelogos.Services.Models.DTO
{
    public class TaskWithUsersDto
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public IEnumerable<UserDto> Users { get; set; }
    }
}