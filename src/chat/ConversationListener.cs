using Dawn;
using OpenIM.IMSDK;
using OpenIM.IMSDK.Listener;
using OpenIMSDK = OpenIM.IMSDK.IMSDK;

namespace IMDemo.Chat
{
    public class ConversationListener : IConversationListener
    {
        public ConversationListener()
        {
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

        public void OnSyncServerFinish()
        {
        }
    }
}
