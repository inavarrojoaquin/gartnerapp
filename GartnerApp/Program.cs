// See https://aka.ms/new-console-template for more information

if (args.Length == 0 || args.Length != 3)
{
    Console.WriteLine("No arguments or arguments different of 3");
    ShowMessageToFinishProgram();
    return;
}



if (args[0].ToLower() == "import")
{
    if (args[1].ToLower() == "capterra")
    {
        Console.WriteLine("Source: ", args[2]);
    }

    if (args[1].ToLower() == "softwareadvice")
    {
        Console.WriteLine("Source: ", args[2]);
    }
}

ShowMessageToFinishProgram();

static void ShowMessageToFinishProgram()
{
    Console.WriteLine("Press any key to finish...");
    Console.ReadKey();
}