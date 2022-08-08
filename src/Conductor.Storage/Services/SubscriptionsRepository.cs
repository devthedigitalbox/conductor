using System.Linq;
using Conductor.Domain.Interfaces;
using Conductor.Storage.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using WorkflowCore.Models;
using System.Threading.Tasks;

namespace Conductor.Storage.Services
{
    public class SubscriptionsRepository : ISubscriptionsRepository
    {
        private readonly IMongoDatabase _database;

        private IMongoCollection<EventSubscription> _collection => _database.GetCollection<EventSubscription>("Subscriptions");

        static SubscriptionsRepository() { }

        public SubscriptionsRepository(IMongoDatabase database)
        {
            _database = database;
        }
        
        public async Task TerminateOrphans()
        {
            var pipeline = new[]
            {
                new BsonDocument("$lookup",
                    new BsonDocument
                    {
                        {"from", "Workflows"},
                        {"localField", "WorkflowId"},
                        {"foreignField", "_id"},
                        {"as", "Workflow"}
                    }),
                new BsonDocument("$match",
                    new BsonDocument("Workflow.0.Status",
                        new BsonDocument("$in",
                            new BsonArray
                            {
                                2,
                                3
                            }))),
                new BsonDocument("$group",
                    new BsonDocument
                    {
                        {"_id", BsonNull.Value},
                        {
                            "DanglingSubscriptions",
                            new BsonDocument("$push", "$_id")
                        }
                    }),
                new BsonDocument("$project",
                    new BsonDocument
                    {
                        {"DanglingSubscriptions", true},
                        {"_id", false}
                    })
            };

            var aggregation = await _collection.Aggregate<DanglingSubscriptionsAggregation>(pipeline)
                .FirstOrDefaultAsync();
            if (aggregation != default)
            {
                await _collection.DeleteManyAsync(x => aggregation.DanglingSubscriptions.Contains(x.Id));
            }
        }
    }
}
