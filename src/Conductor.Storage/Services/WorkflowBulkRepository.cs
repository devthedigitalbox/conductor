using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conductor.Domain.Interfaces;
using Conductor.Domain.Models;
using Conductor.Storage.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using WorkflowCore.Models;
using System.Threading.Tasks;

namespace Conductor.Storage.Services
{
    public class WorkflowBulkRepository : IWorkflowBulkRepository
    {
        private readonly IMongoDatabase _database;

        private IMongoCollection<WorkflowInstance> _collection => _database.GetCollection<WorkflowInstance>("Workflows");

        static WorkflowBulkRepository() { }

        public WorkflowBulkRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public IEnumerable<string> GetAllInstanceIds(string workflowId, params WorkflowStatus[] status)
        {
            var filterDefinition = Builders<WorkflowInstance>.Filter.Eq(w => w.WorkflowDefinitionId, workflowId);
            if(status != default && status.Any())
            {
                filterDefinition &= Builders<WorkflowInstance>.Filter.Or(
                    status.Select(s => Builders<WorkflowInstance>.Filter.Eq(w => w.Status, s))
                );
            }

            var results = _collection.Find(filterDefinition).Project(w => w.Id);
            return results.ToList();
        }
    }
}
