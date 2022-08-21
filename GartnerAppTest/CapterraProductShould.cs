namespace GartnerAppTest
{
    public class CapterraProductShould
    {
        [Test]
        public void GenerateImportLogAsExpected()
        {
            CapterraProvider capterraProduct = new CapterraProvider();

            Assert.DoesNotThrow(() => capterraProduct.Run(TestConstants.CAPTERRA_FILE_PATH));
        }
    }
}