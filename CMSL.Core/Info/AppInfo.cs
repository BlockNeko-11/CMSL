using System.Reflection;
using CMSL.Core.Utils;

namespace CMSL.Core.Info;

public static class AppInfo
{
    public static string Version { get; private set; }
    
    public static string DataDir { get; private set; }

    public static void Init()
    {
        Version = Assembly.GetExecutingAssembly().GetName().Version!.ToString();
        
        var workingDir = Directory.GetCurrentDirectory();
        DataDir = Path.Combine(workingDir, Constants.DataDirName);

        if (!Directory.Exists(DataDir))
        {
            Directory.CreateDirectory(DataDir);
        }
    }
}