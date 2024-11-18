using Newtonsoft.Json;

namespace Dawn
{
    public static class LocalStore
    {
        // static string localDataFileName = "./temp/localdata.json";

        // public static LocalUserData GetLocalUserData(string userName)
        // {
        //     if (File.Exists(localDataFileName))
        //     {
        //         var jsonText = File.ReadAllText(localDataFileName);
        //         if (jsonText != "")
        //         {
        //             var data = JsonConvert.DeserializeObject<LocalData>(jsonText);
        //             if (data != null)
        //             {
        //                 localData = data;
        //                 if (localData.LocalUserDatas == null)
        //                 {
        //                     localData.LocalUserDatas = new List<LocalUserData>();
        //                 }
        //                 foreach (LocalUserData userData in localData.LocalUserDatas)
        //                 {
        //                     if (userData.UserName == userName)
        //                     {
        //                         return userData;
        //                     }
        //                 }
        //             }
        //             else
        //             {
        //                 localData = new LocalData();
        //                 localData.LocalUserDatas = new List<LocalUserData>();
        //             }
        //         }
        //     }
        //     return null;
        // }
        // public static void SaveLocalData(LocalUserData data)
        // {
        //     if (data == null)
        //     {
        //         return;
        //     }
        //     if (localData == null)
        //     {
        //         localData = new LocalData();
        //         localData.LocalUserDatas = new List<LocalUserData>();
        //     }
        //     int index = -1;
        //     for (int i = 0; i < localData.LocalUserDatas.Count; i++)
        //     {
        //         if (localData.LocalUserDatas[i].UserName == data.UserName)
        //         {
        //             index = i;
        //         }
        //     }
        //     if (index >= 0)
        //     {
        //         localData.LocalUserDatas.RemoveAt(index);
        //     }
        //     localData.LocalUserDatas.Add(data);
        //     try
        //     {
        //         File.WriteAllText(localDataFileName, JsonConvert.SerializeObject(localData));
        //     }
        //     catch (Exception ex)
        //     {
        //         Debug.Log("an error ocurred", ex.Message);
        //     }
        // }
    }
}

