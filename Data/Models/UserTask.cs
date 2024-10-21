namespace task_management_tekhnelogos.Data.Models
{
    public class UserTask
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int TaskItemId { get; set; }
        public TaskItem TaskItem { get; set; }
        public bool IsAttended { get; set; }
    }
}