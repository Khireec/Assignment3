using Xunit;
using MongoDBConnectorLib;

namespace MongoDBConnectorLib.Tests
{
    public class PostgresConnectorTests
    {
        [Fact]
        public void Ping_ShouldReturnTrue_WhenConnectionIsValid()
        {
            // Replace with a valid connection string to your local or test PostgreSQL
            var connectionString = "Host=localhost;Username=postgres;Password=yourpassword;Database=postgres";

            var connector = new PostgresConnector(connectionString);

            var result = connector.Ping();

            Assert.True(result);
        }

        [Fact]
        public void Ping_ShouldReturnFalse_WhenConnectionIsInvalid()
        {
            // Intentionally bad connection string
            var badConnectionString = "Host=invalid;Username=bad;Password=bad;Database=none";

            var connector = new PostgresConnector(badConnectionString);

            var result = connector.Ping();

            Assert.False(result);
        }
    }
}
