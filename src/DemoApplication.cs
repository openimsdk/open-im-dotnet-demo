
using Dawn;
using IMDemo.Chat;
using IMDemo.UI;
using OpenTK.Windowing.Common;

namespace IMDemo
{
    public class DemoApplication : Application
    {
        public Action OnLoadCallBack;
        public DemoApplication(string title, int width, int height) : base(title, width, height)
        {

        }

        protected override void OnLoad()
        {
            base.OnLoad();
            if (!ChatMgr.Instance.InitSDK())
            {
                Debug.Log("InitSDK error");
                Close();
                return;
            }
            if (OnLoadCallBack != null)
            {
                OnLoadCallBack();
            }
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

            ChatMgr.Instance.Update();
        }
        protected override void OnGUI()
        {
            // draw
            StatusBar.Draw();
        }

        public void TryUserLogin(string uid, string token)
        {
            if (ChatMgr.Instance.currentUser == null)
            {
                var user = new User(uid, token);
                user.Login();
                ChatMgr.Instance.currentUser = user;
                Title = "IMDemo-" + uid;
            }
            else
            {
                if (ChatMgr.Instance.currentUser.uid != uid)
                {
                    CreateNewInstance(uid, token);
                }
                else
                {
                    Debug.Log("Already Login");
                }
            }
        }
    }
}