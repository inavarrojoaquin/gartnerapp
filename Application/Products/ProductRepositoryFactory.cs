using Domain.Common;
using Infrastructure.Handlers;
using Infrastructure.Persistance;
using Infrastructure.Repositories;

namespace Application.Products
{
    public static class ProductRepositoryFactory
    {
        public static IProductRepository Create(
            DatabaseSettingsHandler databaseFactorySectionHandler,
            Database database)
        {
            if (databaseFactorySectionHandler.SelectedConnectionProviderName
                == Constants.MYSQL_CONNECTION_NAME)
                return new MySQLProductRepository(database);

            return new MongoDBProductRepository(database);
        }
    }
}
