// See https://aka.ms/new-console-template for more information


using Infrastructure.Starts;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Reflection;

try
{
    // Build a config object, using env vars and JSON providers.
    IConfiguration config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .AddEnvironmentVariables()
        .Build();

    DatabaseFactorySectionHandler.Create(config);

    UsersManager.GetUsers();

    //ConnectionSettings settings = config.GetRequiredSection("ConnectionSettings").Get<ConnectionSettings>();

    //DbProviderFactories.RegisterFactory("MySqlConnector", MySqlConnector.MySqlConnectorFactory.Instance);
    //DbProviderFactory factory = DbProviderFactories.GetFactory(settings.ConnectionStrings.FirstOrDefault().ProviderName);

    //DbConnection? connection = factory.CreateConnection();
    //connection.ConnectionString = settings.ConnectionStrings.FirstOrDefault().ConnectionString;
    //connection.Open();

    //using (IDbCommand command = connection.CreateCommand())
    //{
    //    command.CommandText = "SELECT * FROM users u";
    //    using (IDataReader reader = command.ExecuteReader())
    //    {
    //        Console.WriteLine("List of users from database:");
    //        while (reader.Read())
    //        {
    //            string firstName = reader["first_name"].ToString();
    //            string lastName = reader["last_name"].ToString();
    //            string email = reader["email"].ToString();

    //            Console.WriteLine("User: " + firstName + " " + lastName + "Email: " + email);
    //        }
    //        Console.WriteLine();
    //    }
    //}

    IStartProgram startProgram = new StartProgram(args);
    startProgram.Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

public class ConnectionSettings
{
    public List<ConnectionStrings> ConnectionStrings { get; set; }
    public DatabaseFactoryConfiguration DatabaseFactoryConfiguration { get; set; }   
}

public class ConnectionStrings
{
    public string Name { get; set; }
    public string ProviderName { get; set; }
    public string ConnectionString { get; set; }
}

public class DatabaseFactoryConfiguration
{
    public string Name { get; set; }
    public string ConnectionStringName { get; set; }
}

public abstract class Database
{
    public string connectionString;

    #region Abstract Functions

    public abstract IDbConnection CreateConnection();
    public abstract IDbCommand CreateCommand();
    public abstract IDbConnection CreateOpenConnection();
    public abstract IDbCommand CreateCommand(string commandText, IDbConnection connection);
    public abstract IDbCommand CreateStoredProcCommand(string procName, IDbConnection connection);
    public abstract IDataParameter CreateParameter(string parameterName, object parameterValue);

    #endregion
}

public sealed class DatabaseFactorySectionHandler
{
    private static ConnectionSettings connectionSettings;

    public static void Create(IConfiguration config)
    {
        connectionSettings = config.GetRequiredSection("ConnectionSettings").Get<ConnectionSettings>();
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

public sealed class DatabaseFactory
{
    private DatabaseFactory() { }

    public static Database CreateDatabase()
    {
        // Verify a DatabaseFactoryConfiguration line exists in the web.config.
        if (DatabaseFactorySectionHandler.Name.Length == 0)
        {
            throw new Exception("Database name not defined in DatabaseFactoryConfiguration section of appsettings.json.");
        }

        try
        {
            // Find the class
            Type database = Type.GetType(DatabaseFactorySectionHandler.Name);

            // Get it's constructor
            ConstructorInfo constructor = database.GetConstructor(new Type[] { });

            // Invoke it's constructor, which returns an instance.
            Database createdObject = (Database)constructor.Invoke(null);

            // Initialize the connection string property for the database.
            createdObject.connectionString = DatabaseFactorySectionHandler.ConnectionString;

            // Pass back the instance as a Database
            return createdObject;
        }
        catch (Exception excep)
        {
            throw new Exception("Error instantiating database " + DatabaseFactorySectionHandler.Name + ". " + excep.Message);
        }
    }
}

public class DataWorker
{
    private static Database _database = null;

    static DataWorker()
    {
        try
        {
            _database = DatabaseFactory.CreateDatabase();
        }
        catch (Exception excep)
        {
            throw excep;
        }
    }

    public static Database database
    {
        get { return _database; }
    }
}

class UsersManager : DataWorker
{
    public static void GetUsers()
    {
        using (IDbConnection connection = database.CreateOpenConnection())
        {
            using (IDbCommand command = database.CreateCommand("SELECT * FROM users", connection))
            {
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
        }
    }
}

public class MySQLDatabase : Database
{
    public override IDbConnection CreateConnection()
    {
        return new MySqlConnector.MySqlConnection(connectionString);
    }

    public override IDbCommand CreateCommand()
    {
        return new MySqlConnector.MySqlCommand();
    }

    public override IDbConnection CreateOpenConnection()
    {
        MySqlConnector.MySqlConnection connection = (MySqlConnector.MySqlConnection)CreateConnection();
        connection.Open();

        return connection;
    }

    public override IDbCommand CreateCommand(string commandText, IDbConnection connection)
    {
        MySqlConnector.MySqlCommand command = (MySqlConnector.MySqlCommand)CreateCommand();

        command.CommandText = commandText;
        command.Connection = (MySqlConnector.MySqlConnection)connection;
        command.CommandType = CommandType.Text;

        return command;
    }

    public override IDbCommand CreateStoredProcCommand(string procName, IDbConnection connection)
    {
        MySqlConnector.MySqlCommand command = (MySqlConnector.MySqlCommand)CreateCommand();

        command.CommandText = procName;
        command.Connection = (MySqlConnector.MySqlConnection)connection;
        command.CommandType = CommandType.StoredProcedure;

        return command;
    }

    public override IDataParameter CreateParameter(string parameterName, object parameterValue)
    {
        return new MySqlConnector.MySqlParameter(parameterName, parameterValue);
    }
}