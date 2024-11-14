using Dawn;
using Dawn.UI;
using ImGuiNET;
using OpenIM.IMSDK;
using OpenIMSDK = OpenIM.IMSDK.IMSDK;

namespace IMDemo.UI
{
    public class ConversationListWindow : ImGuiWindow
    {
        [MenuItem("Conversation/Conversation List")]
        public static void ShowConversationList()
        {
            GetWindow<ConversationListWindow>().Show("Conversation List");
        }

        List<Conversation> conversationList;
        public override void OnEnable()
        {
            RefreshConversationList();
        }
        public void RefreshConversationList()
        {
            OpenIMSDK.GetAllConversationList((list, errCode, errMsg) =>
            {
                if (list != null)
                {
                    conversationList = list;
                }
                else
                {
                    Debug.Error(errMsg);
                }
            });
        }
        public override void OnGUI()
        {
            if (conversationList == null) return;
            ImGui.BeginChild("TableContainer", new System.Numerics.Vector2(0, rect.h - 50), true, ImGuiWindowFlags.HorizontalScrollbar | ImGuiWindowFlags.AlwaysVerticalScrollbar);

            if (ImGui.BeginTable("GroupInfoTable", 6, ImGuiTableFlags.Borders | ImGuiTableFlags.RowBg | ImGuiTableFlags.ScrollX))
            {
                ImGui.TableSetupColumn("ShowName");
                ImGui.TableSetupColumn("FaceURL");
                ImGui.TableSetupColumn("UnreadCount");
                ImGui.TableSetupColumn("Chat");
                ImGui.TableSetupColumn("Delete");
                ImGui.TableSetupColumn("Detail");

                ImGui.TableHeadersRow();

                foreach (var conversation in conversationList)
                {
                    ImGui.TableNextRow();

                    ImGui.TableSetColumnIndex(0);
                    ImGui.Text(conversation.ShowName);

                    ImGui.TableSetColumnIndex(1);
                    ImGui.Text(conversation.FaceURL);

                    ImGui.TableSetColumnIndex(2);
                    ImGui.Text(conversation.UnreadCount.ToString());

                    ImGui.TableSetColumnIndex(3);
                    if (ImGui.Button("Chat"))
                    {
                        OnChatClick(conversation);
                    }

                    ImGui.TableSetColumnIndex(4);
                    if (ImGui.Button("Delete"))
                    {
                        OnDeleteClick(conversation);
                    }

                    ImGui.TableSetColumnIndex(5);
                    if (ImGui.Button("Detail"))
                    {
                        OnDetailClick(conversation);
                    }
                }

                ImGui.EndTable();
            }

            ImGui.EndChild();
        }

        void OnChatClick(Conversation conversation)
        {
            ChatWindow.ShowChatWindow(conversation);
        }
        void OnDeleteClick(Conversation conversation)
        {
            OpenIMSDK.DeleteConversationAndDeleteAllMsg((suc, err, errMsg) =>
            {
                if (suc)
                {
                    RefreshConversationList();
                }
                else
                {
                    Debug.Error(errMsg);
                }
            }, conversation.ConversationID);
        }
        void OnDetailClick(Conversation conversation)
        {

        }
    }
}