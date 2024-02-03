using System.Text;
using Newtonsoft.Json;
public class RequestTokenArgs
{
    public string secret;
    public int platformID;
    public string userID;
}
public class TokenData
{
    public string userId;
    public string token;
    public long expireTimeSeconds;
}
public class RequestTokenRes
{
    public int errCode;
    public string errMsg;
    public string errDlt;
    public TokenData data;
}
public class TokenMgr
{
    static async void _RequestToken(open_im_sdk.PlatformID platform, string userName, Action<string, long> OnRecvToken)
    {
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("operationID", "123456789");
            var args = new RequestTokenArgs
            {
                secret = "openIM123",
                platformID = (int)platform,
                userID = "openIM123456"
            };
            string jsonData = JsonConvert.SerializeObject(args);
            HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(Config.APIAddr + "/auth/user_token", content);
            string token = "";
            long expireTimeSeconds = 0;
            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<RequestTokenRes>(responseData);
                if (res.errCode == 0)
                {
                    token = res.data.token;
                    expireTimeSeconds = res.data.expireTimeSeconds;
                }
            }

            OnRecvToken(token, expireTimeSeconds);
        }
    }

    public static void RequestToken(open_im_sdk.PlatformID platform, string userName, Action<string, long> OnRecvToken)
    {
        Task.Run(() =>
        {
            _RequestToken(platform, userName, OnRecvToken);
        });
    }
}