using Dawn;
using OpenIM.IMSDK;
using OpenIMSDK = OpenIM.IMSDK.IMSDK;

namespace IMDemo.Chat
{
    public class User
    {
        public string uid;
        public string token;
        public UserInfo selfUserInfo;
        public LoginStatus loginStatus = LoginStatus.Empty;
        ConversationListener conversationListener;
        FriendShipListener friendShipListener;
        GroupListener groupListener;
        public User(string uid, string token)
        {
            this.uid = uid;
            this.token = token;
            conversationListener = new ConversationListener(this);
            friendShipListener = new FriendShipListener(this);
            groupListener = new GroupListener(this);

            OpenIMSDK.SetConversationListener(conversationListener);
            OpenIMSDK.SetFriendShipListener(friendShipListener);
            OpenIMSDK.SetGroupListener(groupListener);
        }

        public void Login()
        {
            OpenIMSDK.Login(uid, token, (bool suc, int errCode, string errMsg) =>
            {
                if (suc)
                {
                    OnLoginSuc();
                }
                else
                {
                    Debug.Log(errCode, errMsg);
                }
            });
        }
        void OnLoginSuc()
        {
            loginStatus = OpenIMSDK.GetLoginStatus();
        }
    }
}

