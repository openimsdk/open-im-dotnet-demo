using System;
using OpenIM.IMSDK;
using OpenIM.IMSDK.Listener;

public enum ConnectStatus
{
    Offline, TokenExpired, Connecting, ConnectSuc, ConnectFailed
}

public class User : IConnListener
{
    static User user;
    public static User Instance
    {
        get
        {
            if (user == null)
            {
                user = new User();
            }
            return user;
        }
    }
    public UserInfo SelfUserInfo;
    public Conversation Conversation;
    public FriendShip Friend;
    public Group Group;
    public ConnectStatus ConnectStatus = ConnectStatus.Offline;

    public string LoginUser = "";
    public LoginStatus LoginStatus = LoginStatus.Empty;
    private User()
    {

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

    public bool Init()
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

        var res = IMSDK.InitSDK(config, this);
        if (!res)
        {
            return false;
        }
        Conversation = new Conversation(this);
        Friend = new FriendShip(this);
        Group = new Group(this);
        SetListener();
        return true;
    }
    public void Update()
    {
        IMSDK.Polling();
    }
    private void SetListener()
    {
        IMSDK.SetConversationListener(Conversation);
        IMSDK.SetFriendShipListener(Friend);
        IMSDK.SetGroupListener(Group);
    }
    public void Login(string userName, string token)
    {
        IMSDK.Login(userName, token, (bool suc, int errCode, string errMsg) =>
        {
            if (suc)
            {
            }
            else
            {
                Debug.Log(errCode, errMsg);
            }
        });
    }
    public void OnConnecting()
    {
        ConnectStatus = ConnectStatus.Connecting;
    }
    public void OnConnectSuccess()
    {
        ConnectStatus = ConnectStatus.ConnectSuc;

        InitData();
    }
    public void OnConnectFailed(int errCode, string errMsg)
    {
        ConnectStatus = ConnectStatus.ConnectFailed;
        Debug.Log("Connect Failed", errCode, errMsg);
    }
    public void OnKickedOffline()
    {
        ConnectStatus = ConnectStatus.Offline;
    }
    public void OnUserTokenExpired()
    {
        ConnectStatus = ConnectStatus.TokenExpired;
    }
    public void InitData()
    {
        LoginUser = IMSDK.GetLoginUserId();
        LoginStatus = IMSDK.GetLoginStatus();
        IMSDK.GetSelfUserInfo((userInfo, errCode, errMsg) =>
        {
            if (userInfo != null)
            {
                user.SelfUserInfo = userInfo;
            }
            else
            {
                Debug.Log(errMsg);
            }
        });
        Friend.RefreshFriendList();
        Group.RefreshGroupList();
    }

    public void OnUserTokenInvalid(string errMsg)
    {
    }
}