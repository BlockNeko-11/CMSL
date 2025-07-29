namespace CMSL.Core.Utils;

public static class DateTimeUtils
{
    public static string Formatted()
    {
        return Formatted(DateTime.Now);
    }
    
    public static string Formatted(DateTime dateTime)
    {
        return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
    }
}