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
                report.Append("Name: " + item.Name + ";");
                report.Append("Categories: ");
                foreach (string tag in item.Tags)
                {
                    string log = tag + ", ";
                    if (tag == item.Tags.Last())
                        log = tag + "; ";

                    report.Append(log);
                }
                report.Append("Twitter: " + item.Twitter + "; ");
                report.AppendLine();
            }

            return report.ToString();
        }
    }
}