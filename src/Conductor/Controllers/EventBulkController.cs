using System.Threading.Tasks;
using Conductor.Auth;
using Conductor.Domain.Interfaces;
using Conductor.Models;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Conductor.Controllers
{
    [Route("api/event-bulk")]
    [ApiController]
    public class EventBulkController : ControllerBase
    {
        private readonly IEventBulkService _eventBulkService;
        private readonly IPublishEndpoint _publishEndpoint;

        public EventBulkController(IEventBulkService eventBulkService, IPublishEndpoint publishEndpoint = null)
        {
            _eventBulkService = eventBulkService;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        [Authorize(Policy = Policies.Controller)]
        public async Task<IActionResult> Post([FromBody] EventBulkPostPayload payload)
        {
            if (string.IsNullOrEmpty(EnvironmentVariables.RabbitMQ))
            {
                var result = await _eventBulkService.PublishEvents(payload.Events);
                if (!result)
                    return BadRequest();
            }
            else
            {
                await _publishEndpoint.Publish(payload);
            }

            return NoContent();
        }
    }
}