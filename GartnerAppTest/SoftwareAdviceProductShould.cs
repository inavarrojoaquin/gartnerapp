namespace GartnerAppTest
{
    public class SoftwareAdviceProductShould
    {
        [Test]
        public void GenerateImportLogAsExpected()
        {
            SoftwareAdviceProduct softwareAdviceProduct = new SoftwareAdviceProduct();
            string inputPath = "feed-products/softwareadvice.json";
            
            Assert.DoesNotThrow(() => softwareAdviceProduct.Run(inputPath));
        }

    }
}