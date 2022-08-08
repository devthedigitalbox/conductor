using System;
using Conductor.Domain.Interfaces;
using MongoDB.Driver;
using WorkflowCore.Models;
using System.Threading.Tasks;

namespace Conductor.Storage.Services
{
    public class EventsRepository : IEventsRepository
    {
        private readonly IMongoDatabase _database;

        static EventsRepository()
        {
        }

        public EventsRepository(IMongoDatabase database)
        {
            _database = database;
        }

        private IMongoCollection<Event> _collection => _database.GetCollection<Event>("Events");

        public async Task Cleanup()
        {
            // TODO: take time limit as parameter
            var oneMonthAgo = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month - 1, DateTime.UtcNow.Day, 0, 0, 0, 0, DateTimeKind.Utc);
            await _collection.DeleteManyAsync(e => e.EventTime < oneMonthAgo);
        }
    }
}