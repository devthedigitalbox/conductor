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
    [Route("api/workflow-bulk")]
    [ApiController]
    [Authorize]
    public class WorkflowBulkController : ControllerBase
    {
        private readonly IWorkflowBulkService _bulkService;

        public WorkflowBulkController(IWorkflowBulkService workflowBulkService)
        {
            _bulkService = workflowBulkService;
        }

        [HttpPost("{id}")]
        [Authorize(Policy = Policies.Controller)]
        public async Task<IActionResult> Post(string id, [FromBody] WorkflowBulkPostPayload payload)
        {
            if (payload?.Data?.Any() != true)
                return BadRequest();

            var result = await _bulkService.StartWorkflows(id, payload.Data);
            if (result)
                return NoContent();
            else
                return BadRequest();
        }

        [HttpPut("{id}/suspend")]
        [Authorize(Policy = Policies.Controller)]
        public async Task<IActionResult> Suspend(string id)
        {
            var result = await _bulkService.SuspendWorkflows(id);
            if (result)
                return NoContent();
            else
                return BadRequest();
        }

        [HttpPut("{id}/resume")]
        [Authorize(Policy = Policies.Controller)]
        public async Task<IActionResult> Resume(string id)
        {
            var result = await _bulkService.ResumeWorkflows(id);
            if (result)
                return NoContent();
            else
                return BadRequest();
        }

        [HttpPut("{id}/terminate")]
        [Authorize(Policy = Policies.Controller)]
        public async Task<IActionResult> Terminate(string id)
        {
            var result = await _bulkService.TerminateWorkflows(id);
            if (result)
                return NoContent();
            else
                return BadRequest();
        }


    }
}