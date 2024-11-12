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
                ImGui.Columns(2, "UserInfoColumns", false);
                ImGui.SetColumnWidth(0, 150);

                ImGui.Text("UserId"); ImGui.NextColumn();
                ImGui.Text($"{selfUserInfo.UserID}"); ImGui.NextColumn();

                ImGui.Text("NickName"); ImGui.NextColumn();
                ImGui.Text($"{selfUserInfo.Nickname}"); ImGui.NextColumn();

                ImGui.Text("FaceUrl"); ImGui.NextColumn();
                ImGui.Text($"{selfUserInfo.FaceURL}"); ImGui.NextColumn();

                ImGui.Text("CreateTime"); ImGui.NextColumn();
                ImGui.Text($"{Time.GetTimeStampStr(selfUserInfo.CreateTime / 1000)}"); ImGui.NextColumn();

                ImGui.Text("AppManagerLevel"); ImGui.NextColumn();
                ImGui.Text($"{selfUserInfo.AppMangerLevel}"); ImGui.NextColumn();

                ImGui.Text("Ex"); ImGui.NextColumn();
                ImGui.Text($"{selfUserInfo.Ex}"); ImGui.NextColumn();

                ImGui.Text("AttachedInfo"); ImGui.NextColumn();
                ImGui.Text($"{selfUserInfo.AttachedInfo}"); ImGui.NextColumn();

                ImGui.Text("GlobalRecvMsgOpt"); ImGui.NextColumn();
                ImGui.Text($"{selfUserInfo.GlobalRecvMsgOpt}"); ImGui.NextColumn();

                ImGui.Columns(1);
            }
        }
    }
}