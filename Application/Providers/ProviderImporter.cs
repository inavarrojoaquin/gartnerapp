using Application.Generators;
using Domain.ProviderItems;
using Infrastructure.Repositories;

namespace Application.Providers
{
    public class ProviderImporter : IProviderImporter
    {
        private IReportConsoleGenerator reportConsoleGenerator;
        private IProductRepository repository;
        private IProvider targetProvider;

        public ProviderImporter(IProvider targetProvider,
                                IReportConsoleGenerator reportConsoleGenerator,
                                IProductRepository repository)
        {
            this.targetProvider = targetProvider;
            this.reportConsoleGenerator = reportConsoleGenerator;
            this.repository = repository;
        }
        public void Import()
        {
            ICollection<IProduct> items = targetProvider.GetItems();

            string generatedReport = reportConsoleGenerator.Generate(items);

            Console.Write(generatedReport);

            foreach (IProduct item in items)
            {
                repository.Insert(item);
            }
        }
    }
}
