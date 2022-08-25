using Application.Generators;
using Domain.ProviderItems;

namespace ApplicationTest.Generators
{
    public class ReportConsoleGeneratorShould
    {
        [Test]
        public void GenerateReportAsExpected()
        {
            IReportConsoleGenerator reportConsoleGenerator = new ReportConsoleGenerator();

            ICollection<IProduct> items = new List<IProduct>
            {
                new CapterraProduct
                {
                    Name = "Name1",
                    Tags = new List<string> { "Tag1", "Tag2" },
                    Twitter = "Twitter1"
                },
                new CapterraProduct
                {
                    Name = "Name2",
                    Tags = new List<string> { "Tag3", "Tag4" },
                    Twitter = "Twitter2"
                }
            };

            string generatedReport = reportConsoleGenerator.Generate(items);

            Assert.That(generatedReport, Is.Not.Null);
            Assert.That(generatedReport, Is.Not.Empty);

            Assert.That(generatedReport.Contains("Name1"), Is.True);
            Assert.That(generatedReport.Contains("Tag1"), Is.True);
            Assert.That(generatedReport.Contains("Tag2"), Is.True);
            Assert.That(generatedReport.Contains("Twitter1"), Is.True);

            Assert.That(generatedReport.Contains("Name2"), Is.True);
            Assert.That(generatedReport.Contains("Tag3"), Is.True);
            Assert.That(generatedReport.Contains("Tag4"), Is.True);
            Assert.That(generatedReport.Contains("Twitter2"), Is.True);
        }

        [Test]
        public void GetEmptyWhenItemsAreNull()
        {
            IReportConsoleGenerator reportConsoleGenerator = new ReportConsoleGenerator();

            string generatedReport = reportConsoleGenerator.Generate(null);

            Assert.That(generatedReport, Is.Not.Null);
            Assert.That(generatedReport, Is.Empty);
        }

        [Test]
        public void GetEmptyWhenItemsDoesNotHaveElements()
        {
            IReportConsoleGenerator reportConsoleGenerator = new ReportConsoleGenerator();
            ICollection<IProduct> items = new List<IProduct>();
            string generatedReport = reportConsoleGenerator.Generate(items);

            Assert.That(generatedReport, Is.Not.Null);
            Assert.That(generatedReport, Is.Empty);
        }
    }
}
