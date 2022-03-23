using System;
using System.Dynamic;

namespace Conductor.Domain.Models
{
    public class Event
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public ExpandoObject Data { get; set; }
        public DateTime? EffectiveDate { get; set; }
    }
}
