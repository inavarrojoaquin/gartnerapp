using GartnerApp;

public class StartProgram
{
    private string[] args;

    public StartProgram(string[] args)
    {
        if(args == null)
            throw new ArgumentNullException("Arguments");

        if (args.Length == 0)
            throw new ArgumentException("Error: Arguments are empty");

        if (args.Length != 3)
            throw new ArgumentException(string.Format("Error: Arguments size must be 3. Current size: {0}",
                                                    args.Length));
        
        this.args = args;
    }

    public void Run()
    {
        if (args[0].ToLower() == Constants.IMPORT)
        {
            IProviderFactory providerFactory = new ProviderFactory();
            IProvider targetProvider = providerFactory.Execute(args[1].ToLower());

            targetProvider.Run(args[2]);
        }

        ShowMessageToFinishProgram();
    }

    static void ShowMessageToFinishProgram()
    {
        Console.WriteLine("Press any key to finish...");
        Console.ReadKey();
    }
}