using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conductor.Domain.Interfaces;
using WorkflowCore.Interface;

namespace Conductor.Domain.Services
{
    public class EventBulkService : IEventBulkService
    {
        private readonly IWorkflowController _workflowController;

        public EventBulkService(IWorkflowController workflowController)
        {
            _workflowController = workflowController;
        }

        public async Task<bool> PublishEvents(IEnumerable<Models.Event> events)
        {
            var tasks = events.Select(d => Task.Run(async () => await _workflowController.PublishEvent(d.Name, d.Key, d.Data)));
            await Task.WhenAll(tasks);
            return true;
        }
    }
}
