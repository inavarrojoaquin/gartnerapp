using Application.Generators;
using Application.Parsers;
using Application.Providers;
using Domain.DTO;
using Domain.ProviderItems;
using Infrastructure.Repositories;

namespace Application
{
    public class StartProgram
    {
        private readonly IInputParser inputParser;
        private readonly IProviderFactory providerFactory;
        private readonly IReportConsoleGenerator reportConsoleGenerator;
        private readonly IProductRepository repository;

        public StartProgram(IInputParser inputParser,
                            IProviderFactory providerFactory,
                            IReportConsoleGenerator reportConsoleGenerator,
                            IProductRepository repository)
        {
            this.inputParser = inputParser;
            this.providerFactory = providerFactory;
            this.reportConsoleGenerator = reportConsoleGenerator;
            this.repository = repository;
        }

        public void Run()
        {
            Console.WriteLine("Program starts\n");

            ConsoleInputDTO consoleInputDTO = inputParser.Parse();

            IPathGenerator pathGenerator = new PathGenerator();
            
            IProvider targetProvider = providerFactory.ProductParse(
                consoleInputDTO.Provider,
                consoleInputDTO.Path,
                pathGenerator);
            
            IProviderImporter providerImporter = new ProviderImporter(
                targetProvider,
                reportConsoleGenerator,
                repository);

            providerImporter.Import();

            Console.WriteLine("\nProgram ends");
        }
    }
}