using System.Linq;
using Conductor.Domain.Interfaces;
using Conductor.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WorkflowCore.Interface;

namespace Conductor.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureDomainServices(this IServiceCollection services)
        {
            services.AddSingleton<IDefinitionService, DefinitionService>();
            services.AddSingleton<IWorkflowLoader, WorkflowLoader>();
            services.AddSingleton<ICustomStepService, CustomStepService>();
            services.AddSingleton<IExpressionEvaluator, ExpressionEvaluator>();
            services.AddSingleton<IEventBulkService, EventBulkService>();
            services.AddSingleton<IWorkflowBulkService, WorkflowBulkService>();
            services.AddSingleton<IWorkflowController, WorkflowController>();
            services.AddTransient<CustomStep>();
            services.AddTransient<IBackgroundTask, EventConsumer>();
        }
    }
}
