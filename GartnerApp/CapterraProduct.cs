using System.Text;
using YamlDotNet.Serialization.NamingConventions;

public class CapterraProduct
{
    public CapterraProduct()
    {
    }

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
}