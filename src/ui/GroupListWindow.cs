using Dawn;
using Dawn.UI;
using ImGuiNET;
using OpenIM.IMSDK;
using OpenIMSDK = OpenIM.IMSDK.IMSDK;

namespace IMDemo.UI
{
    public class GroupListWindow : ImGuiWindow
    {
        [MenuItem("Group/Group List")]
        public static void ShowGroupList()
        {
            GetWindow<GroupListWindow>().Show("Group List");
        }

        List<GroupInfo> groupList;
        public override void OnEnable()
        {
            RefreshGroupList();
        }
        void RefreshGroupList()
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

            if (ImGui.BeginTable("GroupListTable", 6, ImGuiTableFlags.Borders | ImGuiTableFlags.RowBg | ImGuiTableFlags.ScrollX))
            {
                ImGui.TableSetupColumn("GroupName");
                ImGui.TableSetupColumn("FaceURL");
                ImGui.TableSetupColumn("MemberCount");
                ImGui.TableSetupColumn("Chat");
                ImGui.TableSetupColumn("Delete");
                ImGui.TableSetupColumn("Detail");

                ImGui.TableHeadersRow();

                foreach (var group in groupList)
                {
                    ImGui.TableNextRow();

                    ImGui.TableSetColumnIndex(0);
                    ImGui.Text(group.GroupName);

                    ImGui.TableSetColumnIndex(1);
                    ImGui.Text(group.FaceURL);

                    ImGui.TableSetColumnIndex(2);
                    ImGui.Text(group.MemberCount.ToString());

                    ImGui.TableSetColumnIndex(3);
                    if (ImGui.Button("Chat"))
                    {
                        OnChatClick(group);
                    }
                    ImGui.TableSetColumnIndex(4);
                    if (ImGui.Button("Delete"))
                    {
                        OnDeleteClick(group);
                    }
                    ImGui.TableSetColumnIndex(5);
                    if (ImGui.Button("Detail"))
                    {
                        OnDetailClick(group);
                    }
                }

                ImGui.EndTable();
            }

            ImGui.EndChild();
        }

        void OnChatClick(GroupInfo group)
        {
            OpenIMSDK.GetOneConversation((converstion, err, errMsg) =>
            {
                if (converstion != null)
                {
                    ChatWindow.ShowChatWindow(converstion);
                }
                else
                {
                    Debug.Error(errMsg);
                }
            }, ConversationType.Group, group.GroupID);
        }
        void OnDetailClick(GroupInfo group)
        {
            GroupInfoWindow.ShowGroupInfo(group);
        }
        void OnDeleteClick(GroupInfo group)
        {
            if (group.OwnerUserID == OpenIMSDK.GetLoginUserId())
            {
                OpenIMSDK.DismissGroup((suc, err, errMsg) =>
                {
                    if (suc)
                    {
                        RefreshGroupList();
                    }
                    else
                    {
                        Debug.Error(errMsg);
                    }
                }, group.GroupID);
            }
            else
            {
                OpenIMSDK.QuitGroup((suc, err, errMsg) =>
                {
                    if (suc)
                    {
                        RefreshGroupList();
                    }
                    else
                    {
                        Debug.Error(errMsg);
                    }
                }, group.GroupID);
            }
        }
    }
}