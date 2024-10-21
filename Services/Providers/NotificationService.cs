using task_management_tekhnelogos.Data.Interfaces;

namespace task_management_tekhnelogos.Services.Providers
{
    public class NotificationService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public NotificationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                    var upcomingTasks = (await unitOfWork.Tasks.GetAllAsync())
                        .Where(t => t.DueDate <= DateTime.Now.AddMinutes(30)); // Adjust as needed

                    foreach (var task in upcomingTasks)
                    {
                        // Logic to send notifications to users
                        // This could be email, SMS, push notification, etc.
                    }
                }

                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }
        }
    }
}
