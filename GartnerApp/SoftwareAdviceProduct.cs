using GartnerApp;
using Newtonsoft.Json;
using System.Text;

public class SoftwareAdviceProvider : IProvider
{
    public void Run(string inputPath)
    {
        string currentExePath = System.Reflection.Assembly.GetEntryAssembly().Location;
        string basePath = currentExePath.Split("GartnerApp")[0];
        string targetPath = Path.Combine(basePath, inputPath);
        string file = File.ReadAllText(targetPath);

        SoftwareAdvice softwareAdvice = JsonConvert.DeserializeObject<SoftwareAdvice>(file);

        foreach(SoftwareAdviceItem item in softwareAdvice.Products)
        {
            StringBuilder reportLog = new StringBuilder();
            reportLog.Append("Importing: ");
            reportLog.Append("Name: " + item.Name  + "; ");
            reportLog.Append("Categories: ");
            foreach(string tag in item.Tags)
            {
                string log = tag + ", ";
                if (tag == item.Tags.Last())
                    log = tag + "; ";

                reportLog.Append(log);
            }
                
            reportLog.Append("Twitter: " + item.Twitter + "; ");

            Console.WriteLine(reportLog.ToString());
        }
    }
}