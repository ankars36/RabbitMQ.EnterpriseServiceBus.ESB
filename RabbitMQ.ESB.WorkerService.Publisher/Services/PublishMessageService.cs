using MassTransit;
using Microsoft.Extensions.Hosting;
using RabbitMQ.ESB.Shared.Messages;

namespace RabbitMQ.ESB.WorkerService.Publisher.Services
{
    public class PublishMessageService : BackgroundService
    {
        readonly IPublishEndpoint _publishEndpoint;

        public PublishMessageService(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int i = 0;
            while (true)
            {
                ExampleMessage message = new()
                {
                    Text = $"{++i}. mesaj"
                };

                await _publishEndpoint.Publish(message);
            }
        }
    }
}
