using System.Collections.Generic;
using System.Threading.Tasks;
using WorkflowCore.Models;

namespace Conductor.Domain.Interfaces
{
    public interface ISubscriptionsRepository
    {
        Task TerminateDanglingSubscriptions();
    }
}
