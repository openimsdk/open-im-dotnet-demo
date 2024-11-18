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
            ImGui.Columns(2, "FriendInfoColumns", false);

            // OwnerUserID
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("OwnerUserID");
            ImGui.NextColumn();
            ImGui.Text(friend.OwnerUserID);
            ImGui.NextColumn();

            // FriendUserID
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("FriendUserID");
            ImGui.NextColumn();
            ImGui.Text(friend.FriendUserID);
            ImGui.NextColumn();

            // Remark
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("Remark");
            ImGui.NextColumn();
            if (ImGui.InputText("remark", ref friend.Remark, 100)) { }
            ImGui.NextColumn();

            // CreateTime
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("CreateTime");
            ImGui.NextColumn();
            ImGui.Text($"{Time.GetTimeStampStr(friend.CreateTime / 1000)}");
            ImGui.NextColumn();

            // AddSource
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("AddSource");
            ImGui.NextColumn();
            ImGui.Text($"{friend.AddSource}");
            ImGui.NextColumn();

            // OperatorUserID
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("OperatorUserID");
            ImGui.NextColumn();
            ImGui.Text(friend.OperatorUserID);
            ImGui.NextColumn();

            // Nickname
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("Nickname");
            ImGui.NextColumn();
            if (ImGui.InputText("nickname", ref friend.Nickname, 100)) { }
            ImGui.NextColumn();

            // FaceURL
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("FaceURL");
            ImGui.NextColumn();
            if (ImGui.InputText("faceURL", ref friend.FaceURL, 100)) { }
            ImGui.NextColumn();

            // Ex
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("Ex");
            ImGui.NextColumn();
            ImGui.Text(friend.Ex);
            ImGui.NextColumn();

            // AttachedInfo
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("AttachedInfo");
            ImGui.NextColumn();
            ImGui.Text(friend.AttachedInfo);
            ImGui.NextColumn();

            // IsPinned
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("IsPinned");
            ImGui.NextColumn();
            ImGui.Text(friend.IsPinned.ToString());
            ImGui.NextColumn();

            ImGui.Columns(1); // Reset to 1 column layout

        }
    }
}