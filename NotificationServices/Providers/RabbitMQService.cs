using RabbitMQ.Client;
using System.Text;
using task_management_tekhnelogos.NotificationServices.Interfaces;

namespace task_management_tekhnelogos.NotificationServices.Providers
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMQService()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" }; // Update as needed
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(queue: "task_queue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
        }

        public void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "",
                                 routingKey: "task_queue",
                                 basicProperties: null,
                                 body: body);
        }
    }
}
