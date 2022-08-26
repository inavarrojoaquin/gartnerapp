using Infrastructure.Handlers;
using System.Data;
using System.Data.Common;

namespace Infrastructure.Persistance
{
    public class Database
    {
        private readonly IDatabaseSettingsHandler databaseHandler;

        public Database(IDatabaseSettingsHandler databaseHandler)
        {
            DbProviderFactories.RegisterFactory(
                databaseHandler.ProviderInvariantName,
                MySqlConnector.MySqlConnectorFactory.Instance);
            
            this.databaseHandler = databaseHandler;
        }
        public IDbConnection CreateOpenConnection()
        {
            var factory = DbProviderFactories.GetFactory(databaseHandler.ProviderName);
            var connection = factory.CreateConnection();
            connection.ConnectionString = databaseHandler.ConnectionString;
            connection.Open();

            return connection;
        }
    }
}
