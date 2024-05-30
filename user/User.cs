using System;
using open_im_sdk;

public enum ConnectStatus
{
    Offline, TokenExpired, Connecting, ConnectSuc, ConnectFailed
}

public class User : IConnCallBack
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
    public LocalUser SelfUserInfo;
    public Conversation Conversation;
    public FriendShip Friend;
    public Group Group;
    public ConnectStatus ConnectStatus = ConnectStatus.Offline;

    public string LoginUser = "";
    public LoginStatus LoginStatus = LoginStatus.Empty;
    private User()
    {

    }

    public static open_im_sdk.PlatformID PlatformID
    {
        get
        {
#if WINDOWS
            return open_im_sdk.PlatformID.WindowsPlatformID;
#elif LINUX
            return open_im_sdk.PlatformID.LinuxPlatformID;
#elif MAC
            return open_im_sdk.PlatformID.OSXPlatformID;
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
            DataDir = Config.DataDir,
            LogLevel = Config.LogLevel,
            IsLogStandardOutput = Config.IsLogStandardOutput,
            LogFilePath = Config.LogFilePath,
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
        LoginUser = IMSDK.GetLoginUser();
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
}