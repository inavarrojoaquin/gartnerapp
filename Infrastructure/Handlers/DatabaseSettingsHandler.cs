using Domain.Database;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Handlers
{
    public class DatabaseSettingsHandler
    {
        public string SelectedConnectionProviderName { get; }
        public List<ConnectionProvider> ConnectionProviders { get; }

        public DatabaseSettingsHandler(IConfiguration config)
        {
            if(config == null)
                throw new ArgumentNullException("Error: Config is null.");

            ConnectionSettings connectionSettings = config.GetRequiredSection("ConnectionSettings")
                .Get<ConnectionSettings>();

            SelectedConnectionProviderName = connectionSettings.SelectedConnectionProviderName;
            ConnectionProviders = connectionSettings.ConnectionProviders;
        }
    }
}
