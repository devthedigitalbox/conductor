﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Conductor.Auth;
using Conductor.Domain.Interfaces;
using Conductor.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WorkflowCore.Interface;

namespace Conductor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IWorkflowController _workflowController;

        public EventController(IWorkflowController workflowController)
        {
            _workflowController = workflowController;
        }

        [Authorize(Policy = Policies.Controller)]
        [HttpPost("{name}/{key}")]
        public async Task Post(string name, string key, [FromBody] object data, [FromQuery] DateTime? effectiveDate)
        {
            await _workflowController.PublishEvent(name, key, data, effectiveDate);
            Response.StatusCode = 204;
        }
    }
}