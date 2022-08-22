namespace Application.Managers
{
    public class PathManager
    {
        public string GetTargetPath(string inputPath)
        {
            string currentExePath = System.Reflection.Assembly.GetEntryAssembly().Location;
            string basePath = currentExePath.Split("GartnerApp")[0];
            
            return Path.Combine(basePath, inputPath);
        }
    }
}