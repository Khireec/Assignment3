using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDBConnectorLib
{
    public class MongoDBConnector
    {
        private readonly MongoClient _client;

        public MongoDBConnector(string connectionString)
        {
            _client = new MongoClient(connectionString);
        }

        public bool Ping()
        {
            try
            {
                var db = _client.GetDatabase("admin");
                var command = new BsonDocument("ping", 1);
                db.RunCommand<BsonDocument>(command);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}