using Application.Generators;
using Application.Providers;
using Domain.ProviderItems;
using NSubstitute;
using System.Reflection;

namespace ApplicationTest.Providers
{
    public class SoftwareAdviceProductShould
    {
        [Test]
        public void GetSoftwareAdviceProductsAsExpected()
        {
            string inputPath = TestConstants.SOFTWAREADVICE_RESOURCE_FILE_PATH;
            var currentPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            var resourceTestFile = Path.Combine(currentPath, inputPath);

            IPathGenerator pathGenerator = Substitute.For<IPathGenerator>();
            pathGenerator.Generate(inputPath)
                         .Returns(resourceTestFile);

            IProvider softwareAdviceProvider = new SoftwareAdviceProvider(
                inputPath,
                pathGenerator);

            ICollection<IProduct> items = softwareAdviceProvider.GetItems();

            Assert.That(items.Count, Is.EqualTo(2));
        }
    }
}