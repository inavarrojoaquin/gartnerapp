namespace Infrastructure.Handlers
{
    public interface IDatabaseSettingsHandler
    {
        string Name { get; }
        string ProviderName { get; }
        string ConnectionString { get; }
        string ProviderInvariantName { get; }
    }
}