using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boyner.RabbitMQ
{
    public class MessageReceiver
    {
        private readonly RabbitMQConnection _rabbitMQConnection;

        public string Consumer(string queueName)
        {
            var connection = _rabbitMQConnection.GetRabbitMQConnection();
            var channel = connection.CreateModel();
            var data = channel.BasicGet(queueName, true);

            return Encoding.UTF8.GetString(data.Body);
        }
    }
}
