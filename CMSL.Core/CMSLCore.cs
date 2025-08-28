using CMSL.Core.Info;
using CMSL.Core.Logging;

namespace CMSL.Core;

public static class CMSLCore
{
    public static event Action? onShutdown;
    
    public static void Init()
    {
        AppInfo.Init();
        Logger.Init();
        SystemInfo.Init();
    }
    
    public static void Shutdown()
    {
        onShutdown?.Invoke();
    }
}