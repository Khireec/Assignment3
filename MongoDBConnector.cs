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

        =
        public bool Ping()
        {
            
            throw new NotImplementedException();
        }
}