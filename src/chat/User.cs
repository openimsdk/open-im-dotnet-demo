using Dawn;
using OpenIM.IMSDK;
using OpenIMSDK = OpenIM.IMSDK.IMSDK;

namespace IMDemo.Chat
{
    public class User
    {
        public string uid;
        public string token;
        public LoginStatus loginStatus = LoginStatus.Empty;
        public ConversationListener conversationListener;
        public FriendShipListener friendShipListener;
        public GroupListener groupListener;
        public MessageListener messageListener;
        public int totalUnreadCount;

        public User(string uid, string token)
        {
            this.uid = uid;
            this.token = token;
            conversationListener = new ConversationListener();
            friendShipListener = new FriendShipListener();
            groupListener = new GroupListener();
            messageListener = new MessageListener();

            OpenIMSDK.SetConversationListener(conversationListener);
            OpenIMSDK.SetFriendShipListener(friendShipListener);
            OpenIMSDK.SetGroupListener(groupListener);
            OpenIMSDK.SetBatchMsgListener(messageListener);
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
        public void Logout()
        {
            OpenIMSDK.Logout((bool suc, int errCode, string errMsg) =>
            {
                if (suc)
                {
                    Debug.Log($"{uid} Logout suc");
                    ChatMgr.Instance.currentUser = null;
                    ChatMgr.Application.Title = "IMDemo";
                }
                else
                {
                    Debug.Log(errCode, errMsg);
                }
            });
        }
        void OnLoginSuc()
        {
            uid = OpenIMSDK.GetLoginUserId();
            ChatMgr.Application.Title = "IMDemo-" + uid;
            loginStatus = OpenIMSDK.GetLoginStatus();
            OpenIMSDK.GetTotalUnreadMsgCount((count, err, errMsg) =>
            {
                if (err > 0)
                {
                    Debug.Error(errMsg);
                }
                else
                {
                    totalUnreadCount = count;
                }
            });
        }

        public static void TryLogin(string uid, string token)
        {
            if (ChatMgr.Instance.currentUser == null)
            {
                var user = new User(uid, token);
                user.Login();
                ChatMgr.Instance.currentUser = user;
            }
            else
            {
                if (ChatMgr.Instance.currentUser.uid != uid)
                {
                    Application.CreateNewInstance(uid, token);
                }
                else
                {
                    Debug.Log("Already Login");
                }
            }
        }
    }
}

