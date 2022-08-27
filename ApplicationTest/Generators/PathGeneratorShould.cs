using Application.Generators;

namespace ApplicationTest.Generators
{
    public class PathGeneratorShould
    {
        [TestCase(TestConstants.CAPTERRA_FILE_PATH)]
        [TestCase(TestConstants.SOFTWAREADVICE_FILE_PATH)]
        public void GeneratePathAsExpected(string inputPath)
        {
            PathGenerator pathGenerator = new PathGenerator();
            string targetPath = pathGenerator.Generate(inputPath);

            Assert.That(targetPath.EndsWith(Path.Combine("GartnerApp", inputPath)), Is.True);
        }

        [Test]
        public void RaiseExWhenTargetFolderPathDoesNotExists()
        {
            PathGenerator pathGenerator = new PathGenerator();
            string inputPath = TestConstants.NOT_EXISTS_PATH;
            
            var ex = Assert.Throws<Exception>(() => pathGenerator.Generate(inputPath));

            Assert.That(ex.Message.Contains("Error: The folder feed-products does not exists. The folder must be in C: eg. C:\\feed-products\\capterra.yaml"), Is.True);
        }

        [Test]
        public void RaiseExWhenTargetFileDoesNotExists()
        {
            PathGenerator pathGenerator = new PathGenerator();
            string inputPath = Path.Combine(
                TestConstants.FEED_PRODUCTS_PATH,
                TestConstants.NOT_EXISTS_PATH);

            var ex = Assert.Throws<Exception>(() => pathGenerator.Generate(inputPath));

            Assert.That(ex.Message.Contains("Error: The file does not exists. The file must be in C:\\feed-products eg. C:\\feed-products\\capterra.yaml"), Is.True);
        }
    }
}
