using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boyner.RabbitMQ
{
    public class Publisher
    {
        private readonly RabbitMQConnection _rabbitMQConnection;

        public Publisher(string queueName, string message)
        {
            _rabbitMQConnection = new RabbitMQConnection();

            using (var connection = _rabbitMQConnection.GetRabbitMQConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queueName, false, false, false, null);

                    channel.BasicPublish("", queueName, null, Encoding.UTF8.GetBytes(message));
                }
            }
        }
    }
}
