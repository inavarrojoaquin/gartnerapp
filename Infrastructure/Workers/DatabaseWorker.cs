using Application.Database;
using Infrastructure.Persistance;

namespace Infrastructure.Workers
{
    public class DatabaseWorker
    {
        private static Database _database = null;

        static DatabaseWorker()
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
}
