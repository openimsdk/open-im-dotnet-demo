using OpenIM.IMSDK.Listener;

namespace IMDemo.Chat
{
    public enum ConnectStatus
    {
        Offline, TokenExpired, Connecting, ConnectSuc, ConnectFailed, UserTokenInvalid
    }
    public class ConnListener : IConnListener
    {
        public ConnectStatus connectStatus = ConnectStatus.Offline;
        public void OnConnecting()
        {
            connectStatus = ConnectStatus.Connecting;
        }
        public void OnConnectSuccess()
        {
            connectStatus = ConnectStatus.ConnectSuc;
        }
        public void OnConnectFailed(int errCode, string errMsg)
        {
            connectStatus = ConnectStatus.ConnectFailed;
        }
        public void OnKickedOffline()
        {
            connectStatus = ConnectStatus.Offline;
        }
        public void OnUserTokenExpired()
        {
            connectStatus = ConnectStatus.TokenExpired;
        }

        public void OnUserTokenInvalid(string errMsg)
        {
            connectStatus = ConnectStatus.UserTokenInvalid;
        }
    }
}