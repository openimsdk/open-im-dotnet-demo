using System.Numerics;
using System.Text;
using ImGuiNET;
using open_im_sdk;

public class LoginWindow : ImGuiWindow
{
    byte[] userId = new byte[128];
    byte[] userToken = new byte[256];
    public LoginWindow(string title, Rect position) : base(title, position)
    {
        var user = "yejian";
        var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySUQiOiJ5ZWppYW4iLCJQbGF0Zm9ybUlEIjozLCJleHAiOjE3MjIwMzcxMjUsIm5iZiI6MTcxNDI2MDgyNSwiaWF0IjoxNzE0MjYxMTI1fQ.VynYKfHcR17GwpJRp4uEr9mv_OIJXrbq0_NXhNTBFJQ";
        Buffer.BlockCopy(Encoding.ASCII.GetBytes(user), 0, userId, 0, user.Length);
        Buffer.BlockCopy(Encoding.ASCII.GetBytes(token), 0, userToken, 0, token.Length);
    }
    public override void OnDraw()
    {
        var user = User.Instance;
        ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 5);
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