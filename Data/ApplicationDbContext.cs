using Microsoft.EntityFrameworkCore;
using task_management_tekhnelogos.Data.Models;

namespace task_management_tekhnelogos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTask>()
                .HasKey(ut => new { ut.UserId, ut.TaskItemId });

            modelBuilder.Entity<UserTask>()
                .HasOne(ut => ut.User)
                .WithMany(u => u.UserTasks)
                .HasForeignKey(ut => ut.UserId);

            modelBuilder.Entity<UserTask>()
                .HasOne(ut => ut.TaskItem)
                .WithMany(t => t.UserTasks)
                .HasForeignKey(ut => ut.TaskItemId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
