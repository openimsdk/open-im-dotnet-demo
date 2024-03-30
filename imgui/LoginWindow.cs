using System.Numerics;
using System.Text;
using ImGuiNET;
using open_im_sdk;

public class LoginWindow : ImGuiWindow
{
    Vector4 bgColor;
    byte[] userId = new byte[128];
    byte[] userToken = new byte[256];
    public LoginWindow(string title, Rect position) : base(title, position)
    {
        bgColor = new Vector4(0.5f, 0.5f, 0.5f, 1);
        var user = "yejian001";
        var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySUQiOiJ5ZWppYW4wMDEiLCJQbGF0Zm9ybUlEIjozLCJleHAiOjE3MTYwNDA1NjMsIm5iZiI6MTcwODI2NDI2MywiaWF0IjoxNzA4MjY0NTYzfQ.Qu_tjWfYCAYyZ3lxrZaBisp2VlXWJo9knBNcRS0UygI";
        Buffer.BlockCopy(Encoding.ASCII.GetBytes(user), 0, userId, 0, user.Length);
        Buffer.BlockCopy(Encoding.ASCII.GetBytes(token), 0, userToken, 0, token.Length);
    }
    public override void OnDraw()
    {
        var user = User.Instance;
        ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 5);
        // ImGui.PushStyleColor(ImGuiCol.WindowBg, bgColor);
        ImGui.SetNextWindowPos(new Vector2(position.x, position.y));
        ImGui.SetNextWindowSize(new Vector2(position.w, position.h), ImGuiCond.Always);
        ImGui.Begin(title, ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoResize);
        ImGui.SetCursorPosX(position.w / 2);
        ImGui.Text("Login");
        // ImGui.PushItemWidth();
        if (ImGui.InputText("UserID", userId, 128, ImGuiInputTextFlags.None))
        {
        }
        if (ImGui.InputText("Token", userToken, 256, ImGuiInputTextFlags.None))
        {
        }
        ImGui.Spacing();
        ImGui.Spacing();
        ImGui.Spacing();
        ImGui.SetCursorPosX(position.w / 2 - 50);
        if (ImGui.Button("Login"))
        {
            string id = Encoding.UTF8.GetString(userId).TrimEnd('\0');
            string token = Encoding.UTF8.GetString(userToken).TrimEnd('\0');
            if (id == null || token == null)
            {
                return;
            }
            if (id == "" || token == "")
            {
                return;
            }
            User.Instance.Login(id, token);
        }
        if (user.ConnectStatus == ConnectStatus.Connecting)
        {
            ImGui.Text("connecting");
        }
        else if (user.ConnectStatus == ConnectStatus.TokenExpired)
        {
            ImGui.Text("TokenExired");
        }
        else if (user.ConnectStatus == ConnectStatus.ConnectFailed)
        {
            ImGui.Text("ConnectFailed");
        }
        ImGui.End();
        ImGui.PopStyleVar();
    }

}