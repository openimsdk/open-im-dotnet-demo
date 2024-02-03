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
        bgColor = new Vector4(1, 1, 1, 1);
        var user = "openIM123456";
        Buffer.BlockCopy(Encoding.ASCII.GetBytes(user), 0, userId, 0, user.Length);
        var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySUQiOiJvcGVuSU0xMjM0NTYiLCJQbGF0Zm9ybUlEIjozLCJleHAiOjE3MTQ1NzIwNDQsIm5iZiI6MTcwNjc5NTc0NCwiaWF0IjoxNzA2Nzk2MDQ0fQ.hyu88OH8MgTrmBqANzKReeYu3PQE9UrsjA-ziwrTouM";
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
        if (ImGui.Button("RequestToken"))
        {
            user.RequestToken("openIM123456");
        }
        ImGui.SameLine();
        if (ImGui.Button("Login"))
        {
            string id = Encoding.UTF8.GetString(userId);
            string token = Encoding.UTF8.GetString(userToken);
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
        // ImGui.PopItemWidth();
        ImGui.End();
        // ImGui.PopStyleColor();
        ImGui.PopStyleVar();
    }

}