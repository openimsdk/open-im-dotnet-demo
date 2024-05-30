using System.Numerics;
using System.Text;
using ImGuiNET;
using Newtonsoft.Json;

public class LoginWindow : ImGuiWindow
{
    byte[] userId = new byte[128];
    byte[] userToken = new byte[256];
    public LoginWindow(string title, Rect position) : base(title, position)
    {
        var user = "yejian";
        // TODO read from local cache
        var token = "";
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
        ImGui.SetCursorPosX(position.w / 2 - 100);
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
        ImGui.SameLine();
        if (ImGui.Button("GetToken"))
        {
            string id = Encoding.UTF8.GetString(userId).TrimEnd('\0');
            RefreshToken(id);
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

    async void RefreshToken(string userId)
    {
        using (var httpClient = new HttpClient())
        {
            try
            {
                var url = string.Format("{0}{1}", Config.APIAddr, "/auth/user_token");
                var userTokenReq = new UserTokenReq()
                {
                    secret = "openIM123",
                    platformID = (int)User.PlatformID,
                    userID = userId,
                };
                var postData = JsonConvert.SerializeObject(userTokenReq);
                httpClient.DefaultRequestHeaders.Add("operationID", "111111");
                HttpResponseMessage response = await httpClient.PostAsync(url, new StringContent(postData, Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<UserTokenRes>(jsonResponse);
                if (res.errCode > 0)
                {
                    Console.WriteLine($"Http Request Error Code :{res.errCode + ":" + res.errMsg}");
                }
                else
                {
                    var token = res.data.token;
                    Buffer.BlockCopy(Encoding.ASCII.GetBytes(token), 0, userToken, 0, token.Length);
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Http Request Error:{e.Message}");
            }
        }
    }
}