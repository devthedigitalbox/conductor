using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Conductor.Models
{
    public class BulkPostPayload
    {
        public IEnumerable<ExpandoObject> Data { get; set; }
    }
}
