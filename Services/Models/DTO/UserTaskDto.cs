namespace task_management_tekhnelogos.Services.Models.DTO
{
    public class UserTaskDto
    {
        public int Id { get; set; }
        public int TaskItemId { get; set; }
        public int UserId { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public DateTime TaskDueDate { get; set; }
        public string UserUsername { get; set; }
        public string UserEmail { get; set; }
    }
}