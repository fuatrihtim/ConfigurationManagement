using Boyner.RabbitMQ;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Boyner.ServiceB
{
    internal class ScheduledTask : IHostedService
    {
        private Timer _timer;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(CheckQueueForConfig, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        private void CheckQueueForConfig(object state)
        {
            Consumer consumer = new Consumer();
            consumer.Consume("ServiceB");
        }
    }
}
