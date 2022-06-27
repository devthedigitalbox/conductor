using System.Threading.Tasks;
using Conductor.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Quartz;
using WorkflowCore.Interface;

namespace Conductor.Domain.Services
{
    public class TerminateDanglingSubscriptionsJob: IJob
    {
        private readonly ISubscriptionsRepository _repository;
        private readonly ILogger _logger;

        public TerminateDanglingSubscriptionsJob(ISubscriptionsRepository repository, ILoggerFactory loggerFactory)
        {
            _repository = repository;
            _logger = loggerFactory.CreateLogger(GetType());
        }
        
        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Terminating Dangling Subscriptions");
            return _repository.TerminateDanglingSubscriptions();
        }
    }
}