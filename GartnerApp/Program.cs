// See https://aka.ms/new-console-template for more information

using Infrastructure.Starts;
using Microsoft.Extensions.Configuration;

try
{
    // Build a config object, using env vars and JSON providers.
    IConfiguration config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .AddEnvironmentVariables()
        .Build();

    IStartProgram startProgram = new StartProgram(args, config);
    startProgram.Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}