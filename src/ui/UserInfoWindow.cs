using Dawn;
using Dawn.UI;
using IMDemo.Chat;
using ImGuiNET;
using OpenIM.IMSDK;
using OpenIMSDK = OpenIM.IMSDK.IMSDK;

namespace IMDemo.UI
{
    public class UserInfoWindow : ImGuiWindow
    {
        [MenuItem("User/UserInfo")]
        public static void ShowUserInfo()
        {
            GetWindow<UserInfoWindow>().Show("UserInfo");
        }

        UserInfo selfUserInfo = null;

        public override void OnEnable()
        {
            if (ChatMgr.Instance.currentUser != null)
            {
                OpenIMSDK.GetSelfUserInfo((userInfo, err, errMsg) =>
                {
                    if (userInfo != null)
                    {
                        selfUserInfo = userInfo;
                    }
                });
            }
        }

        public override void OnGUI()
        {
            if (selfUserInfo != null)
            {
                ImGui.Text(selfUserInfo.Nickname);
            }
        }
    }
}