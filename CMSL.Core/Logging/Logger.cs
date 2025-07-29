using CMSL.Core.Info;
using CMSL.Core.Utils;

namespace CMSL.Core.Logging;

public static class Logger
{
    private static StreamWriter _fileWriter;

    public static void Init()
    {
        if (RuntimeInfo.RunType == RunType.Designer)
        {
            return;
        }
        
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
    }

    private static void Log(string level, string message)
    {
        var formatted = $"[CMSL][{DateTimeUtils.Formatted()}] [{level}] {message}";
        Console.WriteLine(formatted);

        if (RuntimeInfo.RunType == RunType.Program)
        {
            _fileWriter.WriteLine(formatted);
        }
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

    public static void Shutdown()
    {
        if (RuntimeInfo.RunType == RunType.Designer)
        {
            return;
        }
        
        _fileWriter.Dispose();
    }
}