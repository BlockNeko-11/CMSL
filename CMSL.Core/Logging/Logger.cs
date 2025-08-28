using CMSL.Core.Info;
using CMSL.Core.Utils;

namespace CMSL.Core.Logging;

public static class Logger
{
    private static StreamWriter _fileWriter;

    public static void Init()
    {
        var log = Path.Combine(AppInfo.DataDir, Constants.LogFileName);

        if (File.Exists(log))
        {
            Console.WriteLine("Existing log file was found!");
        }

        var fileStream = File.Open(log, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
        _fileWriter = new StreamWriter(fileStream)
        {
            AutoFlush = true
        };

        CMSLCore.onShutdown += Shutdown;
    }

    private static void Log(string level, string message)
    {
        var formatted = $"[CMSL][{DateTimeUtils.LoggingFormatted()}] [{level}] {message}";
        Console.WriteLine(formatted);

        _fileWriter.WriteLine(formatted);
    }

    public static void Info(string message)
    {
        Log("INFO", message);
    }
    
    public static void Warn(string message)
    {
        Log("WARN", message);
    }
    
    public static void Err(string message)
    {
        Log("ERROR", message);
    }

    public static void Err(Exception ex)
    {
        Err(ex.ToString());
    }

    private static void Shutdown()
    {
        _fileWriter.Dispose();
    }
}