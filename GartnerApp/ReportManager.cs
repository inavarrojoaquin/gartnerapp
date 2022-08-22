using System.Text;

namespace GartnerApp
{
    public class ReportManager
    {
        public string BuildReport(ICustomProvider customProvider)
        {
            StringBuilder report = new StringBuilder();

            foreach (var item in customProvider.Products)
            {
                report.Append("Importing: ");
                
                if (!string.IsNullOrEmpty(item.Name))
                    report.Append("Name: " + item.Name + ";");

                if (item.Tags.Any())
                {
                    report.Append("Categories: ");
                    foreach (string tag in item.Tags)
                    {
                        string log = tag + ", ";
                        if (tag == item.Tags.Last())
                            log = tag + "; ";

                        report.Append(log);
                    }
                }
                
                if (!string.IsNullOrEmpty(item.Twitter))
                    report.Append("Twitter: " + item.Twitter + "; ");
                
                report.AppendLine();
            }

            return report.ToString();
        }
    }
}