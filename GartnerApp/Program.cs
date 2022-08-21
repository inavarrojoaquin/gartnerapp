// See https://aka.ms/new-console-template for more information

try
{
    StartProgram startProgram = new StartProgram(args);
    startProgram.Run();

    // To Debug use these lines and comment the previous ones
    //string[] testArgs = { "import", "capterra", "feed-products/capterra.yaml" };
    //StartProgram startProgram = new StartProgram(testArgs);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}