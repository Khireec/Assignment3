using Xunit;
using MongoDBConnectorLib;
using Testcontainers.MongoDb;
using System.Threading.Tasks;

namespace MongoDBConnectorLib.Tests
{
    public class MongoDBConnectorTests : IAsyncLifetime
    {
        private readonly MongoDbContainer _mongoDbContainer;

        public MongoDBConnectorTests()
        {
            _mongoDbContainer = new MongoDbBuilder().Build();
        }

        public async Task InitializeAsync() => await _mongoDbContainer.StartAsync();

        public async Task DisposeAsync() => await _mongoDbContainer.DisposeAsync();

        [Fact]
        public void Ping_ShouldReturnTrue_WhenMongoDBIsRunning()
        {
            var connector = new MongoDBConnector(_mongoDbContainer.GetConnectionString());
            Assert.True(connector.Ping());
        }

        [Fact]
        public void Ping_ShouldReturnFalse_WhenMongoDBIsInvalid()
        {
            var connector = new MongoDBConnector("mongodb://invalid:27017");
            Assert.False(connector.Ping());
        }

        [Fact]
        public void Ping_ShouldReturnFalse_WhenMongoIsNotRunning()
        {

            var wrongConnectionString = "mongodb://localhost:12345";


            var connector = new MongoDBConnector(wrongConnectionString);


            var result = connector.Ping();


            Assert.False(result);
        }
    }
}
