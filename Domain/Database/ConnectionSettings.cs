namespace Domain.Database
{
    public class ConnectionSettings
    {
        public string SelectedConnectionProviderName { get; set; }
        public List<ConnectionProvider> ConnectionProviders { get; set; }
    }
}
