using Dawn;
using OpenIM.IMSDK;
using OpenIM.IMSDK.Listener;
using OpenIMSDK = OpenIM.IMSDK.IMSDK;

namespace IMDemo.Chat
{
    public class GroupListener : IGroupListener
    {
        public GroupListener()
        {
        }

        public void OnGroupApplicationAccepted(GroupApplicationInfo groupApplication)
        {
            throw new NotImplementedException();
        }

        public void OnGroupApplicationAdded(GroupApplicationInfo groupApplication)
        {
            throw new NotImplementedException();
        }

        public void OnGroupApplicationDeleted(GroupApplicationInfo groupApplication)
        {
        }

        public void OnGroupApplicationRejected(GroupApplicationInfo groupApplication)
        {
        }

        public void OnGroupDismissed(GroupInfo groupInfo)
        {
        }

        public void OnGroupInfoChanged(GroupInfo groupInfo)
        {
        }

        public void OnGroupMemberAdded(GroupMember groupMemberInfo)
        {
        }

        public void OnGroupMemberDeleted(GroupMember groupMemberInfo)
        {
        }

        public void OnGroupMemberInfoChanged(GroupMember groupMemberInfo)
        {
        }

        public void OnJoinedGroupAdded(GroupInfo groupInfo)
        {
        }

        public void OnJoinedGroupDeleted(GroupInfo groupInfo)
        {
        }
    }
}

