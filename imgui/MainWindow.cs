using System.Numerics;
using System.Text;
using ImGuiNET;
using Newtonsoft.Json;
using open_im_sdk;

public class MainWindow : ImGuiWindow
{
    public MainWindow(string title, Rect position) : base(title, position)
    {
    }
    int selectTabMenu = 0;
    static string[] TabMenuName = new string[] { "User", "Conversation", "Friend", "Group" };

    byte[] addFriendId = new byte[128];
    byte[] addGroupId = new byte[128];

    int selectConversationIndex = -1;
    int selectFriendIndex = -1;
    int selectGroupIndex = -1;
    public override void OnDraw()
    {
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
    }

    void DrawUserInfo()
    {
        var user = User.Instance;
        ImGui.SameLine();
        ImGui.BeginGroup();
        {
            ImGui.Text("LoginUser:" + user.LoginUser);
            ImGui.Text("LoginStatus:" + user.LoginStatus.ToString());
            if (user.SelfUserInfo != null)
            {
                ImGui.Text("用户ID:" + user.SelfUserInfo.UserID);
                ImGui.Text("昵称:" + user.SelfUserInfo.Nickname);
                ImGui.Text("头像:" + user.SelfUserInfo.FaceURL);
                ImGui.Text("CreateTime:" + user.SelfUserInfo.CreateTime.ToString());
            }
            // ImGui.SeparatorText("Friend");
            // ImGui.InputText("FriendId", addFriendId, 128, ImGuiInputTextFlags.None);
            // if (ImGui.Button("AddFriend"))
            // {
            //     IMSDK.AddFriend((suc, errCode, errMsg) =>
            //     {

            //     }, new ApplyToAddFriendReq()
            //     {
            //         FromUserID = user.SelfUserInfo.UserID,
            //         ToUserID = Encoding.UTF8.GetString(addFriendId).TrimEnd('\0'),
            //         ReqMsg = "",
            //         Ex = "",
            //     });
            // }
        }
        ImGui.EndGroup();

    }
    void DrawConversation()
    {
        var user = User.Instance;
        ImGui.SameLine();
        ImGui.BeginChild("ConversationList", new Vector2(200, 0), true);
        var list = user.Conversation.ConversationList;
        if (list != null)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var conversation = list[i];
                if (ImGui.Selectable(conversation.ShowName, selectConversationIndex == i))
                {
                    selectConversationIndex = i;
                }
            }
        }
        ImGui.EndChild();
        ImGui.SameLine();
        ImGui.BeginChild("CharInfo", new Vector2(position.w - 300, 0), true);
        ImGui.EndChild();
    }
    void DrawFriend()
    {
        var user = User.Instance;
        ImGui.SameLine();
        ImGui.BeginChild("FriendList", new Vector2(200, 0), true);
        var list = user.Friend.FriendList;
        if (list != null)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var f = list[i];
                if (ImGui.Selectable(f.Nickname, selectFriendIndex == i))
                {
                    selectFriendIndex = i;
                }
            }
        }
        ImGui.EndChild();
        ImGui.SameLine();
        ImGui.BeginChild("", new Vector2(position.w - 300, 0), true);
        if (selectFriendIndex >= 0)
        {
            if (ImGui.Button("Send"))
            {
                var msg = IMSDK.CreateTextMessage("中文信息");
                Debug.Log(open_im_sdk.util.Utils.ToJson(msg));
            }
        }
        ImGui.EndChild();
    }
    void DrawGroup()
    {
        var user = User.Instance;
        ImGui.SameLine();
        ImGui.BeginChild("GroupList", new Vector2(200, 0), true);
        var list = user.Group.GroupList;
        if (list != null)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var f = list[i];
                if (ImGui.Selectable(f.GroupName, selectGroupIndex == i))
                {
                    selectGroupIndex = i;
                }
            }
        }
        ImGui.EndChild();
        ImGui.SameLine();
        ImGui.BeginChild("GroupInfo", new Vector2(position.w - 300, 0), true);
        ImGui.EndChild();
    }


}