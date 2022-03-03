using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Conductor.Auth;
using Conductor.Domain.Interfaces;
using Conductor.Domain.Models;
using Conductor.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WorkflowCore.Interface;

namespace Conductor.Controllers
{
    [Route("api/event-bulk")]
    [ApiController]
    public class EventBulkController : ControllerBase
    {
        private readonly IEventBulkService _eventBulkService;

        public EventBulkController(IEventBulkService eventBulkService)
        {
            _eventBulkService = eventBulkService;
        }

        [HttpPost]
        [Authorize(Policy = Policies.Controller)]
        public async Task<IActionResult> Post([FromBody] EventBulkPostPayload payload)
        {
            var result = await _eventBulkService.PublishEvents(payload.Events);
            if (result)
                return NoContent();
            else
                return BadRequest();
        }
    }
}