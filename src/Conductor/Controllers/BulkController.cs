using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BulkController : ControllerBase
    {
        private readonly IBulkService _bulkService;

        public BulkController(IBulkService workflowBulkService)
        {
            _bulkService = workflowBulkService;
        }

        [HttpPost("{id}")]
        [Authorize(Policy = Policies.Controller)]
        public async Task<IActionResult> Post(string id, [FromBody] IEnumerable<ExpandoObject> data)
        {
            var result = await _bulkService.StartWorkflows(id, data);
            return Ok(result);
        }

        [HttpPut("{id}/suspend")]
        [Authorize(Policy = Policies.Controller)]
        public async Task<IActionResult> Suspend(string id)
        {
            var result = await _bulkService.SuspendWorkflows(id);
            if (result)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut("{id}/resume")]
        [Authorize(Policy = Policies.Controller)]
        public async Task<IActionResult> Resume(string id)
        {
            var result = await _bulkService.ResumeWorkflows(id);
            if (result)
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = Policies.Controller)]
        public async Task<IActionResult> Terminate(string id)
        {
            var result = await _bulkService.TerminateWorkflows(id);
            if (result)
                return Ok();
            else
                return BadRequest();
        }


    }
}