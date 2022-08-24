// See https://aka.ms/new-console-template for more information

using Application;
using Application.Providers;
using Microsoft.Extensions.Configuration;

try
{
    // Build a config object, using env vars and JSON providers.
    IConfiguration config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .AddEnvironmentVariables()
        .Build();

    IProviderFactory providerFactory = new ProviderFactory();
    //IDatabaseFactorySectionHandler databaseFactorySectionHandler = new DatabaseFactorySectionHandler(config);
    StartProgram startProgram = new StartProgram(args,
                                                  providerFactory);
    
    startProgram.Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}