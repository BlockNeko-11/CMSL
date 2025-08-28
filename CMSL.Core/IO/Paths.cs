using System.Diagnostics;
using CMSL.Core.Info;

namespace CMSL.Core.IO;

public static class Paths
{
    public static void OpenWithExplorer(string path)
    {
        var fullPath = Path.GetFullPath(path);
        
        switch (SystemInfo.OS)
        {
            case OSType.Windows:
                Process.Start("explorer", fullPath);
                break;
            case OSType.Linux:
                Process.Start("xdg-open", $"\"{fullPath}\"");
                break;
            case OSType.MacOS:
                Process.Start("open", $"\"{fullPath}\"");
                break;
        }
    }
}