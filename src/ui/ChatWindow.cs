using System.Numerics;
using Dawn;
using Dawn.UI;
using IMDemo.Chat;
using ImGuiNET;
using Microsoft.VisualBasic;
using OpenIM.IMSDK;
using OpenIMSDK = OpenIM.IMSDK.IMSDK;

namespace IMDemo.UI
{
    public class ChatWindow : ImGuiWindow
    {
        class SendMsgCallBack : IMsgSendCallBack
        {
            public Action<int, string> OnErrorCB;
            public Action<long> OnProgressCB;
            public Action<Message> OnSuccessCB;

            public void OnError(int code, string errMsg)
            {
                if (OnErrorCB != null)
                {
                    OnErrorCB(code, errMsg);
                }
            }

            public void OnProgress(long progress)
            {
                if (OnProgressCB != null)
                {
                    OnProgressCB(progress);
                }
            }

            public void OnSuccess(Message msg)
            {
                if (OnSuccessCB != null)
                {
                    OnSuccessCB(msg);
                }
            }
        }

        public static void ShowChatWindow(Conversation conversation)
        {
            var window = GetWindow<ChatWindow>();
            window.conversation = conversation;
            window.Show(conversation.ShowName);
        }

        public Conversation conversation;
        public List<Message> historyMessage;
        public string inputMessage;
        public override void OnEnable()
        {
            inputMessage = "";
            OpenIMSDK.GetAdvancedHistoryMessageList((res, err, errMsg) =>
            {
                if (res != null)
                {
                    historyMessage = [.. res.MessageList];
                    Debug.Log("-----------", res.MessageList.Length);
                }
            }, new GetAdvancedHistoryMessageListParams
            {
                ConversationID = conversation.ConversationID,
                LastMinSeq = 0,
                StartClientMsgID = "",
                Count = 100
            });
            var user = ChatMgr.Instance.currentUser;
            if (user != null)
            {
                user.messageListener.Event_OnRecvNewMessages += OnRecvMessage;
            }
        }

        public override void OnGUI()
        {
            if (conversation == null) return;

            ImGui.BeginChild("ChatMessages", new Vector2(0, -80), true, ImGuiWindowFlags.AlwaysVerticalScrollbar);

            if (historyMessage != null)
            {
                foreach (var message in historyMessage)
                {
                    if (message.TextElem != null)
                    {
                        ImGui.Text(message.SenderNickname + ":" + message.TextElem.Content);
                    }
                    if (message.NotificationElem != null)
                    {
                        var notification = Notification.Parse(message.ContentType, message.NotificationElem.Detail);
                        if (notification is FriendApplicationApprovedTips)
                        {
                            var tip = notification as FriendApplicationApprovedTips;
                            ImGui.Text("FriendApplicationApprovedTips:" + tip.FromToUserID.FromUserID + tip.FromToUserID.ToUserID);
                        }
                    }
                }
            }

            ImGui.EndChild();

            ImGui.InputText("##input", ref inputMessage, 1000);
            if (ImGui.Button("Send"))
            {
                if (!string.IsNullOrEmpty(inputMessage))
                {
                    var msg = OpenIMSDK.CreateTextMessage(inputMessage);
                    SendMessage(msg);
                }
            }
        }

        public override void OnClose()
        {
            base.OnClose();
            var user = ChatMgr.Instance.currentUser;
            if (user != null)
            {
                user.messageListener.Event_OnRecvNewMessages -= OnRecvMessage;
            }
        }


        public void SendMessage(Message msg)
        {
            var msgCallBack = new SendMsgCallBack();
            msgCallBack.OnSuccessCB = (_msg) =>
            {
                historyMessage.Add(_msg);
            };
            msgCallBack.OnErrorCB = (errCode, errMsg) =>
            {
                Debug.Error(errMsg);
            };
            OpenIMSDK.SendMessage(msgCallBack, msg, conversation.UserID, conversation.GroupID, new OfflinePushInfo(), false);
        }

        public void OnRecvMessage(List<Message> msgLists)
        {
            foreach (var msg in msgLists)
            {
                if (msg.SessionType == ConversationType.Single)
                {
                    if (msg.SendID == conversation.UserID)
                    {
                        historyMessage.Add(msg);
                    }
                }
                else if (msg.SessionType == ConversationType.Group)
                {
                    if (msg.RecvID == conversation.GroupID)
                    {
                        historyMessage.Add(msg);
                    }
                }
            }
        }
    }
}