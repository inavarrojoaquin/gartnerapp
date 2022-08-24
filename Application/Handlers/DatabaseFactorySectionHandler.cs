using Domain.Database;
using Microsoft.Extensions.Configuration;

namespace Application.Handlers
{
    public sealed class DatabaseFactorySectionHandler
    {
        private static ConnectionSettings connectionSettings;

        public static void Create(IConfiguration config)
        {
            if (config == null)
                return;

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
