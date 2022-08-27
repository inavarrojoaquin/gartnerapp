using Domain.ProviderItems;
using Infrastructure.Persistance;

namespace Infrastructure.Repositories
{
    public class MongoDBProductRepository : IProductRepository
    {
        private Database database;
        public MongoDBProductRepository(Database database)
        {
            this.database = database;
        }
        public void Insert(IProduct item)
        {
            Console.WriteLine("MongoDB Inserting...: " + item.Name);
        }
    }
}
