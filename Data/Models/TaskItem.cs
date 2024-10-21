namespace task_management_tekhnelogos.Data.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public ICollection<UserTask> UserTasks { get; set; }
    }
}
