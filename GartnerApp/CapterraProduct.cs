using GartnerApp;
using System.Text;
using YamlDotNet.Serialization.NamingConventions;

public class CapterraProvider : IProvider
{
    public void Run(string inputPath)
    {
        string currentExePath = System.Reflection.Assembly.GetEntryAssembly().Location;
        string basePath = currentExePath.Split("GartnerApp")[0];
        string targetPath = Path.Combine(basePath, inputPath);

        using (var input = File.OpenText(targetPath))
        {
            var deserializer = new YamlDotNet.Serialization.DeserializerBuilder()
                                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                                .Build();

            List<CapterraItem> capterras = deserializer.Deserialize<List<CapterraItem>>(input);

            foreach (CapterraItem capterra in capterras)
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
}