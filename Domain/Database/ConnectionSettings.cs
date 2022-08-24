namespace Domain.Database
{
    public class ConnectionSettings
    {
        public List<ConnectionStrings> ConnectionStrings { get; set; }
        public DatabaseFactoryConfiguration DatabaseFactoryConfiguration { get; set; }
    }
}
