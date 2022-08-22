using Domain.Common;
using Infrastructure.Factories;
using Infrastructure.Providers;

namespace Infrastructure
{
    public class StartProgram
    {
        public string Command { get; }
        public string Provider { get; }
        public string Path { get; }

        public StartProgram(string[] args)
        {
            if (args == null)
                throw new ArgumentNullException("Arguments");

            if (args.Length == 0)
                throw new ArgumentException("Error: Arguments are empty");

            if (args.Length != 3)
                throw new ArgumentException(string.Format("Error: Arguments size must be 3. Current size: {0}",
                                                        args.Length));

            Command = args[0].ToLower();
            Provider = args[1].ToLower();
            Path = args[2].ToLower();
        }

        public void Run()
        {
            if (Command == Constants.IMPORT)
            {
                IProviderFactory providerFactory = new ProviderFactory();
                IProvider targetProvider = providerFactory.Execute(Provider);
                targetProvider.Run(Path);
            }

            ShowMessageToFinishProgram();
        }

        static void ShowMessageToFinishProgram()
        {
            Console.WriteLine("Press any key to finish...");
            Console.ReadKey();
        }
    }
}