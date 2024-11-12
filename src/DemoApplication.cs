
using Dawn;
using IMDemo.Chat;
using IMDemo.UI;
using OpenTK.Windowing.Common;

namespace IMDemo
{
    public class DemoApplication : Application
    {

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