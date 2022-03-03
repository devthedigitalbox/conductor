using System.Collections.Generic;
using System.Threading.Tasks;
using WorkflowCore.Models;

namespace Conductor.Domain.Interfaces
{
    public interface IWorkflowBulkRepository
    {
        Task<IEnumerable<string>> GetAllInstanceIds(string workflowId, params WorkflowStatus[] status);
    }
}
