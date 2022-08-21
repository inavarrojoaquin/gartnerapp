// See https://aka.ms/new-console-template for more information

try
{
    string[] args1 = { "arg1" };
    StartProgram startProgram = new StartProgram(args1);
    startProgram.Run();
}
catch (Exception)
{
    throw;
}