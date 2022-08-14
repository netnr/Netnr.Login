namespace Netnr.Login;

public partial class DingTalk
{
    /// <summary>
    /// GET
    /// </summary>
    public static string API_Authorize_ScanCode { get; set; } = "https://login.dingtalk.com/oauth2/auth";

    /// <summary>
    /// GET
    /// </summary>
    public static string API_Authorize_Password { get; set; } = "https://oapi.dingtalk.com/connect/oauth2/sns_authorize";

    /// <summary>
    /// POST
    /// </summary>
    public static string API_AccessToken { get; set; } = "https://api.dingtalk.com/v1.0/oauth2/userAccessToken";

    /// <summary>
    /// GET
    /// </summary>
    public static string API_User { get; set; } = "https://api.dingtalk.com/v1.0/contact/users/me";

    /// <summary>
    /// 新版本：企业内部开发 H5微应用，配置 开发管理、权限管理（通讯录个人信息读权限）、登录与分享。
    /// 旧版本：移动应用接入 扫码登录
    /// </summary>
    public static bool IsOld { get; set; } = false;

    /// <summary>
    /// 扫码登录 或 密码登录
    /// </summary>
    public static bool IsScanCode { get; set; } = true;

    /// <summary>
    /// GET
    /// </summary>
    /// <returns></returns>
    public static string API_Authorize()
    {
        if (IsOld)
        {
            return IsScanCode ? API_Authorize_Old_ScanCode : API_Authorize_Old_Password;
        }
        else
        {
            return IsScanCode ? API_Authorize_ScanCode : API_Authorize_Password;
        }        
    }

    public static string AppId { get; set; }

    public static string AppSecret { get; set; }

    public static string Redirect_Uri { get; set; }
}

/// <summary>
/// authorize 请求参数
/// </summary>
public class DingTalkAuthorizeModel : PublicAuthorizeModel
{
    public DingTalkAuthorizeModel()
    {
        Redirect_Uri = DingTalk.Redirect_Uri;
    }

    public string Client_Id { get; set; } = DingTalk.AppId;

    public string Scope { get; set; } = "openid";

    /// <summary>
    /// 值为consent时，会进入授权确认页
    /// </summary>
    public string Prompt { get; set; } = "consent";

    public string Response_Type { get; set; } = "code";
}

/// <summary>
/// access token
/// </summary>
public class DingTalkAccessTokenModel
{
    [JsonPropertyName("clientId")]
    public string ClientId { get; set; } = DingTalk.AppId;

    [JsonPropertyName("clientSecret")]
    public string ClientSecret { get; set; } = DingTalk.AppSecret;

    [JsonPropertyName("code")]
    public string Code { get; set; }

    [JsonPropertyName("grantType")]
    public string GrantType { get; set; } = "authorization_code";
}

/// <summary>
/// refresh token
/// </summary>
public class DingTalkRefreshTokenModel
{
    [JsonPropertyName("clientId")]
    public string ClientId { get; set; } = DingTalk.AppId;

    [JsonPropertyName("clientSecret")]
    public string ClientSecret { get; set; } = DingTalk.AppSecret;

    /// <summary>
    /// 刷新 token
    /// </summary>
    [JsonPropertyName("refreshToken")]
    public string RefreshToken { get; set; }

    [JsonPropertyName("grantType")]
    public string GrantType { get; set; } = "refresh_token";
}

/// <summary>
/// user 请求参数
/// </summary>
public class DingTalkUserModel
{
    /// <summary>
    /// 授权凭证
    /// </summary>
    public string Access_Token { get; set; }
}