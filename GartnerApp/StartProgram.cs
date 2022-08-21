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
                var currentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());

                var targetParent = currentDirectory.Parent.Parent.Parent.Parent.Parent;

                string inputPath = args[2];
                string targetPath = Path.Combine(targetParent.FullName, inputPath);
                
                using (var input = File.OpenText(targetPath))
                {
                    var deserializer = new YamlDotNet.Serialization.DeserializerBuilder()
                                        .WithNamingConvention(CamelCaseNamingConvention.Instance)
                                        .Build();

                    List<Capterra> capterras = deserializer.Deserialize<List<Capterra>>(input);
                    
                    foreach (Capterra capterra in capterras) 
                    {
                        StringBuilder reportLog = new StringBuilder();
                        reportLog.Append("Importing: ");
                        reportLog.Append("Name: " + capterra.Name + ";");
                        reportLog.Append("Categories: " + capterra.Tags + ";");
                        reportLog.Append("Twitter: " + capterra.Twitter + ";");

                        Console.WriteLine(reportLog.ToString());
                    }   
                }
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