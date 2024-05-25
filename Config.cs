public class Config
{
#if LOCALDEV
    public static string APIAddr = "http://192.168.101.9:10002";
    public static string WsAddr = "ws://192.168.101.9:10001";
#else
    public static string APIAddr = "http://14.29.168.56:10002";
    public static string WsAddr = "ws://14.29.168.56:10001";
#endif
    public static string DataDir = "./";
    public static uint LogLevel = 5;
    public static bool IsLogStandardOutput = true;
    public static string LogFilePath = "./log/";
    public static bool IsExternalExtensions = true;

}