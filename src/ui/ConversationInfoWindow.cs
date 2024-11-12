using Dawn;
using Dawn.UI;
using IMDemo.Chat;
using ImGuiNET;
using OpenIM.IMSDK;
using OpenIMSDK = OpenIM.IMSDK.IMSDK;

namespace IMDemo.UI
{
    public class ConversationInfoWindow : ImGuiWindow
    {
        [MenuItem("Conversation/Conversation Info")]
        public static void ShowConversationInfo()
        {
            GetWindow<ConversationInfoWindow>().Show("Conversation List");
        }


        List<Conversation> conversationList;
        public override void OnEnable()
        {
            OpenIMSDK.GetAllConversationList((list, errCode, errMsg) =>
            {
                if (list != null)
                {
                    conversationList = list;
                }
            });
        }
        public override void OnGUI()
        {
            if (conversationList == null) return;
            ImGui.BeginChild("TableContainer", new System.Numerics.Vector2(0, rect.h - 50), true, ImGuiWindowFlags.HorizontalScrollbar | ImGuiWindowFlags.AlwaysVerticalScrollbar);

            if (ImGui.BeginTable("GroupInfoTable", 8, ImGuiTableFlags.Borders | ImGuiTableFlags.RowBg | ImGuiTableFlags.ScrollX))
            {
                ImGui.TableSetupColumn("ConversationID");
                ImGui.TableSetupColumn("ConversationType");
                ImGui.TableSetupColumn("UserID");
                ImGui.TableSetupColumn("GroupID");
                ImGui.TableSetupColumn("ShowName");
                ImGui.TableSetupColumn("FaceURL");
                ImGui.TableSetupColumn("UnreadCount");
                ImGui.TableSetupColumn("GroupAtType");

                ImGui.TableHeadersRow();

                foreach (var conversation in conversationList)
                {
                    ImGui.TableNextRow();

                    ImGui.TableSetColumnIndex(0);
                    ImGui.Text(conversation.ConversationID);

                    ImGui.TableSetColumnIndex(1);
                    ImGui.Text(conversation.ConversationType.ToString());

                    ImGui.TableSetColumnIndex(2);
                    ImGui.Text(conversation.UserID);

                    ImGui.TableSetColumnIndex(3);
                    ImGui.Text(conversation.GroupID);

                    ImGui.TableSetColumnIndex(4);
                    ImGui.Text(conversation.ShowName);

                    ImGui.TableSetColumnIndex(5);
                    ImGui.Text(conversation.FaceURL);

                    ImGui.TableSetColumnIndex(6);
                    ImGui.Text(conversation.UnreadCount.ToString());

                    ImGui.TableSetColumnIndex(7);
                    ImGui.Text(conversation.GroupAtType.ToString());
                }

                ImGui.EndTable();
            }

            ImGui.EndChild();
        }
    }
}