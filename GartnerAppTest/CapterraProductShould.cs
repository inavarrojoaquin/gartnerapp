namespace GartnerAppTest
{
    public class CapterraProductShould
    {
        
        
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void GenerateImportLogAsExpected()
        {
            CapterraProduct capterraProduct = new CapterraProduct();
            string inputPath = "feed-products/capterra.yaml";
            
            Assert.DoesNotThrow(() => capterraProduct.Run(inputPath));
        }

    }
}