namespace Netnr.Login;

/// <summary>
/// Xiaomi
/// </summary>
public class Xiaomi
{
    /// <summary>
    /// GET
    /// </summary>
    public static string API_Authorize { get; set; } = "https://account.xiaomi.com/oauth2/authorize";

    /// <summary>
    /// POST
    /// </summary>
    public static string API_AccessToken { get; set; } = "https://account.xiaomi.com/oauth2/token";

    /// <summary>
    /// GET
    /// </summary>
    public static string API_User { get; set; } = "https://open.account.xiaomi.com/user/profile";

    /// <summary>
    /// Client ID
    /// </summary>
    public static string AppId { get; set; } = "";

    /// <summary>
    /// Client Secret
    /// </summary>
    public static string AppSecret { get; set; } = "";

    /// <summary>
    /// 回调
    /// </summary>
    public static string Redirect_Uri { get; set; } = "";
}

/// <summary>
/// authorize 请求参数
/// </summary>
public class XiaomiAuthorizeModel : PublicAuthorizeModel
{
    public XiaomiAuthorizeModel()
    {
        Redirect_Uri = Xiaomi.Redirect_Uri;
    }

    /// <summary>
    /// 申请应用时分配的应用 ID，可以在应用详情页获取
    /// </summary>
    public string Client_Id { get; set; } = Xiaomi.AppId;

    public string Response_Type { get; set; } = "code";

    public string Scope { get; set; } = "1";
}

/// <summary>
/// access token 请求参数
/// </summary>
public class XiaomiAccessTokenModel : PublicAccessTokenModel
{
    public XiaomiAccessTokenModel()
    {
        Redirect_Uri = Xiaomi.Redirect_Uri;
    }

    /// <summary>
    /// 申请应用时分配的应用 ID
    /// </summary>
    public string Client_Id { get; set; } = Xiaomi.AppId;

    /// <summary>
    /// 申请应用时分配的 AppSecret
    /// </summary>
    public string Client_Secret { get; set; } = Xiaomi.AppSecret;

    public string Grant_Type { get; set; } = "authorization_code";
}

/// <summary>
/// refresh token 请求参数
/// </summary>
public class XiaomiRefreshTokenModel
{
    /// <summary>
    /// 申请应用时分配的应用 ID
    /// </summary>
    public string Client_Id { get; set; } = Xiaomi.AppId;
    /// <summary>
    /// 申请应用时分配的 AppSecret
    /// </summary>
    public string Client_Secret { get; set; } = Xiaomi.AppSecret;
    /// <summary>
    /// 
    /// </summary>
    public string Redirect_Uri { get; set; } = Xiaomi.Redirect_Uri;
    /// <summary>
    /// 固定值
    /// </summary>
    public string Grant_Type { get; set; } = "refresh_token";
    /// <summary>
    /// 刷新 token
    /// </summary>
    public string Refresh_Token { get; set; }
}

/// <summary>
/// user 请求参数
/// </summary>
public class XiaomiUserModel
{
    /// <summary>
    /// 申请应用时分配的应用 ID
    /// </summary>
    public string Client_Id { get; set; } = Xiaomi.AppId;
    /// <summary>
    /// token
    /// </summary>
    public string Token { get; set; }
}