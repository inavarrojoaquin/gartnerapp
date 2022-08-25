using Application.Generators;
using Application.Providers;
using Domain.ProviderItems;
using NSubstitute;
using System.Reflection;

namespace ApplicationTest.Providers
{
    public class CapterraProviderShould
    {
        [Test]
        public void GetCapterraProductsAsExpected()
        {
            string inputPath = TestConstants.CAPTERRA_RESOURCE_FILE_PATH;
            var currentPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            var resourceTestFile = Path.Combine(currentPath, inputPath);

            IPathGenerator pathGenerator = Substitute.For<IPathGenerator>();
            pathGenerator.Generate(inputPath)
                         .Returns(resourceTestFile);

            IProvider capterraProvider = new CapterraProvider(
                inputPath,
                pathGenerator);

            ICollection<IProduct> items = capterraProvider.GetItems();

            Assert.That(items.Count, Is.EqualTo(3));
        }
    }
}