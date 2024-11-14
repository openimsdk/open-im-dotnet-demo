using IMDemo.Chat;
using ImGuiNET;

namespace IMDemo.UI
{
    public static class StatusBar
    {
        public static void Draw()
        {
            ImGui.PushStyleColor(ImGuiCol.WindowBg, new System.Numerics.Vector4(0.1f, 0.1f, 0.1f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.Text, new System.Numerics.Vector4(1.0f, 1.0f, 1.0f, 1.0f));

            ImGui.SetNextWindowSize(new System.Numerics.Vector2(ImGui.GetIO().DisplaySize.X, 30));
            ImGui.SetNextWindowPos(new System.Numerics.Vector2(0, ImGui.GetIO().DisplaySize.Y - 30));

            ImGui.Begin("Status Bar", ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.AlwaysAutoResize | ImGuiWindowFlags.NoScrollbar);

            ImGui.Text(string.Format("Conn Status: {0}", ChatMgr.Instance.GetConnStatus()));

            if (ChatMgr.Instance.currentUser != null)
            {
                ImGui.SameLine();
                var user = ChatMgr.Instance.currentUser;
                ImGui.Text(string.Format("  {0}:{1}", user.uid, user.loginStatus));

                ImGui.SameLine();
                ImGui.Text(string.Format("  {0}:{1}", "TotalUnReadCount", user.totalUnreadCount));
            }

            ImGui.End();

            ImGui.PopStyleColor(2);
        }
    }

}