using Domain.Database;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Handlers
{
    public class DatabaseSettingsHandler : IDatabaseSettingsHandler
    {
        public string Name { get; }
        public string ProviderName { get; }
        public string ConnectionString { get; }
        public string ProviderInvariantName { get; }

        public DatabaseSettingsHandler(IConfiguration config)
        {
            ConnectionSetting connectionSetting = config.GetRequiredSection("ConnectionSetting")
                .Get<ConnectionSetting>();

            Name = connectionSetting.Name;
            ProviderName = connectionSetting.ProviderName;
            ConnectionString = connectionSetting.ConnectionString;
            ProviderInvariantName = connectionSetting.ProviderInvariantName;
        }
    }
}
