using CMSL.Core.Info;
using CMSL.Core.Logging;

namespace CMSL.Core;

public static class CMSLCore
{
    public static void Init()
    {
        AppInfo.Init();
        Logger.Init();
    }
    
    public static void Shutdown()
    {
        Logger.Shutdown();
    }
}