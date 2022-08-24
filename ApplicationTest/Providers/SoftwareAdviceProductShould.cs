using Application.Providers;

namespace ApplicationTest.Providers
{
    public class SoftwareAdviceProductShould
    {
        [Test]
        public void GenerateImportLogAsExpected()
        {
            SoftwareAdviceProvider softwareAdviceProduct = new SoftwareAdviceProvider();
            
            Assert.DoesNotThrow(() => softwareAdviceProduct.Run(TestConstants.SOFTWAREADVICE_FILE_PATH));
        }
    }
}