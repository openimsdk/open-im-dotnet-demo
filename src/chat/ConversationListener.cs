using Dawn;
using OpenIM.IMSDK;
using OpenIM.IMSDK.Listener;
using OpenIMSDK = OpenIM.IMSDK.IMSDK;

namespace IMDemo.Chat
{
    public class ConversationListener : IConversationListener
    {
        User user;
        List<OpenIM.IMSDK.Conversation> conversationList;
        public List<OpenIM.IMSDK.Conversation> ConversationList
        {
            get
            {
                return conversationList;
            }
        }

        public ConversationListener(User user)
        {
            this.user = user;
            conversationList = new List<OpenIM.IMSDK.Conversation>();
        }

        public void OnConversationChanged(List<Conversation> conversationList)
        {
        }

        public void OnNewConversation(List<Conversation> conversationList)
        {
        }

        public void OnSyncServerFailed()
        {
        }

        public void OnSyncServerFinish()
        {
            OpenIMSDK.GetAllConversationList((list, errCode, errMsg) =>
            {
                if (list != null)
                {
                    conversationList.AddRange(list);
                }
                else
                {
                    Debug.Log(errCode, errMsg);
                }
            });
        }

        public void OnSyncServerStart()
        {
        }

        public void OnTotalUnreadMessageCountChanged(int totalUnreadCount)
        {
        }

        public void OnConversationUserInputStatusChanged(InputStatesChangedData data)
        {
        }

        public void OnSyncServerProgress(int progress)
        {
        }
    }
}
