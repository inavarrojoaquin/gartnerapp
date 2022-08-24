using Application.Database;
using Infrastructure.Handlers;
using System.Reflection;

namespace Infrastructure.Persistance
{
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
}
