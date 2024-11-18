using Dawn;
using Dawn.UI;
using ImGuiNET;
using OpenIM.IMSDK;
using OpenIMSDK = OpenIM.IMSDK.IMSDK;

namespace IMDemo.UI
{
    public class ConversationInfoWindow : ImGuiWindow
    {
        public static void ShowConversationInfo(Conversation conversation)
        {
            var window = GetWindow<ConversationInfoWindow>();
            window.conversation = conversation;
            window.Show("Conversation");
        }

        public Conversation conversation;
        public override void OnEnable()
        {
        }

        public override void OnGUI()
        {
            if (conversation == null) return;
            ImGui.Columns(2, "ConversationInfoColumns", false);

            // ConversationID
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("ConversationID");
            ImGui.NextColumn();
            ImGui.Text(conversation.ConversationID);
            ImGui.NextColumn();

            // ConversationType
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("ConversationType");
            ImGui.NextColumn();
            ImGui.Text($"{conversation.ConversationType}");
            ImGui.NextColumn();

            // UserID
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("UserID");
            ImGui.NextColumn();
            ImGui.Text(conversation.UserID);
            ImGui.NextColumn();

            // GroupID
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("GroupID");
            ImGui.NextColumn();
            ImGui.Text(conversation.GroupID);
            ImGui.NextColumn();

            // ShowName
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("ShowName");
            ImGui.NextColumn();
            ImGui.Text(conversation.ShowName);
            ImGui.NextColumn();

            // FaceURL
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("FaceURL");
            ImGui.NextColumn();
            ImGui.Text(conversation.FaceURL);
            ImGui.NextColumn();

            // RecvMsgOpt
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("RecvMsgOpt");
            ImGui.NextColumn();
            ImGui.Text($"{conversation.RecvMsgOpt}");
            ImGui.NextColumn();

            // UnreadCount
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("UnreadCount");
            ImGui.NextColumn();
            ImGui.Text($"{conversation.UnreadCount}");
            ImGui.NextColumn();

            // GroupAtType
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("GroupAtType");
            ImGui.NextColumn();
            ImGui.Text($"{conversation.GroupAtType}");
            ImGui.NextColumn();

            // LatestMsg
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("LatestMsg");
            ImGui.NextColumn();
            ImGui.Text(conversation.LatestMsg);
            ImGui.NextColumn();

            // LatestMsgSendTime
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("LatestMsgSendTime");
            ImGui.NextColumn();
            ImGui.Text($"{conversation.LatestMsgSendTime}");
            ImGui.NextColumn();

            // DraftText
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("DraftText");
            ImGui.NextColumn();
            if (ImGui.InputText("draftText", ref conversation.DraftText, 100)) { }
            ImGui.NextColumn();

            // DraftTextTime
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("DraftTextTime");
            ImGui.NextColumn();
            ImGui.Text($"{conversation.DraftTextTime}");
            ImGui.NextColumn();

            // IsPinned
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("IsPinned");
            ImGui.NextColumn();
            ImGui.Text(conversation.IsPinned.ToString());
            ImGui.NextColumn();

            // IsPrivateChat
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("IsPrivateChat");
            ImGui.NextColumn();
            ImGui.Text(conversation.IsPrivateChat.ToString());
            ImGui.NextColumn();

            // BurnDuration
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("BurnDuration");
            ImGui.NextColumn();
            ImGui.Text($"{conversation.BurnDuration}");
            ImGui.NextColumn();

            // IsNotInGroup
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("IsNotInGroup");
            ImGui.NextColumn();
            ImGui.Text(conversation.IsNotInGroup.ToString());
            ImGui.NextColumn();

            // UpdateUnreadCountTime
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("UpdateUnreadCountTime");
            ImGui.NextColumn();
            ImGui.Text($"{conversation.UpdateUnreadCountTime}");
            ImGui.NextColumn();

            // AttachedInfo
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("AttachedInfo");
            ImGui.NextColumn();
            ImGui.Text(conversation.AttachedInfo);
            ImGui.NextColumn();

            // Ex
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("Ex");
            ImGui.NextColumn();
            ImGui.Text(conversation.Ex);
            ImGui.NextColumn();

            // MaxSeq
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("MaxSeq");
            ImGui.NextColumn();
            ImGui.Text($"{conversation.MaxSeq}");
            ImGui.NextColumn();

            // MinSeq
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("MinSeq");
            ImGui.NextColumn();
            ImGui.Text($"{conversation.MinSeq}");
            ImGui.NextColumn();

            // HasReadSeq
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("HasReadSeq");
            ImGui.NextColumn();
            ImGui.Text($"{conversation.HasReadSeq}");
            ImGui.NextColumn();

            // MsgDestructTime
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("MsgDestructTime");
            ImGui.NextColumn();
            ImGui.Text($"{conversation.MsgDestructTime}");
            ImGui.NextColumn();

            // IsMsgDestruct
            ImGui.SetColumnWidth(0, 150);
            ImGui.Text("IsMsgDestruct");
            ImGui.NextColumn();
            ImGui.Text(conversation.IsMsgDestruct.ToString());
            ImGui.NextColumn();

            ImGui.Columns(1); // Reset to 1 column layout

        }
    }
}