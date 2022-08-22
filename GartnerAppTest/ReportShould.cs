using GartnerApp;

namespace GartnerAppTest
{
    public class ReportShould
    {
        [Test]
        public void GenerateCapterraReportAsExpected()
        {
            List<CapterraItemDTO> capterraList = new List<CapterraItemDTO> 
            {
                new CapterraItemDTO { Name = "Name1", Tags = "Tag1", Twitter = "Twitter1" },
                new CapterraItemDTO { Name = "Name2", Tags = "Tag2", Twitter = "Twitter2" }
            };

            ICustomProvider customProvider = new Capterra(capterraList);

            ReportManager report = new ReportManager();
            string resultReport = report.BuildReport(customProvider);

            Assert.IsNotNull(resultReport);
            Assert.IsNotEmpty(resultReport);
        }

        [Test]
        public void GenerateSoftwareAdviceReportAsExpected()
        {
            SoftwareAdviceDTO softwareAdviceDTO = new SoftwareAdviceDTO
            {
                Products = new List<SoftwareAdviceItemDTO>
                {
                    new SoftwareAdviceItemDTO
                    {
                        Name = "Name1", 
                        Tags = new List<string> { "Tag1" }, 
                        Twitter = "Twitter1"
                    },
                    new SoftwareAdviceItemDTO
                    {
                        Name = "Name1",
                        Tags = new List<string> { "Tag1" },
                        Twitter = "Twitter1"
                    }
                }
            };
            ICustomProvider customProvider = new SoftwareAdvice(softwareAdviceDTO);

            ReportManager report = new ReportManager();
            string resultReport = report.BuildReport(customProvider);

            Assert.IsNotNull(resultReport);
            Assert.IsNotEmpty(resultReport);
        }

    }
}
