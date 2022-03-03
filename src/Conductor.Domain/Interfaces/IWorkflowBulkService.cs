using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conductor.Domain.Interfaces
{
    public interface IWorkflowBulkService
    {
        Task<bool> StartWorkflows(string workflowId, IEnumerable<object> data);
        Task<bool> SuspendWorkflows(string workflowId);
        Task<bool> ResumeWorkflows(string workflowId);
        Task<bool> TerminateWorkflows(string workflowId);
    }
}
