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
            ImGui.Columns(2, "GroupInfoColumns", false);

            // GroupID
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("GroupID");
            ImGui.NextColumn();
            ImGui.Text(group.GroupID);
            ImGui.NextColumn();

            // GroupName
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("GroupName");
            ImGui.NextColumn();
            if (ImGui.InputText("groupName", ref group.GroupName, 100)) { }
            ImGui.NextColumn();

            // Notification
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("Notification");
            ImGui.NextColumn();
            if (ImGui.InputText("notification", ref group.Notification, 100)) { }
            ImGui.NextColumn();

            // Introduction
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("Introduction");
            ImGui.NextColumn();
            if (ImGui.InputText("introduction", ref group.Introduction, 100)) { }
            ImGui.NextColumn();

            // FaceURL
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("FaceURL");
            ImGui.NextColumn();
            if (ImGui.InputText("faceURL", ref group.FaceURL, 100)) { }
            ImGui.NextColumn();

            // CreateTime
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("CreateTime");
            ImGui.NextColumn();
            ImGui.Text($"{Time.GetTimeStampStr(group.CreateTime / 1000)}");
            ImGui.NextColumn();

            // Status
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("Status");
            ImGui.NextColumn();
            ImGui.Text($"{group.Status}");
            ImGui.NextColumn();

            // CreatorUserID
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("CreatorUserID");
            ImGui.NextColumn();
            ImGui.Text(group.CreatorUserID);
            ImGui.NextColumn();

            // GroupType
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("GroupType");
            ImGui.NextColumn();
            ImGui.Text($"{group.GroupType}");
            ImGui.NextColumn();

            // OwnerUserID
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("OwnerUserID");
            ImGui.NextColumn();
            ImGui.Text(group.OwnerUserID);
            ImGui.NextColumn();

            // MemberCount
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("MemberCount");
            ImGui.NextColumn();
            ImGui.Text($"{group.MemberCount}");
            ImGui.NextColumn();

            // Ex
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("Ex");
            ImGui.NextColumn();
            ImGui.Text(group.Ex);
            ImGui.NextColumn();

            // AttachedInfo
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("AttachedInfo");
            ImGui.NextColumn();
            ImGui.Text(group.AttachedInfo);
            ImGui.NextColumn();

            // NeedVerification
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("NeedVerification");
            ImGui.NextColumn();
            ImGui.Text($"{group.NeedVerification}");
            ImGui.NextColumn();

            // LookMemberInfo
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("LookMemberInfo");
            ImGui.NextColumn();
            ImGui.Text($"{group.LookMemberInfo}");
            ImGui.NextColumn();

            // ApplyMemberFriend
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("ApplyMemberFriend");
            ImGui.NextColumn();
            ImGui.Text($"{group.ApplyMemberFriend}");
            ImGui.NextColumn();

            // NotificationUpdateTime
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("NotificationUpdateTime");
            ImGui.NextColumn();
            ImGui.Text($"{group.NotificationUpdateTime}");
            ImGui.NextColumn();

            // NotificationUserID
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("NotificationUserID");
            ImGui.NextColumn();
            ImGui.Text(group.NotificationUserID);
            ImGui.NextColumn();

            ImGui.Columns(1); // Reset to 1 column layout

        }
    }
}