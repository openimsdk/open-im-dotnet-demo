using Dawn;
using Dawn.UI;
using ImGuiNET;
using OpenIM.IMSDK;
using OpenIMSDK = OpenIM.IMSDK.IMSDK;

namespace IMDemo.UI
{
    public class ChatWindow : ImGuiWindow
    {
        public static void ShowChatWindow(Conversation conversation)
        {
            var window = GetWindow<ChatWindow>();
            window.conversation = conversation;
            window.Show("Chat");
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