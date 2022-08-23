// See https://aka.ms/new-console-template for more information


using Infrastructure.Starts;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Common;

try
{
    // Build a config object, using env vars and JSON providers.
    IConfiguration config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .AddEnvironmentVariables()
        .Build();

    ConnectionSettings settings = config.GetRequiredSection("ConnectionStrings").Get<ConnectionSettings>();

    DbProviderFactories.RegisterFactory("MySqlConnector", MySqlConnector.MySqlConnectorFactory.Instance);
    DbProviderFactory factory = DbProviderFactories.GetFactory(settings.ProviderName);

    DbConnection? connection = factory.CreateConnection();
    connection.ConnectionString = settings.ConnectionString;
    connection.Open();
    
    using (IDbCommand command = connection.CreateCommand())
    {
        command.CommandText = "SELECT * FROM users u";
        using (IDataReader reader = command.ExecuteReader())
        {
            Console.WriteLine("List of users from database:");
            while (reader.Read())
            {
                string firstName = reader["first_name"].ToString();
                string lastName = reader["last_name"].ToString();
                string email = reader["email"].ToString();

                Console.WriteLine("User: " + firstName + " " + lastName + "Email: " + email);
            }
            Console.WriteLine();
        }
    }
    
    IStartProgram startProgram = new StartProgram(args);
    startProgram.Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

public class ConnectionSettings
{
    public string Name { get; set; }
    public string ProviderName { get; set; }
    public string ConnectionString { get; set; }
}
