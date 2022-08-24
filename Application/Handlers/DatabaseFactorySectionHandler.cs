using Domain.Database;
using Microsoft.Extensions.Configuration;

namespace Application.Handlers
{
    public class DatabaseFactorySectionHandler : IDatabaseFactorySectionHandler
    {
        private static ConnectionSettings connectionSettings;

        public DatabaseFactorySectionHandler(IConfiguration config)
        {
            connectionSettings = config.GetRequiredSection("ConnectionSettings")
                .Get<ConnectionSettings>();
        }
        
        public static string Name
        {
            get { return connectionSettings.DatabaseFactoryConfiguration.Name; }
        }

        public static string ConnectionStringName
        {
            get { return connectionSettings.DatabaseFactoryConfiguration.ConnectionStringName; }
        }

        public static string ConnectionString
        {
            get
            {
                try
                {
                    return connectionSettings
                            .ConnectionStrings
                            .FirstOrDefault(x => x.Name == ConnectionStringName)
                            .ConnectionString;
                }
                catch (Exception excep)
                {
                    throw new Exception("Connection string " + ConnectionStringName + " was not found in appsettings.json. " + excep.Message);
                }
            }
        }
    }
}
