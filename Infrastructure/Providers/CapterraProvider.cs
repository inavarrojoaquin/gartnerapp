using Application.Managers;
using Domain.DTOs;
using Domain.Providers;
using YamlDotNet.Serialization.NamingConventions;

namespace Infrastructure.Providers
{
    public class CapterraProvider : IProvider
    {
        public void Run(string inputPath)
        {
            PathManager pathManager = new PathManager();
            string targetPath = pathManager.GetTargetPath(inputPath);

            using (var input = File.OpenText(targetPath))
            {
                var deserializer = new YamlDotNet.Serialization.DeserializerBuilder()
                                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                                    .Build();

                List<CapterraItemDTO> capterraList = deserializer.Deserialize<List<CapterraItemDTO>>(input);

                Capterra customCapterra = new Capterra(capterraList);

                ReportManager report = new ReportManager();
                string resultReport = report.BuildReport(customCapterra);

                Console.WriteLine(resultReport);
            }
        }
    }
}