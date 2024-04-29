public class Config
{
    public static string APIAddr = "http://192.168.101.9:10002";
    public static string WsAddr = "ws://192.168.101.9:10001";
    public static int PlatformID = 3; //windows
    public static string DataDir = "./";
    public static uint LogLevel = 5;
    public static bool IsLogStandardOutput = true;
    public static string LogFilePath = "./log/";
    public static bool IsExternalExtensions = true;
}