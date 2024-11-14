using Dawn;
using Dawn.UI;
using IMDemo.Chat;
using ImGuiNET;
using OpenIM.IMSDK;
using OpenIMSDK = OpenIM.IMSDK.IMSDK;

namespace IMDemo.UI
{
    public class FriendListWindow : ImGuiWindow
    {
        [MenuItem("Friend/Friend List")]
        public static void ShowFriendInfo()
        {
            GetWindow<FriendListWindow>().Show("Friend List");
        }

        List<FriendInfo> friendList;

        public override void OnEnable()
        {
            RefreshFriendList();
        }

        void RefreshFriendList()
        {
            OpenIMSDK.GetFriendList((list, errCode, errMsg) =>
           {
               if (list != null)
               {
                   friendList = list;
               }
           }, true);
        }

        public override void OnGUI()
        {
            if (friendList == null) return;

            ImGui.BeginChild("TableContainer", new System.Numerics.Vector2(0, rect.h - 50), true, ImGuiWindowFlags.HorizontalScrollbar | ImGuiWindowFlags.AlwaysVerticalScrollbar);

            if (ImGui.BeginTable("FriendInfoTable", 5, ImGuiTableFlags.Borders | ImGuiTableFlags.RowBg | ImGuiTableFlags.ScrollX))
            {
                ImGui.TableSetupColumn("Nickname");
                ImGui.TableSetupColumn("FaceURL");
                ImGui.TableSetupColumn("Chat");
                ImGui.TableSetupColumn("Delete");
                ImGui.TableSetupColumn("Detail");

                ImGui.TableHeadersRow();

                foreach (var friend in friendList)
                {
                    ImGui.TableNextRow();

                    ImGui.TableSetColumnIndex(0);
                    ImGui.Text(friend.Nickname);

                    ImGui.TableSetColumnIndex(1);
                    ImGui.Text(friend.FaceURL);

                    ImGui.TableSetColumnIndex(2);
                    if (ImGui.Button("Chat"))
                    {
                        OnChatClick(friend);
                    }

                    ImGui.TableSetColumnIndex(3);
                    if (ImGui.Button("Delete"))
                    {
                        OnDeleteClick(friend);
                    }

                    ImGui.TableSetColumnIndex(4);
                    if (ImGui.Button("Detail"))
                    {
                        OnDetailClick(friend);
                    }
                }

                ImGui.EndTable();
            }

            ImGui.EndChild();
        }

        void OnChatClick(FriendInfo friend)
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
            }, ConversationType.Single, friend.FriendUserID);
        }
        void OnDeleteClick(FriendInfo friend)
        {
            OpenIMSDK.DeleteFriend((suc, err, errMsg) =>
            {
                if (suc)
                {
                    RefreshFriendList();
                }
                else
                {
                    Debug.Error(errMsg);
                }
            }, friend.FriendUserID);
        }
        void OnDetailClick(FriendInfo friend)
        {

        }
    }
}