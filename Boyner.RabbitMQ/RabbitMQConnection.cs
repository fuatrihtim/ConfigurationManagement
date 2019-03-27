using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boyner.RabbitMQ
{
    public class RabbitMQConnection
    {
        private readonly string _hostname = "localhost";

        public IConnection GetRabbitMQConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory()
            {
                HostName = _hostname
            };

            return connectionFactory.CreateConnection();
        }
    }
}
