using open_im_sdk;
using open_im_sdk.listener;

public class Group : IGroupListener
{

    public List<LocalGroup> GroupList;
    public Group(User user)
    {
        GroupList = new List<LocalGroup>();
    }

    public void AddGroups(List<LocalGroup> groups)
    {
        GroupList.AddRange(groups);
    }
    public void AddGroup(LocalGroup group)
    {
        GroupList.Add(group);
    }

    public void OnGroupApplicationAccepted(LocalGroupRequest groupApplication)
    {
    }

    public void OnGroupApplicationAdded(LocalGroupRequest groupApplication)
    {
    }

    public void OnGroupApplicationDeleted(LocalGroupRequest groupApplication)
    {
    }

    public void OnGroupApplicationRejected(LocalGroupRequest groupApplication)
    {
    }

    public void OnGroupDismissed(LocalGroup groupInfo)
    {
    }

    public void OnGroupInfoChanged(LocalGroup groupInfo)
    {
    }

    public void OnGroupMemberAdded(LocalGroupMember groupMemberInfo)
    {
    }

    public void OnGroupMemberDeleted(LocalGroupMember groupMemberInfo)
    {
    }

    public void OnGroupMemberInfoChanged(LocalGroupMember groupMemberInfo)
    {
    }

    public void OnJoinedGroupAdded(LocalGroup groupInfo)
    {
    }

    public void OnJoinedGroupDeleted(LocalGroup groupInfo)
    {
    }
}