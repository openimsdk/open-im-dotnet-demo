using Dawn;
using Dawn.UI;
using ImGuiNET;
using OpenIM.IMSDK;
using OpenIMSDK = OpenIM.IMSDK.IMSDK;

namespace IMDemo.UI
{
    public class GroupInfoWindow : ImGuiWindow
    {
        public static void ShowGroupInfo(GroupInfo group)
        {
            var window = GetWindow<GroupInfoWindow>();
            window.group = group;
            window.Show("Group Info");
        }

        public GroupInfo group;

        public override void OnEnable()
        {
        }

        public override void OnGUI()
        {
            if (group == null) return;
        }
    }
}