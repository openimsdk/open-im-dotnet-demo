using Dawn;
using OpenIM.IMSDK;
using OpenIM.IMSDK.Listener;
using OpenIMSDK = OpenIM.IMSDK.IMSDK;

namespace IMDemo.Chat
{
    public class MessageListener : IBatchMsgListener
    {
        public event Action<List<Message>> Event_OnRecvNewMessages;
        public MessageListener()
        {
        }

        public void OnRecvNewMessages(List<Message> messageList)
        {
            Event_OnRecvNewMessages?.Invoke(messageList);
        }

        public void OnRecvOfflineNewMessages(List<Message> messageList)
        {

        }
    }
}
