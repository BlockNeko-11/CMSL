using Avalonia;
using System;
using Avalonia.Logging;
using CMSL.Core.IO;
using CMSL.Core.Utils;
using Logger = CMSL.Core.Logging.Logger;

namespace CMSL.UI;

public static class CMSLGUI
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        try
        {
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }
        catch (Exception ex)
        {
            var path = CrashReport.Generate("GUI Crashed", ex);
            Paths.OpenWithExplorer(path);
            App.Shutdown();
        }
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
    {
        return AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
#if DEBUG
            .LogToTrace(LogEventLevel.Information)
#else
            .LogToTrace()
#endif
        ;
    }
}
