using System.Reflection;
using System.Text;
using System.Xml;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

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
        if (args[0].ToLower() == "import")
        {
            if (args[1].ToLower() == "capterra")
            {
                CapterraProduct capterraProduct = new CapterraProduct();
                capterraProduct.Run(args[2]);
            }

            if (args[1].ToLower() == "softwareadvice")
            {
                Console.WriteLine("Source: ", args[2]);
            }
        }

        ShowMessageToFinishProgram();

    }

    static void ShowMessageToFinishProgram()
    {
        Console.WriteLine("Press any key to finish...");
        Console.ReadKey();
    }
}