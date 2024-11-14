using Dawn;
using Dawn.UI;
using IMDemo.Chat;
using ImGuiNET;
using OpenIM.IMSDK;
using OpenIMSDK = OpenIM.IMSDK.IMSDK;

namespace IMDemo.UI
{
    public class FriendInfoWindow : ImGuiWindow
    {
        public static void ShowFriendInfo(FriendInfo friend)
        {
            var window = GetWindow<FriendInfoWindow>();
            window.friend = friend;
            window.Show("Friend");
        }
        public FriendInfo friend;

        public override void OnEnable()
        {
        }

        public override void OnGUI()
        {
            if (friend == null) return;

        }
    }
}