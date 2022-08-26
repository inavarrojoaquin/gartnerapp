// See https://aka.ms/new-console-template for more information

using Application;
using Application.Generators;
using Application.Parsers;
using Application.Providers;
using Infrastructure.Handlers;
using Infrastructure.Persistance;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;

try
{
    IConfiguration config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .AddEnvironmentVariables()
        .Build();

    IDatabaseSettingsHandler databaseFactorySectionHandler = new DatabaseSettingsHandler(config);

    Database database = new Database(databaseFactorySectionHandler);
    
    IInputParser inputParser = new InputParser(args);
    IProviderFactory providerFactory = new ProviderFactory();
    IReportConsoleGenerator reportConsoleGenerator = new ReportConsoleGenerator();
    IProductRepository repository = new ProductRepository(database);
    StartProgram startProgram = new StartProgram(inputParser,
                                                 providerFactory,
                                                 reportConsoleGenerator,
                                                 repository);
    startProgram.Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}