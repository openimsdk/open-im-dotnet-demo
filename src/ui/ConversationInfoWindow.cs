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
        }
    }
}