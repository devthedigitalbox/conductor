using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Conductor.Models
{
    public class WorkflowBulkPostPayload
    {
        public IEnumerable<ExpandoObject> Data { get; set; }
    }
}
