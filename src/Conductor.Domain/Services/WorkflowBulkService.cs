using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conductor.Domain.Interfaces;
using Conductor.Domain.Models;
using Microsoft.Extensions.Logging;
using SharpYaml.Serialization;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Conductor.Domain.Services
{
    public class WorkflowBulkService : IWorkflowBulkService
    {
        private readonly IWorkflowController _workflowController;
        private readonly IWorkflowBulkRepository _repository;
        private readonly ILogger _logger;

        public WorkflowBulkService(IWorkflowController workflowController, IWorkflowBulkRepository repository, ILoggerFactory loggerFactory)
        {
            _workflowController = workflowController;
            _repository = repository;
            _logger = loggerFactory.CreateLogger(GetType());
        }

        public async Task<IEnumerable<string>> StartWorkflows(string workflowId, IEnumerable<object> data = null)
        {
            var tasks = data.Select(d => Task.Run(async () => await _workflowController.StartWorkflow(workflowId, d)));
            return await Task.WhenAll(tasks);
        }

        public async Task<bool> SuspendWorkflows(string workflowId)
        {
            var instanceIds = _repository.GetAllInstanceIds(workflowId, WorkflowStatus.Runnable);
            var tasks = instanceIds.Select(id => Task.Run(async () => await _workflowController.SuspendWorkflow(id)));
            var results = await Task.WhenAll(tasks);
            return !results.Contains(false);
        }

        public async Task<bool> ResumeWorkflows(string workflowId)
        {
            var instanceIds = _repository.GetAllInstanceIds(workflowId, WorkflowStatus.Suspended);
            var tasks = instanceIds.Select(id => Task.Run(async () => await _workflowController.ResumeWorkflow(id)));
            var results = await Task.WhenAll(tasks);
            return !results.Contains(false);
        }

        public async Task<bool> TerminateWorkflows(string workflowId)
        {
            var instanceIds = _repository.GetAllInstanceIds(workflowId, WorkflowStatus.Runnable, WorkflowStatus.Suspended);
            var tasks = instanceIds.Select(id => Task.Run(async () => await _workflowController.TerminateWorkflow(id)));
            var results = await Task.WhenAll(tasks);
            return !results.Contains(false);
        }
    }
}
