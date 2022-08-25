using System.Reflection;

namespace Application.Generators
{
    public class PathGenerator : IPathGenerator
    {
        public string Generate(string inputPath)
        {
            string[] splitedPath = inputPath.Split(
                new string[] { "\\", "/" },
                StringSplitOptions.None);
            string folder = splitedPath[0];
            
            var basePath = Path.GetPathRoot(Assembly.GetEntryAssembly().Location);
            string targetPath = Path.Combine(basePath, folder);

            if (!Directory.Exists(targetPath))
                throw new Exception("Error: The folder feed-products does not exists. The folder must be in C: eg. C:\\feed-products\\capterra.yaml");

            string file = splitedPath[1];
            targetPath = Path.Combine(targetPath, file);
            
            if (!File.Exists(targetPath))
                throw new Exception("Error: The file does not exists. The file must be in C:\\feed-products eg. C:\\feed-products\\capterra.yaml");

            return targetPath;
        }
    }
}