using Dawn;
using Dawn.UI;
using IMDemo.Chat;
using ImGuiNET;
using OpenIM.IMSDK;
using OpenIMSDK = OpenIM.IMSDK.IMSDK;

namespace IMDemo.UI
{
    public class FriendInfoWindow : ImGuiWindow
    {
        [MenuItem("Friend/Friend Info")]
        public static void ShowFriendInfo()
        {
            GetWindow<FriendInfoWindow>().Show("Friend List");
        }

        List<FriendInfo> friendList;

        public override void OnEnable()
        {
            OpenIMSDK.GetFriendList((list, errCode, errMsg) =>
            {
                if (list != null)
                {
                    friendList = list;
                }
            }, true);
        }

        public override void OnGUI()
        {
            if (friendList == null) return;

            ImGui.BeginChild("TableContainer", new System.Numerics.Vector2(0, rect.h - 50), true, ImGuiWindowFlags.HorizontalScrollbar | ImGuiWindowFlags.AlwaysVerticalScrollbar);

            if (ImGui.BeginTable("FriendInfoTable", 11, ImGuiTableFlags.Borders | ImGuiTableFlags.RowBg | ImGuiTableFlags.ScrollX))
            {
                ImGui.TableSetupColumn("OwnerUserID");
                ImGui.TableSetupColumn("FriendUserID");
                ImGui.TableSetupColumn("Remark");
                ImGui.TableSetupColumn("CreateTime");
                ImGui.TableSetupColumn("AddSource");
                ImGui.TableSetupColumn("OperatorUserID");
                ImGui.TableSetupColumn("Nickname");
                ImGui.TableSetupColumn("FaceURL");
                ImGui.TableSetupColumn("Ex");
                ImGui.TableSetupColumn("AttachedInfo");
                ImGui.TableSetupColumn("IsPinned");

                ImGui.TableHeadersRow();

                foreach (var friend in friendList)
                {
                    ImGui.TableNextRow();

                    ImGui.TableSetColumnIndex(0);
                    ImGui.Text(friend.OwnerUserID);

                    ImGui.TableSetColumnIndex(1);
                    ImGui.Text(friend.FriendUserID);

                    ImGui.TableSetColumnIndex(2);
                    ImGui.Text(friend.Remark);

                    ImGui.TableSetColumnIndex(3);
                    ImGui.Text(Time.GetTimeStampStr(friend.CreateTime / 1000)); // 转换 CreateTime

                    ImGui.TableSetColumnIndex(4);
                    ImGui.Text(friend.AddSource.ToString());

                    ImGui.TableSetColumnIndex(5);
                    ImGui.Text(friend.OperatorUserID);

                    ImGui.TableSetColumnIndex(6);
                    ImGui.Text(friend.Nickname);

                    ImGui.TableSetColumnIndex(7);
                    ImGui.Text(friend.FaceURL);

                    ImGui.TableSetColumnIndex(8);
                    ImGui.Text(friend.Ex);

                    ImGui.TableSetColumnIndex(9);
                    ImGui.Text(friend.AttachedInfo);

                    ImGui.TableSetColumnIndex(10);
                    ImGui.Text(friend.IsPinned.ToString());
                }

                ImGui.EndTable();
            }

            ImGui.EndChild();
        }
    }
}