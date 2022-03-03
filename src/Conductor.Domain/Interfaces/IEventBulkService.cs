using System.Collections.Generic;
using System.Threading.Tasks;
using Conductor.Domain.Models;

namespace Conductor.Domain.Interfaces
{
    public interface IEventBulkService
    {
        Task<bool> PublishEvents(IEnumerable<Event> events);
    }
}
