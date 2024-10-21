namespace task_management_tekhnelogos.NotificationServices.Interfaces
{
    public interface IRabbitMQService
    {
        void SendMessage(string message);
    }
}
