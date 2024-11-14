using OpenIMSDK = OpenIM.IMSDK.IMSDK;

using OpenIM.IMSDK;
using Dawn;
using IMDemo.Data;
using Newtonsoft.Json;
using System.Text;

namespace IMDemo.Chat
{
    public class ChatMgr
    {
        public static DemoApplication Application;
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
        public static OpenIM.IMSDK.PlatformID PlatformID
        {
            get
            {
#if WINDOWS
                return OpenIM.IMSDK.PlatformID.WindowsPlatformID;
#elif LINUX
                return OpenIM.IMSDK.PlatformID.LinuxPlatformID;
#elif MAC
                return OpenIM.IMSDK.PlatformID.OSXPlatformID;
#endif
            }
        }
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
        public void UnInitSDK()
        {
            OpenIMSDK.UnInitSDK();
        }
        public void Update()
        {
            OpenIMSDK.Polling();
        }

        public string GetConnStatus()
        {
            return connListener.connectStatus.ToString();
        }

        async void RefreshToken(string userId)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var url = string.Format("{0}{1}", Config.APIAddr, "/auth/get_user_token");
                    var userTokenReq = new UserTokenReq()
                    {
                        secret = "openIM123",
                        platformID = (int)ChatMgr.PlatformID,
                        userID = userId,
                    };
                    var postData = JsonConvert.SerializeObject(userTokenReq);
                    httpClient.DefaultRequestHeaders.Add("operationID", "111111");
                    httpClient.DefaultRequestHeaders.Add("token", Config.AdminToken);
                    HttpResponseMessage response = await httpClient.PostAsync(url, new StringContent(postData, Encoding.UTF8, "application/json"));
                    response.EnsureSuccessStatusCode();
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var res = JsonConvert.DeserializeObject<UserTokenRes>(jsonResponse);
                    if (res.errCode > 0)
                    {
                        Debug.Log($"Http Request Error Code :{res.errCode + ":" + res.errMsg}");
                    }
                    else
                    {
                        var token = res.data.token;
                        // TODO
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Http Request Error:{e.Message}");
                }
            }
        }
    }
}