using open_im_sdk;
using open_im_sdk.listener;
public class FriendShip : IFriendShipListener
{
    public List<LocalFriend> FriendList;
    public FriendShip(User user)
    {
        FriendList = new List<LocalFriend>();
    }
    public void RefreshFriendList()
    {
        IMSDK.GetFriendList((list, errCode, errMsg) =>
       {
           if (list != null)
           {
               foreach (FullUserInfo fullUserInfo in list)
               {
                   FriendList.Add(fullUserInfo.FriendInfo);
               }
           }
           else
           {
               Debug.Log(errMsg);
           }
       });
    }
    public void AddFriends(List<LocalFriend> friends)
    {
        FriendList.AddRange(friends);
    }
    public void AddFriend(LocalFriend friend)
    {
        FriendList.Add(friend);
    }

    public void OnBlackAdded(LocalBlack blackInfo)
    {
    }

    public void OnBlackDeleted(LocalBlack blackInfo)
    {
    }

    public void OnFriendAdded(LocalFriend friendInfo)
    {
    }

    public void OnFriendApplicationAccepted(LocalFriendRequest friendApplication)
    {
    }

    public void OnFriendApplicationAdded(LocalFriendRequest friendApplication)
    {
    }

    public void OnFriendApplicationDeleted(LocalFriendRequest friendApplication)
    {
    }

    public void OnFriendApplicationRejected(LocalFriendRequest friendApplication)
    {
    }

    public void OnFriendDeleted(LocalFriend friendInfo)
    {

    }

    public void OnFriendInfoChanged(LocalFriend friendInfo)
    {

    }
}