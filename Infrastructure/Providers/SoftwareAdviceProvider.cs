using Application.Managers;
using Domain.DTOs;
using Domain.Providers;
using Newtonsoft.Json;

namespace Infrastructure.Providers
{
    public class SoftwareAdviceProvider : IProvider
    {
        public void Run(string inputPath)
        {
            PathManager pathManager = new PathManager();
            string targetPath = pathManager.GetTargetPath(inputPath);

            string file = File.ReadAllText(targetPath);
            SoftwareAdviceDTO softwareAdviceDTO = JsonConvert.DeserializeObject<SoftwareAdviceDTO>(file);
            SoftwareAdvice customSoftwareAdvice = new SoftwareAdvice(softwareAdviceDTO);

            ReportManager report = new ReportManager();
            string resultReport = report.BuildReport(customSoftwareAdvice);

            Console.WriteLine(resultReport);
        }
    }
}