using IMDemo.Chat;
using ImGuiNET;

namespace IMDemo.UI
{
    public static class StatusBar
    {
        public static void Draw()
        {
            ImGui.PushStyleColor(ImGuiCol.WindowBg, new System.Numerics.Vector4(0.1f, 0.1f, 0.1f, 1.0f));
            ImGui.PushStyleColor(ImGuiCol.Text, new System.Numerics.Vector4(1.0f, 1.0f, 1.0f, 1.0f)); // 白色

            ImGui.SetNextWindowSize(new System.Numerics.Vector2(ImGui.GetIO().DisplaySize.X, 30)); // 设置高度
            ImGui.SetNextWindowPos(new System.Numerics.Vector2(0, ImGui.GetIO().DisplaySize.Y - 30)); // 设置位置为底部

            ImGui.Begin("Status Bar", ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.AlwaysAutoResize | ImGuiWindowFlags.NoScrollbar);

            ImGui.Text(string.Format("Conn Status: {0}", ChatMgr.Instance.GetConnStatus()));

            if (ChatMgr.Instance.currentUser != null)
            {
                ImGui.SameLine();
                var user = ChatMgr.Instance.currentUser;
                ImGui.Text(string.Format("  {0}:{1}", user.uid, user.loginStatus));
            }

            // ImGui.SameLine();
            // ImGui.Text("FPS: " + (1.0f / ImGui.GetIO().DeltaTime).ToString("F0"));

            ImGui.End();

            // 恢复样式
            ImGui.PopStyleColor(2); // 恢复窗口背景色和文本颜色
        }
    }

}