using Dawn;
using IMDemo.Chat;

namespace IMDemo.UI
{
    public static class MainMenu
    {
        [MenuItem("Start/Login/yejian1")]
        public static void LoginUser1()
        {
            var uid = "yejian1";
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySUQiOiJ5ZWppYW4xIiwiUGxhdGZvcm1JRCI6MywiZXhwIjoxNzM5MzIwNTA3LCJuYmYiOjE3MzE1NDQyMDcsImlhdCI6MTczMTU0NDUwN30.KcvsLdIGmV6nsVdKYTbatzoSONyC4oeAuVBnnP9o_0Q";
            User.TryLogin(uid, token);
        }

        [MenuItem("Start/Login/yejian2")]
        public static void LoginUser2()
        {
            var uid = "yejian2";
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySUQiOiJ5ZWppYW4yIiwiUGxhdGZvcm1JRCI6MywiZXhwIjoxNzM5MzIwNTMxLCJuYmYiOjE3MzE1NDQyMzEsImlhdCI6MTczMTU0NDUzMX0.ywmgbsNbTGprgBHpDOnW8Bjn7KwYs8EdgGqIhgjvi24";
            User.TryLogin(uid, token);
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
    }
}