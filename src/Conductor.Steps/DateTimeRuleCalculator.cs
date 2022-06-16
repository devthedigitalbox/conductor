using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Conductor.Steps
{
    public class DateTimeRuleCalculator : StepBodyAsync
    {
        public string DaysOfWeek { get; set; } = string.Join(",", new {
            DayOfWeek.Sunday,
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday
        });
        public TimeSpan TimeRangeStart { get; set; } = new TimeSpan(0, 0, 0);
        public TimeSpan TimeRangeEnd { get; set; } =  new TimeSpan(24, 0, 0);

        public string Result { get; set; }

        public override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            var daysOfWeek = DaysOfWeek.Split(',').Select(int.Parse).Cast<DayOfWeek>();
            if (MatchRule(daysOfWeek, TimeRangeStart, TimeRangeEnd))
            {
                Result = new TimeSpan(0, 0, 0, 0).ToString();
            }
            else
            {
                var closestDateTime = FindClosestDateTime(daysOfWeek, TimeRangeStart);
                Result = (closestDateTime - DateTime.UtcNow).ToString();
            }
            
            return Task.FromResult(ExecutionResult.Next());
        }

        private bool MatchRule(IEnumerable<DayOfWeek> daysOfWeek, TimeSpan timeRangeStart, TimeSpan timeRangeEnd)
        {
            return daysOfWeek.Contains(DateTime.UtcNow.DayOfWeek)
                   && timeRangeStart <= DateTime.UtcNow.TimeOfDay
                   && timeRangeEnd >= DateTime.UtcNow.TimeOfDay;
        }

        private DateTime FindClosestDateTime(IEnumerable<DayOfWeek> daysOfWeek, TimeSpan timeRangeStart)
        {
            return daysOfWeek.SelectMany(d => new List<int>() {d - DateTime.UtcNow.DayOfWeek, d - DateTime.UtcNow.DayOfWeek + 7})
                .Select(d => new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, timeRangeStart.Hours,
                    timeRangeStart.Minutes, timeRangeStart.Seconds, DateTimeKind.Utc).AddDays(d))
                .Where(d => d >= DateTime.UtcNow)
                .Min();
        }
    }
}