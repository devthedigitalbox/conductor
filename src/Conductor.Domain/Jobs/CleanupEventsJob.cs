using System.Threading.Tasks;
using Conductor.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Quartz;

namespace Conductor.Domain.Services
{
    public class CleanupEventsJob: IJob
    {
        private readonly IEventsRepository _repository;
        private readonly ILogger _logger;

        public CleanupEventsJob(IEventsRepository repository, ILoggerFactory loggerFactory)
        {
            _repository = repository;
            _logger = loggerFactory.CreateLogger(GetType());
        }
        
        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Cleanup Events");
            return _repository.Cleanup();
        }
    }
}