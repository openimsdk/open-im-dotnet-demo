
namespace Dawn
{
    public static class Time
    {
        public static string GetTimeStampStr(long timeStamp)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(timeStamp);
            return dateTimeOffset.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}