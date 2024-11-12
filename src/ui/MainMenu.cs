using Dawn;
using IMDemo.Chat;

namespace IMDemo.UI
{
    public static class MainMenu
    {
        [MenuItem("Start/LoginUser/yejian1")]
        public static void LoginUser1()
        {
            if (ChatMgr.Instance.currentUser != null)
            {
                Debug.Log("repeat login");
                return;
            }
            var uid = "yejian1";
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySUQiOiJ5ZWppYW4xIiwiUGxhdGZvcm1JRCI6MiwiZXhwIjoxNzM4ODAyMzE0LCJuYmYiOjE3MzEwMjYwMTQsImlhdCI6MTczMTAyNjMxNH0.U7UUq4iVBL5GFXKKtAdgAWZEFI3cV6x3BnVp4LWKHW8";
            var user = new User(uid, token);
            user.Login();
            ChatMgr.Instance.currentUser = user;
        }
        [MenuItem("Start/LoginUser/yejian2")]
        public static void LoginUser2()
        {
            if (ChatMgr.Instance.currentUser != null)
            {
                Debug.Log("repeat login");
                return;
            }
            var uid = "yejian2";
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySUQiOiJ5ZWppYW4yIiwiUGxhdGZvcm1JRCI6MiwiZXhwIjoxNzM4ODAyNDI3LCJuYmYiOjE3MzEwMjYxMjcsImlhdCI6MTczMTAyNjQyN30.IwdVStbhnW6kU3U2NskaH15c9ooQ9Daz656YF5BGzms";
            var user = new User(uid, token);
            user.Login();
            ChatMgr.Instance.currentUser = user;
        }

        [MenuItem("Help/Official WebSite")]
        public static void OfficialWebSite()
        {
            Application.OpenUrl(Config.OfficialWebSite);
        }

        [MenuItem("Help/Doc WebSite")]
        public static void DocWebSite()
        {
            Application.OpenUrl(Config.DocWebSite);
        }

        [MenuItem("Help/About")]
        public static void About()
        {

        }
    }
}