using Application.Generators;
using Application.Repositories;
using Domain.ProviderItems;

namespace Application.Providers
{
    public class ProviderImporter : IProviderImporter
    {
        private IReportConsoleGenerator reportConsoleGenerator;
        private IRepository repository;
        private IProvider targetProvider;

        public ProviderImporter(IProvider targetProvider,
                                IReportConsoleGenerator reportConsoleGenerator,
                                IRepository repository)
        {
            this.targetProvider = targetProvider;
            this.reportConsoleGenerator = reportConsoleGenerator;
            this.repository = repository;
        }
        public ICollection<IProduct> GetItems()
        {
            return targetProvider.GetItems();
        }

        public string Generate(ICollection<IProduct> items)
        {
            return reportConsoleGenerator.Generate(items);
        }

        public void Insert(ICollection<IProduct> items)
        {
            foreach (IProduct item in items)
            {
                repository.Insert(item);
            }
        }
    }
}
