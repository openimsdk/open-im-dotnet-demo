using System.Diagnostics;
using IMDemo;
using IMDemo.Chat;

var arguments = new Dictionary<string, string>();
for (int i = 0; i < args.Length; i += 2)
{
    if (i + 1 < args.Length && args[i].StartsWith("--"))
    {
        arguments[args[i].TrimStart('-')] = args[i + 1];
    }
}

var app = new DemoApplication("IMDemo", 1000, 800);
ChatMgr.Application = app;
if (arguments.Count > 0)
{
    app.OnLoadCallBack = () =>
    {
        if (arguments.ContainsKey("uid") && arguments.ContainsKey("token"))
        {
            var uid = arguments["uid"];
            var token = arguments["token"];
            Dawn.Debug.Log(uid);
            Dawn.Debug.Log(token);
            app.TryUserLogin(uid, token);
        }
    };
}

app.Run();







