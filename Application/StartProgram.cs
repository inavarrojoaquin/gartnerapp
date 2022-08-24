using Application.Providers;
using Domain.Common;

namespace Application
{
    public class StartProgram
    {
        private string[] arguments;
        private IProviderFactory providerFactory;
        //private readonly IDatabaseFactorySectionHandler databaseFactorySectionHandler;

        public StartProgram(string[] args,
                            IProviderFactory providerFactory)
        {
            if (args == null)
                throw new ArgumentNullException("Arguments");

            if (args.Length == 0)
                throw new ArgumentException("Error: Arguments are empty");

            arguments = args;
            this.providerFactory = providerFactory;
            //this.databaseFactorySectionHandler = databaseFactorySectionHandler;
        }

        public void Run()
        {
            string command = arguments[0].ToLower();
            if (command == Constants.IMPORT)
            {
                if (arguments.Length != 3)
                    throw new ArgumentException(string.Format("Error: Arguments size must be 3. Current size: {0}", arguments.Length));

                string provider = arguments[1].ToLower();
                string path = arguments[2].ToLower();

                IProvider targetProvider = providerFactory.Execute(provider);
                targetProvider.Run(path);
            }

            if (command == Constants.GETUSERS)
            {
                //GetUsersUseCase
                //UsersManager.GetUsers();
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