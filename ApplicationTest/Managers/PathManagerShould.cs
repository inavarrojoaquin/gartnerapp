using Application.Managers;

namespace ApplicationTest.Managers
{
    public class PathManagerShould
    {
        [Test]
        public void GetPathAsExpected()
        {
            string inputPath = "path/target.json";
            PathManager pathManager = new PathManager();
            string targetPath = pathManager.GetTargetPath(inputPath);
            
            Assert.IsTrue(targetPath.Contains(inputPath));
        }
    }
}
