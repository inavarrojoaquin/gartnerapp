using Domain.Database;
using Domain.ProviderItems;
using Infrastructure.Handlers;
using Infrastructure.Persistance;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using NSubstitute;

namespace InfrastructureTest.Repositories
{
    public class ProductRepositoryShould
    {
        [Test]
        public void InsertProductAsExpected()
        {
            IConfiguration config = Substitute.For<IConfiguration>();

            ConnectionSetting connSettings = new ConnectionSetting
            { 
                Name = "MySQLConnection",
                ProviderName = "MySqlConnector",
                ConnectionString = "Server=localhost; Port=3306; Database=testtest22; Uid=gartner; Pwd=gartnertest; charset=utf8: sslMode=none",
                ProviderInvariantName = "MySqlConnector"
            };

            var configSection = Substitute.For<IConfigurationSection>();
            var configuration = Substitute.For<IConfiguration>();

            //object obj = null;
            //configSection.Get(Arg.Any<Type>()).Returns(obj);

            //configuration.GetSection(Arg.Any<string>()).Returns(configSection);


            //config.GetRequiredSection(Arg.Any<string>()).Get(Arg.Any<Type>()).Returns(x => null);

            IDatabaseSettingsHandler databaseFactorySectionHandler = new DatabaseSettingsHandler(config);
            Database database = new Database(databaseFactorySectionHandler);
            IProductRepository productRepository = new ProductRepository(database);
            IProduct item = new CapterraProduct
            {
                Name = "Name1",
                Tags = new List<string> { "Tag1", "Tag2" },
                Twitter = "Twitter"
            };

            productRepository.Insert(item);


        }
    }
}
