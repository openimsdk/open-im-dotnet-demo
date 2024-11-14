using Dawn;
using Dawn.UI;
using IMDemo.Chat;
using ImGuiNET;
using OpenIM.IMSDK;
using OpenIMSDK = OpenIM.IMSDK.IMSDK;

namespace IMDemo.UI
{
    public class SearchUserWindow : ImGuiWindow
    {
        [MenuItem("User/Search User")]
        public static void ShowSearchWindow()
        {
            var window = GetWindow<SearchUserWindow>();
            window.Show("Search User");
        }

        string searchUserId;
        PublicUserInfo searchUserInfo;
        bool notFriend = false;

        public override void OnEnable()
        {
            searchUserId = "";
            searchUserInfo = null;
            notFriend = false;
        }

        public override void OnGUI()
        {
            if (ImGui.InputText("", ref searchUserId, 100))
            {

            }
            ImGui.SameLine();
            if (ImGui.Button("Search"))
            {
                OpenIMSDK.GetUsersInfo((list, err, errMsg) =>
                {
                    if (list != null && list.Count == 1)
                    {
                        searchUserInfo = list[0];
                        OpenIMSDK.GetSpecifiedFriendsInfo((list, err, errMsg) =>
                        {
                            if (list != null && list.Count == 1)
                            {
                                notFriend = false;
                            }
                            else
                            {
                                notFriend = true;
                            }
                        }, [searchUserInfo.UserID], true);
                    }
                }, [searchUserId]);
            }

            if (searchUserInfo != null)
            {
                ImGui.Columns(2, "UserInfoColumns", false);
                ImGui.SetColumnWidth(0, 150);

                ImGui.Text("UserId");
                ImGui.NextColumn();
                ImGui.Text($"{searchUserInfo.UserID}");
                ImGui.NextColumn();

                ImGui.Text("NickName");
                ImGui.NextColumn();
                ImGui.Text($"{searchUserInfo.Nickname}");

                ImGui.NextColumn();

                ImGui.Text("FaceUrl");
                ImGui.NextColumn();
                ImGui.Text(searchUserInfo.FaceURL);

                ImGui.NextColumn();

                ImGui.Text("CreateTime");
                ImGui.NextColumn();
                ImGui.Text($"{Time.GetTimeStampStr(searchUserInfo.CreateTime / 1000)}");
                ImGui.NextColumn();

                ImGui.Columns(1);

                if (notFriend)
                {
                    if (ImGui.Button("Add"))
                    {
                        OnAddClick(searchUserInfo);
                    }
                }

            }
        }
        void OnAddClick(PublicUserInfo userInfo)
        {
            OpenIMSDK.AddFriend((suc, err, errMsg) =>
            {
                if (suc)
                {
                    Close();
                }
                else
                {
                    Debug.Error(errMsg);
                }
            }, new ApplyToAddFriendReq
            {
                FromUserID = ChatMgr.Instance.currentUser.uid,
                ToUserID = userInfo.UserID,
                ReqMsg = $"我是{ChatMgr.Instance.currentUser.uid}",
                Ex = "",
            });
        }
    }
}