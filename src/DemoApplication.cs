
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
        protected override void OnUnload()
        {
            base.OnUnload();
            ChatMgr.Instance.UnInitSDK();
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
    }
}