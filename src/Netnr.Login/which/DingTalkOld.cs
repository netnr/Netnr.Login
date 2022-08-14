namespace Netnr.Login;

public partial class DingTalk
{
    /// <summary>
    /// GET
    /// </summary>
    public static string API_Authorize_Old_ScanCode { get; set; } = "https://oapi.dingtalk.com/connect/qrconnect";

    /// <summary>
    /// GET
    /// </summary>
    public static string API_Authorize_Old_Password { get; set; } = "https://oapi.dingtalk.com/connect/qrconnect";

    /// <summary>
    /// POST
    /// </summary>
    public static string API_User_Old { get; set; } = "https://oapi.dingtalk.com/sns/getuserinfo_bycode";
}

/// <summary>
/// authorize 请求参数
/// </summary>
public class DingTalkOldAuthorizeModel : PublicAuthorizeModel
{
    public DingTalkOldAuthorizeModel()
    {
        Redirect_Uri = DingTalk.Redirect_Uri;
    }

    public string AppId { get; set; } = DingTalk.AppId;

    public string Scope { get; set; } = "snsapi_login";

    public string Response_Type { get; set; } = "code";
}

/// <summary>
/// user 请求参数
/// </summary>
public class DingTalOldkUserModel
{
    public DingTalOldkUserModel()
    {
        using HMACSHA256 hmacsha256 = new()
        {
            Key = Encoding.UTF8.GetBytes(DingTalk.AppSecret)
        };
        byte[] dataBuffer = Encoding.UTF8.GetBytes(Timestamp);
        byte[] hashBytes = hmacsha256.ComputeHash(dataBuffer);

        Signature = Convert.ToBase64String(hashBytes);
    }

    [JsonPropertyName("accessKey")]
    public string AccessKey { get; set; } = DingTalk.AppId;

    /// <summary>
    /// 当前时间戳，单位是毫秒
    /// </summary>
    public string Timestamp { get; set; } = NetnrCore.ToTimestamp(DateTime.Now, true).ToString();

    /// <summary>
    /// 通过appSecret计算出来的签名值
    /// </summary>
    public string Signature { get; set; }
}