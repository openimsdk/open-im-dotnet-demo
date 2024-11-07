using OpenIM.IMSDK;
using OpenIM.IMSDK.Listener;
public class FriendShip : IFriendShipListener
{
    public List<FriendInfo> FriendList;
    public FriendShip(User user)
    {
        FriendList = new List<FriendInfo>();
    }
    public void RefreshFriendList()
    {
        IMSDK.GetFriendList((list, errCode, errMsg) =>
        {
            if (list != null)
            {
                foreach (FriendInfo friend in list)
                {
                    FriendList.Add(friend);
                }
            }
            else
            {
                Debug.Log(errMsg);
            }
        }, true);
    }
    public void AddFriends(List<FriendInfo> friends)
    {
        FriendList.AddRange(friends);
    }
    public void AddFriend(FriendInfo friend)
    {
        FriendList.Add(friend);
    }

    public void OnBlackAdded(BlackInfo blackInfo)
    {
    }

    public void OnBlackDeleted(BlackInfo blackInfo)
    {
    }

    public void OnFriendAdded(FriendInfo friendInfo)
    {
    }

    public void OnFriendDeleted(FriendInfo friendInfo)
    {

    }

    public void OnFriendInfoChanged(FriendInfo friendInfo)
    {

    }

    public void OnFriendApplicationAdded(FriendApplicationInfo friendApplication)
    {
    }

    public void OnFriendApplicationDeleted(FriendApplicationInfo friendApplication)
    {
    }

    public void OnFriendApplicationAccepted(FriendApplicationInfo friendApplication)
    {
    }

    public void OnFriendApplicationRejected(FriendApplicationInfo friendApplication)
    {
    }
}