using Domain.ProviderItems;
using Infrastructure.Persistance;

namespace Infrastructure.Repositories
{
    public class MySQLProductRepository : IProductRepository
    {
        private Database database;
        public MySQLProductRepository(Database database)
        {
            this.database = database;
        }
        public void Insert(IProduct item)
        {
            Console.WriteLine("MySQL Inserting...: " + item.Name);
        }
    }
}
