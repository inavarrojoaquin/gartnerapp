using Domain.ProviderItems;
using System.Text;

namespace Application.Generators
{
    public class ReportConsoleGenerator : IReportConsoleGenerator
    {
        public string Generate(ICollection<IProduct> items)
        {
            if(items == null || !items.Any())
                return string.Empty;

            StringBuilder report = new StringBuilder();

            report.AppendLine("Importing " + items.Count + " items...");

            foreach (var item in items)
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
            report.AppendLine();

            return report.ToString();
        }
    }
}
