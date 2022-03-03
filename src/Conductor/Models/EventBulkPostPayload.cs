using System.Collections.Generic;
using Conductor.Domain.Models;

namespace Conductor.Models
{
    public class EventBulkPostPayload
    {
        public IEnumerable<Event> Events { get; set; }
    }
}
