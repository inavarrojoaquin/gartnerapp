using GartnerApp;
using Newtonsoft.Json;
using System.Text;

public class SoftwareAdviceProvider : IProvider
{
    public void Run(string inputPath)
    {
        PathManager pathManager = new PathManager();
        string targetPath = pathManager.GetTargetPath(inputPath);
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