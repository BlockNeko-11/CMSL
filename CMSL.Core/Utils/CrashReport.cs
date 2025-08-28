using System.Text;
using CMSL.Core.Info;
using CMSL.Core.Logging;

namespace CMSL.Core.Utils;

public static class CrashReport
{
    public static string Generate(string description, Exception ex)
    {
        var content = $"Crystal Minecraft Server Launcher (CMSL) has crashed! {Environment.NewLine}" +
                      $"Please send the crash report to GitHub issues to help us fix the issue. {Environment.NewLine}{Environment.NewLine}" +
                      $"CMSL Version: {AppInfo.Version} {Environment.NewLine}" +
                      $"OS: {SystemInfo.OS} {Environment.NewLine}" +
                      $"Arch: {SystemInfo.Arch} {Environment.NewLine}" +
                      $"Description: {description} {Environment.NewLine}" + 
                      $"Exception: {ex} {Environment.NewLine}";

        var date = DateTimeUtils.CrashReportFileFormatted();
        var crashReports = Path.Combine(AppInfo.DataDir, "crash-reports");

        if (!Directory.Exists(crashReports))
        {
            Directory.CreateDirectory(crashReports);
        }
        var file = Path.Combine(crashReports, date + "_crash.log");
        File.WriteAllBytes(file, Encoding.UTF8.GetBytes(content));
        
        Logger.Err($"Crash report file has generated: {file}");
        return file;
    }
}