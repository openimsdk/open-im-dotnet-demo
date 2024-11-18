using Dawn;
using Dawn.UI;
using IMDemo.Chat;
using ImGuiNET;
using OpenIM.IMSDK;
using OpenIMSDK = OpenIM.IMSDK.IMSDK;

namespace IMDemo.UI
{
    public class AboutWindow : ImGuiWindow
    {
        [MenuItem("Help/About")]
        public static void ShowAbout()
        {
            var window = GetWindow<AboutWindow>();
            window.Show("About", ImGuiWindowFlags.NoResize);
            var winW = 300;
            var winH = 300;
            var displaySize = ImGui.GetIO().DisplaySize;
            Debug.Log(displaySize.X, displaySize.Y);
            window.rect.x = (displaySize.X - winW) / 2;
            window.rect.y = (displaySize.Y - winH) / 2;
            Debug.Log(window.rect.x, window.rect.y);
            window.rect.w = winW;
            window.rect.h = winH;
        }

        public override void OnEnable()
        {
        }

        public override void OnGUI()
        {
            ImGui.Text("Open IM Dotnet SDK Version:1.0.4");
            ImGui.Text("Open IM SDK Core Version:v3.8.2-alpha.1");
            ImGui.Text("Open IM Server Version:3.8.2");
        }
    }
}