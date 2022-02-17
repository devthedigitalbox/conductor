using System.Collections.Generic;
using WorkflowCore.Models;

namespace Conductor.Domain.Interfaces
{
    public interface IBulkRepository
    {
        IEnumerable<string> GetAllInstanceIds(string workflowId, params WorkflowStatus[] status);
    }
}
