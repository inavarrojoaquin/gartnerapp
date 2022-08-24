// See https://aka.ms/new-console-template for more information

using Application.Handlers;
using Infrastructure.Factories;
using Infrastructure.Starts;
using Microsoft.Extensions.Configuration;

try
{
    // Build a config object, using env vars and JSON providers.
    IConfiguration config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .AddEnvironmentVariables()
        .Build();

    IProviderFactory providerFactory = new ProviderFactory();
    IDatabaseFactorySectionHandler databaseFactorySectionHandler = new DatabaseFactorySectionHandler(config);
    IStartProgram startProgram = new StartProgram(args,
                                                  providerFactory,
                                                  databaseFactorySectionHandler);
    
    startProgram.Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}