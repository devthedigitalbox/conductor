using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conductor.Domain.Interfaces;
using Microsoft.Extensions.Logging;
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

        public async Task<bool> StartWorkflows(string workflowId, IEnumerable<object> data)
        {
            foreach (var item in data)
                await _workflowController.StartWorkflow(workflowId, item);
            return true;
        }

        public async Task<bool> SuspendWorkflows(string workflowId)
        {
            var instanceIds = await _repository.GetAllInstanceIds(workflowId, WorkflowStatus.Runnable);
            foreach (var id in instanceIds)
                await _workflowController.SuspendWorkflow(id);
            return true;
        }

        public async Task<bool> ResumeWorkflows(string workflowId)
        {
            var instanceIds = await _repository.GetAllInstanceIds(workflowId, WorkflowStatus.Suspended);
            foreach (var id in instanceIds)
                await _workflowController.ResumeWorkflow(id);
            return true;
        }

        public async Task<bool> TerminateWorkflows(string workflowId)
        {
            var instanceIds = await _repository.GetAllInstanceIds(workflowId, WorkflowStatus.Runnable, WorkflowStatus.Suspended);
            foreach (var id in instanceIds)
                await _workflowController.TerminateWorkflow(id);
            return true;
        }
    }
}
