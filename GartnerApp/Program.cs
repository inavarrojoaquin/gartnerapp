// See https://aka.ms/new-console-template for more information


using Infrastructure.Starts;

try
{
    IStartProgram startProgram = new StartProgram(args);
    startProgram.Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}