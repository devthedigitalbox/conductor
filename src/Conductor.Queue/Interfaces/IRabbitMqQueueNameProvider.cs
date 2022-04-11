using WorkflowCore.Interface;

namespace Conductor.Queue.Interfaces
{
    public interface IRabbitMqQueueNameProvider
    {
        string GetQueueName(QueueType queue);
    }
}