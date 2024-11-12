using Dawn;
using Dawn.UI;
using IMDemo.Chat;
using ImGuiNET;
using OpenIM.IMSDK;
using OpenIMSDK = OpenIM.IMSDK.IMSDK;

namespace IMDemo.UI
{
    public class GroupInfoWindow : ImGuiWindow
    {
        [MenuItem("Group/Group Info")]
        public static void ShowGroupInfo()
        {
            GetWindow<GroupInfoWindow>().Show("Group List");
        }

        List<GroupInfo> groupList;
        public override void OnEnable()
        {
            OpenIMSDK.GetJoinedGroupList((list, errCode, errMsg) =>
            {
                if (list != null)
                {
                    groupList = list;
                }
            });
        }

        public override void OnGUI()
        {
            if (groupList == null) return;
            ImGui.BeginChild("TableContainer", new System.Numerics.Vector2(0, rect.h - 50), true, ImGuiWindowFlags.HorizontalScrollbar | ImGuiWindowFlags.AlwaysVerticalScrollbar);

            if (ImGui.BeginTable("GroupInfoTable", 18, ImGuiTableFlags.Borders | ImGuiTableFlags.RowBg | ImGuiTableFlags.ScrollX))
            {
                ImGui.TableSetupColumn("GroupID");
                ImGui.TableSetupColumn("GroupName");
                ImGui.TableSetupColumn("Notification");
                ImGui.TableSetupColumn("Introduction");
                ImGui.TableSetupColumn("FaceURL");
                ImGui.TableSetupColumn("CreateTime");
                ImGui.TableSetupColumn("Status");
                ImGui.TableSetupColumn("CreatorUserID");
                ImGui.TableSetupColumn("GroupType");
                ImGui.TableSetupColumn("OwnerUserID");
                ImGui.TableSetupColumn("MemberCount");
                ImGui.TableSetupColumn("Ex");
                ImGui.TableSetupColumn("AttachedInfo");
                ImGui.TableSetupColumn("NeedVerification");
                ImGui.TableSetupColumn("LookMemberInfo");
                ImGui.TableSetupColumn("ApplyMemberFriend");
                ImGui.TableSetupColumn("NotificationUpdateTime");
                ImGui.TableSetupColumn("NotificationUserID");

                ImGui.TableHeadersRow();

                foreach (var group in groupList)
                {
                    ImGui.TableNextRow();

                    ImGui.TableSetColumnIndex(0);
                    ImGui.Text(group.GroupID ?? "");

                    ImGui.TableSetColumnIndex(1);
                    ImGui.Text(group.GroupName ?? "");

                    ImGui.TableSetColumnIndex(2);
                    ImGui.Text(group.Notification ?? "");

                    ImGui.TableSetColumnIndex(3);
                    ImGui.Text(group.Introduction ?? "");

                    ImGui.TableSetColumnIndex(4);
                    ImGui.Text(group.FaceURL ?? "");

                    ImGui.TableSetColumnIndex(5);
                    ImGui.Text(Time.GetTimeStampStr(group.CreateTime / 1000)); // 转换 CreateTime

                    ImGui.TableSetColumnIndex(6);
                    ImGui.Text(group.Status.ToString());

                    ImGui.TableSetColumnIndex(7);
                    ImGui.Text(group.CreatorUserID ?? "");

                    ImGui.TableSetColumnIndex(8);
                    ImGui.Text(group.GroupType.ToString());

                    ImGui.TableSetColumnIndex(9);
                    ImGui.Text(group.OwnerUserID ?? "");

                    ImGui.TableSetColumnIndex(10);
                    ImGui.Text(group.MemberCount.ToString());

                    ImGui.TableSetColumnIndex(11);
                    ImGui.Text(group.Ex.ToString());

                    ImGui.TableSetColumnIndex(12);
                    ImGui.Text(group.AttachedInfo.ToString());

                    ImGui.TableSetColumnIndex(13);
                    ImGui.Text(group.NeedVerification.ToString());

                    ImGui.TableSetColumnIndex(14);
                    ImGui.Text(group.LookMemberInfo.ToString());

                    ImGui.TableSetColumnIndex(15);
                    ImGui.Text(group.ApplyMemberFriend.ToString());

                    ImGui.TableSetColumnIndex(16);
                    ImGui.Text(group.NotificationUpdateTime.ToString());

                    ImGui.TableSetColumnIndex(17);
                    ImGui.Text(group.NotificationUserID.ToString());
                }

                ImGui.EndTable();
            }

            ImGui.EndChild();
        }
    }
}