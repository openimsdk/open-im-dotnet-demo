using System.Numerics;
using System.Text;
using ImGuiNET;
using Newtonsoft.Json;
using open_im_sdk;

public class MainWindow : ImGuiWindow
{
    Vector4 bgColor;
    byte[] userId = new byte[128];
    byte[] userToken = new byte[256];
    public MainWindow(string title, Rect position) : base(title, position)
    {
        bgColor = new Vector4(0.5f, 0.5f, 0.5f, 1);
        var user = "openIM123456";
        Buffer.BlockCopy(Encoding.ASCII.GetBytes(user), 0, userId, 0, user.Length);
        var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySUQiOiJ5ZWppYW4wMDEiLCJQbGF0Zm9ybUlEIjozLCJleHAiOjE3MTYwNDA1NjMsIm5iZiI6MTcwODI2NDI2MywiaWF0IjoxNzA4MjY0NTYzfQ.Qu_tjWfYCAYyZ3lxrZaBisp2VlXWJo9knBNcRS0UygI";
        Buffer.BlockCopy(Encoding.ASCII.GetBytes(token), 0, userToken, 0, token.Length);
    }
    public int selectTabMenu = 0;
    static string[] TabMenuName = new string[] { "User", "Conversation", "Friend", "Group" };

    byte[] addFriendId = new byte[128];
    byte[] addGroupId = new byte[128];

    public object FromUserID { get; private set; }

    public override void OnDraw()
    {
        ImGui.PushStyleColor(ImGuiCol.WindowBg, bgColor);
        ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 1);
        ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 1);
        ImGui.SetNextWindowPos(new Vector2(position.x, position.y));
        ImGui.SetNextWindowSize(new Vector2(position.w, position.h), ImGuiCond.Always);
        ImGui.Begin(title, ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoResize);
        {
            ImGui.BeginChild("TabMenuBar", new Vector2(100, 0), true);
            for (int i = 0; i < TabMenuName.Length; i++)
            {
                if (ImGui.Selectable(TabMenuName[i], selectTabMenu == i))
                {
                    selectTabMenu = i;
                }
            }
            ImGui.EndChild();
            if (selectTabMenu == 0) //User
            {
                DrawUserInfo();
            }
            else if (selectTabMenu == 1) //Conversation
            {
                DrawConversation();

            }
            else if (selectTabMenu == 2) // Friend
            {
                DrawFriend();
            }
            else if (selectTabMenu == 3) // Group
            {
                DrawGroup();
            }
        }
        ImGui.End();
        ImGui.PopStyleVar(2);
        ImGui.PopStyleColor();
    }

    public void DrawUserInfo()
    {
        var user = User.Instance;
        ImGui.SameLine();
        ImGui.BeginGroup();
        {
            ImGui.Text("LoginUser:" + user.LoginUser);
            ImGui.Text("LoginStatus:" + user.LoginStatus.ToString());
            if (user.SelfUserInfo != null)
            {
                if (ImGui.CollapsingHeader("SelfUserInfo"))
                {
                    ImGui.Text("UserId:" + user.SelfUserInfo.UserID);
                    ImGui.Text("NickName:" + user.SelfUserInfo.Nickname);
                    ImGui.Text("FaceURL:" + user.SelfUserInfo.FaceURL);
                    ImGui.Text("CreateTime:" + user.SelfUserInfo.CreateTime.ToString());
                    ImGui.Text("AppMangerLevel:" + user.SelfUserInfo.AppMangerLevel.ToString());
                }
            }
            ImGui.SeparatorText("Friend");
            ImGui.InputText("FriendId", addFriendId, 128, ImGuiInputTextFlags.None);
            if (ImGui.Button("AddFriend"))
            {
                IMSDK.AddFriend((suc, errCode, errMsg) =>
                {

                }, new ApplyToAddFriendReq()
                {
                    FromUserID = user.SelfUserInfo.UserID,
                    ToUserID = Encoding.UTF8.GetString(addFriendId).TrimEnd('\0'),
                    ReqMsg = "",
                    Ex = "",
                });
            }
        }
        ImGui.EndGroup();

    }
    public void DrawConversation()
    {
        var user = User.Instance;
        ImGui.SameLine();
        ImGui.BeginChild("ConversationList", new Vector2(200, 0), true);
        if (user.Conversation.ConversationList.Count > 0)
        {
        }
        ImGui.EndChild();
        ImGui.SameLine();
        ImGui.BeginChild("CharInfo", new Vector2(position.w - 300, 0), true);
        ImGui.EndChild();
    }
    public void DrawFriend()
    {
        var user = User.Instance;
        ImGui.SameLine();
        ImGui.BeginChild("FriendList", new Vector2(200, 0), true);
        if (user.Friend.FriendList != null)
        {

        }
        ImGui.EndChild();
        ImGui.SameLine();
        ImGui.BeginChild("FriendMenu", new Vector2(position.w - 300, 0), true);
        ImGui.EndChild();
    }
    public void DrawGroup()
    {
        var user = User.Instance;
        ImGui.SameLine();
        ImGui.BeginChild("GroupList", new Vector2(200, 0), true);
        if (user.Group.GroupList != null)
        {

        }
        ImGui.EndChild();
        ImGui.SameLine();
        ImGui.BeginChild("GroupInfo", new Vector2(position.w - 300, 0), true);
        ImGui.EndChild();
    }
}