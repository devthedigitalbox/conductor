using System.Threading.Tasks;
using Conductor.Domain.Interfaces;
using Conductor.Models;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Conductor.Consumers
{
    public class PublishEventsCommandConsumer :
        IConsumer<EventBulkPostPayload>
    {
        private readonly IEventBulkService _eventBulkService;
        private readonly ILogger<PublishEventsCommandConsumer> _logger;

        public PublishEventsCommandConsumer(IEventBulkService eventBulkService, ILogger<PublishEventsCommandConsumer> logger)
        {
            _eventBulkService = eventBulkService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<EventBulkPostPayload> context)
        {
            _logger.LogInformation("Value: {Value}", context.Message);
            var result = await _eventBulkService.PublishEvents(context.Message.Events);
            if(!result)
                _logger.LogError("Error: {Value}", context.Message);
        }
    }
}