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
        Conversation conversation;
        FriendShip friend;
        Group group;
        public User(string uid, string token)
        {
            this.uid = uid;
            this.token = token;
            conversation = new Conversation(this);
            friend = new FriendShip(this);
            group = new Group(this);

            OpenIMSDK.SetConversationListener(conversation);
            OpenIMSDK.SetFriendShipListener(friend);
            OpenIMSDK.SetGroupListener(group);
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

