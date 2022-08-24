using Application.Providers;

namespace ApplicationTest.Providers
{
    public class CapterraProviderShould
    {
        [Test]
        public void GenerateImportLogAsExpected()
        {
            CapterraProvider capterraProduct = new CapterraProvider();

            Assert.DoesNotThrow(() => capterraProduct.Run(TestConstants.CAPTERRA_FILE_PATH));
        }
    }
}