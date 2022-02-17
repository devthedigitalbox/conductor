using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conductor.Domain.Interfaces
{
    public interface IBulkService
    {
        Task<IEnumerable<string>> StartWorkflows(string workflowId, IEnumerable<object> data = null);
        Task<bool> SuspendWorkflows(string workflowId);
        Task<bool> ResumeWorkflows(string workflowId);
        Task<bool> TerminateWorkflows(string workflowId);
    }
}
