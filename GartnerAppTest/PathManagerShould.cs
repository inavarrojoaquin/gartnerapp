using GartnerApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GartnerAppTest
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
