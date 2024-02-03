using open_im_sdk;
using open_im_sdk.listener;
public class Conversation : IConversationListener
{
    User user;
    List<LocalConversation> conversationList;
    public List<LocalConversation> ConversationList
    {
        get
        {
            return conversationList;
        }
    }

    public Conversation(User user)
    {
        this.user = user;
        conversationList = new List<LocalConversation>();
    }

    public void AddConversations(List<LocalConversation> list)
    {
        conversationList.AddRange(list);
    }

    public void AddConversation(LocalConversation conversation)
    {
        conversationList.Add(conversation);
    }

    public void OnConversationChanged(List<LocalConversation> conversationList)
    {
    }

    public void OnNewConversation(List<LocalConversation> conversationList)
    {
    }

    public void OnSyncServerFailed()
    {
    }

    public void OnSyncServerFinish()
    {
    }

    public void OnSyncServerStart()
    {
    }

    public void OnTotalUnreadMessageCountChanged(int totalUnreadCount)
    {
    }
}