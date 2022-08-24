using Application.Providers;

namespace ApplicationTest.Providers
{
    public class ProviderFactoryShould
    {
        [Test]
        public void CreateCapterraProviderAsExpected()
        {
            IProviderFactory providerFactory = new ProviderFactory();
            IProvider targetProvider = providerFactory.Execute(TestConstants.CAPTERRA);

            Assert.DoesNotThrow(() => targetProvider.Run(TestConstants.CAPTERRA_FILE_PATH));
        }

        [Test]
        public void CreateSoftwareAdvideProviderAsExpected()
        {
            IProviderFactory providerFactory = new ProviderFactory();
            IProvider targetProvider = providerFactory.Execute(TestConstants.SOFTWAREADVICE);

            Assert.DoesNotThrow(() => targetProvider.Run(TestConstants.SOFTWAREADVICE_FILE_PATH));
        }
    }
}
