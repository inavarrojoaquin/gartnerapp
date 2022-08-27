using Application.Products;
using Domain.Database;
using Infrastructure.Handlers;
using Infrastructure.Persistance;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest.Products
{
    public class ProductRepositoryFactoryShould
    {
        [Test]
        public void GetExpectedMySQLProductRepository()
        {
            IConfiguration config = GetSettings(TestConstants.MYSQL_CONNECTION_NAME);
           
            DatabaseSettingsHandler databaseFactorySectionHandler = Substitute.For<DatabaseSettingsHandler>(config);

            Database database = Substitute.For<Database>();
            
            IProductRepository productRepository = ProductRepositoryFactory.Create(databaseFactorySectionHandler, database);

            Assert.That(productRepository.GetType(),
                        Is.EqualTo(typeof(MySQLProductRepository)));
        }

        [Test]
        public void GetExpectedMongoDBProductRepository()
        {
            IConfiguration config = GetSettings(TestConstants.MONGODB_CONNECTION_NAME);

            DatabaseSettingsHandler databaseFactorySectionHandler = Substitute.For<DatabaseSettingsHandler>(config);

            Database database = Substitute.For<Database>();

            IProductRepository productRepository = ProductRepositoryFactory.Create(databaseFactorySectionHandler, database);

            Assert.That(productRepository.GetType(),
                        Is.EqualTo(typeof(MongoDBProductRepository)));
        }

        private IConfiguration GetSettings(string targetConnectionName)
        {
            ConnectionSettings connSettings = new ConnectionSettings
            {
                SelectedConnectionProviderName = targetConnectionName,
                ConnectionProviders = new List<ConnectionProvider>()
            };

            var appSettings = JsonConvert.SerializeObject(connSettings);
            var settings = "{\"ConnectionSettings\": " + appSettings + "}";

            MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(settings));
            
            return new ConfigurationBuilder()
                .AddJsonStream(memoryStream)
                .Build();
        }
    }
}
