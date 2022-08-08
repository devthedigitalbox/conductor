using System.Threading.Tasks;

namespace Conductor.Domain.Interfaces
{
    public interface IEventsRepository
    {
        Task Cleanup();
    }
}
