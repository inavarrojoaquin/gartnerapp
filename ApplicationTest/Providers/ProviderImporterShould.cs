using Application.Generators;
using Application.Providers;
using Application.Repositories;
using Domain.ProviderItems;
using NSubstitute;

namespace ApplicationTest.Providers
{
    public class ProviderImporterShould
    {
        [Test]
        public void GetCapterraProviderItemsAsExpected()
        {
            string path = null;
            IPathGenerator pathGenerator = null;
            IProvider targetProvider = new CapterraProvider(path, pathGenerator);

            IReportConsoleGenerator reportConsoleGenerator = Substitute.For<IReportConsoleGenerator>();

            int generatorCounter = 0;
            reportConsoleGenerator
                .When(x => x.Generate(Arg.Any<ICollection<IProduct>>()))
                .Do(y => generatorCounter++);

            IRepository repository = Substitute.For<IRepository>();

            int repositoryCounter = 0;
            repository.When(x => x.Insert(Arg.Any<IProduct>()))
                      .Do(y => repositoryCounter++);

            IProviderImporter providerImporter = new ProviderImporter(
                            targetProvider,
                            reportConsoleGenerator,
                            repository);

            ICollection<IProduct> items = providerImporter.GetItems();

            Assert.That(items.Count, Is.EqualTo(2));
        }
    }
}
