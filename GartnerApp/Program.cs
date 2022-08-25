// See https://aka.ms/new-console-template for more information

using Application;
using Application.Generators;
using Application.Parsers;
using Application.Providers;
using Application.Repositories;
using Microsoft.Extensions.Configuration;

try
{
    IConfiguration config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .AddEnvironmentVariables()
        .Build();

    IInputParser inputParser = new InputParser(args);
    IProviderFactory providerFactory = new ProviderFactory();
    IReportConsoleGenerator reportConsoleGenerator = new ReportConsoleGenerator();
    IRepository repository = new Repository();
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