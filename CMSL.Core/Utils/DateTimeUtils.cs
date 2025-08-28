namespace CMSL.Core.Utils;

public static class DateTimeUtils
{
    public static string LoggingFormatted()
    {
        return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }

    public static string CrashReportFileFormatted()
    {
        return DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
    }
}