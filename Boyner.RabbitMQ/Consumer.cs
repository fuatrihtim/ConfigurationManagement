using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boyner.RabbitMQ
{
    public class Consumer
    {
        private readonly RabbitMQConnection _rabbitMQService;

        //public Consumer(string queueName)
        //{
        //    _rabbitMQService = new RabbitMQConnection();

        //    using (var connection = _rabbitMQService.GetRabbitMQConnection())
        //    {
        //        using (var channel = connection.CreateModel())
        //        {
        //            var consumer = new EventingBasicConsumer(channel);
        //            consumer.Received += (model, ea) =>
        //            {
        //                var body = ea.Body;
        //                var message = Encoding.UTF8.GetString(body);

        //            };

        //            channel.BasicConsume(queueName, true, consumer);
        //        }
        //    }
        //}

        public string Consume(string queueName)
        {
            var connection = _rabbitMQService.GetRabbitMQConnection();
            var channel = connection.CreateModel();
            var data = channel.BasicGet(queueName, true);

            return Encoding.UTF8.GetString(data.Body);
        }
    }
}
