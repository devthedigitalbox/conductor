using System.Collections.Generic;
using WorkflowCore.Models;

namespace Conductor.Domain.Interfaces
{
    public interface IWorkflowBulkRepository
    {
        IEnumerable<string> GetAllInstanceIds(string workflowId, params WorkflowStatus[] status);
    }
}
