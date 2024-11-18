using Dawn;
using Dawn.UI;
using ImGuiNET;
using OpenIM.IMSDK;
using OpenIMSDK = OpenIM.IMSDK.IMSDK;

namespace IMDemo.UI
{
    public class FriendApplicationListWindow : ImGuiWindow
    {
        [MenuItem("Friend/Friend Application List")]
        public static void Show()
        {
            var window = GetWindow<FriendApplicationListWindow>();
            window.Show("Friend Application List");
        }
        List<FriendApplicationInfo> applicantList;
        List<FriendApplicationInfo> recipientList;
        public override void OnEnable()
        {
            RefreshApplicantList();
            RefreshRecipientList();
        }
        void RefreshApplicantList()
        {
            OpenIMSDK.GetFriendApplicationListAsApplicant((list, err, errMsg) =>
            {
                if (list != null)
                {
                    applicantList = list;
                }
                else
                {
                    Debug.Error(errMsg);
                }
            });
        }
        void RefreshRecipientList()
        {
            OpenIMSDK.GetFriendApplicationListAsRecipient((list, err, errMsg) =>
            {
                if (list != null)
                {
                    recipientList = list;
                }
                else
                {
                    Debug.Error(errMsg);
                }
            });
        }

        public override void OnGUI()
        {
            if (applicantList != null)
            {
                ImGui.Text("ApplicantList:");
                ImGui.BeginChild("ApplicantList", new System.Numerics.Vector2(0, rect.h / 2), true, ImGuiWindowFlags.HorizontalScrollbar | ImGuiWindowFlags.AlwaysVerticalScrollbar);

                if (ImGui.BeginTable("ApplicantListTable", 4, ImGuiTableFlags.Borders | ImGuiTableFlags.RowBg | ImGuiTableFlags.ScrollX))
                {
                    ImGui.TableSetupColumn("FromNickName");
                    ImGui.TableSetupColumn("ToNickName");
                    ImGui.TableSetupColumn("ReqMsg");
                    ImGui.TableSetupColumn("Result");

                    ImGui.TableHeadersRow();

                    foreach (var application in applicantList)
                    {
                        ImGui.TableNextRow();

                        ImGui.TableSetColumnIndex(0);
                        ImGui.Text(application.FromNickname);

                        ImGui.TableSetColumnIndex(1);
                        ImGui.Text(application.ToNickname);

                        ImGui.TableSetColumnIndex(2);
                        ImGui.Text(application.ReqMsg);

                        ImGui.TableSetColumnIndex(3);
                        HandleResult result = (HandleResult)application.HandleResult;
                        ImGui.Text(result.ToString());

                    }

                    ImGui.EndTable();
                }

                ImGui.EndChild();
            }

            ImGui.Text("RecipientList:");
            if (recipientList != null)
            {
                ImGui.BeginChild("RecipientList", new System.Numerics.Vector2(0, rect.h / 2), true, ImGuiWindowFlags.HorizontalScrollbar | ImGuiWindowFlags.AlwaysVerticalScrollbar);

                if (ImGui.BeginTable("RecipientListTable", 6, ImGuiTableFlags.Borders | ImGuiTableFlags.RowBg | ImGuiTableFlags.ScrollX))
                {
                    ImGui.TableSetupColumn("FromNickName");
                    ImGui.TableSetupColumn("ToNickName");
                    ImGui.TableSetupColumn("ReqMsg");
                    ImGui.TableSetupColumn("Result");
                    ImGui.TableSetupColumn("Agree");
                    ImGui.TableSetupColumn("Refuse");


                    ImGui.TableHeadersRow();

                    foreach (var application in recipientList)
                    {
                        ImGui.TableNextRow();

                        ImGui.TableSetColumnIndex(0);
                        ImGui.Text(application.FromNickname);

                        ImGui.TableSetColumnIndex(1);
                        ImGui.Text(application.ToNickname);

                        ImGui.TableSetColumnIndex(2);
                        ImGui.Text(application.ReqMsg);

                        ImGui.TableSetColumnIndex(3);
                        HandleResult result = (HandleResult)application.HandleResult;
                        ImGui.Text(result.ToString());

                        ImGui.TableSetColumnIndex(4);
                        if (result == HandleResult.Unprocessed)
                        {
                            if (ImGui.Button("Agree"))
                            {
                                OnAgreeClick(application);
                            }
                        }

                        ImGui.TableSetColumnIndex(5);
                        if (result == HandleResult.Unprocessed)
                        {
                            if (ImGui.Button("Refuse"))
                            {
                                OnRefuseClick(application);
                            }
                        }
                    }

                    ImGui.EndTable();
                }

                ImGui.EndChild();
            }
        }

        void OnAgreeClick(FriendApplicationInfo applicationInfo)
        {
            OpenIMSDK.AcceptFriendApplication((suc, err, errMsg) =>
            {
                if (suc)
                {
                    RefreshRecipientList();
                }
                else
                {
                    Debug.Error(errMsg);
                }
            }, new ProcessFriendApplicationParams
            {
                ToUserID = applicationInfo.FromUserID,
                HandleMsg = "i agree"
            });
        }
        void OnRefuseClick(FriendApplicationInfo applicationInfo)
        {
            OpenIMSDK.RefuseFriendApplication((suc, err, errMsg) =>
            {
                if (suc)
                {
                    RefreshRecipientList();
                }
                else
                {
                    Debug.Error(errMsg);
                }
            }, new ProcessFriendApplicationParams
            {
                ToUserID = applicationInfo.FromUserID,
                HandleMsg = "i refuse",
            });
        }
    }
}