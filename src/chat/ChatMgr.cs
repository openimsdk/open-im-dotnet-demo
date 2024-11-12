using OpenIMSDK = OpenIM.IMSDK.IMSDK;

using OpenIM.IMSDK;

namespace IMDemo.Chat
{
    public class ChatMgr
    {
        private static ChatMgr _instance;
        public static ChatMgr Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ChatMgr();
                }
                return _instance;
            }
        }
        public User currentUser;
        ConnListener connListener;
        private ChatMgr()
        {
            connListener = new ConnListener();
        }
        public static OpenIM.IMSDK.PlatformID PlatformID = OpenIM.IMSDK.PlatformID.AndroidPlatformID;
        // {
        //             get
        //             {
        // #if WINDOWS
        //                 return OpenIM.IMSDK.PlatformID.AndroidPlatformID;
        // #elif LINUX
        //             return OpenIM.IMSDK.PlatformID.LinuxPlatformID;
        // #elif MAC
        //             return OpenIM.IMSDK.PlatformID.OSXPlatformID;
        // #endif
        //             }
        // }
        public bool InitSDK()
        {
            var config = new IMConfig()
            {
                PlatformID = (int)PlatformID,
                ApiAddr = Config.APIAddr,
                WsAddr = Config.WsAddr,
                DataDir = Path.Combine(AppContext.BaseDirectory, Config.DataDir),
                LogLevel = Config.LogLevel,
                IsLogStandardOutput = Config.IsLogStandardOutput,
                LogFilePath = Path.Combine(AppContext.BaseDirectory, Config.LogFilePath),
                IsExternalExtensions = Config.IsExternalExtensions,
            };

            return OpenIMSDK.InitSDK(config, connListener);
        }

        public void Update()
        {
            OpenIMSDK.Polling();
        }

        public string GetConnStatus()
        {
            return connListener.connectStatus.ToString();
        }
    }
}