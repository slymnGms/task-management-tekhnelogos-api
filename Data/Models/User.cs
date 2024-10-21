﻿namespace task_management_tekhnelogos.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<UserTask> UserTasks { get; set; }
    }
}