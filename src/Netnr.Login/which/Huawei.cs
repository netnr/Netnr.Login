namespace Netnr.Login;

/// <summary>
/// Huawei
/// </summary>
public class Huawei
{
    /// <summary>
    /// GET
    /// </summary>
    public static string API_Authorize { get; set; } = "https://oauth-login.cloud.huawei.com/oauth2/v3/authorize";

    /// <summary>
    /// POST
    /// </summary>
    public static string API_AccessToken { get; set; } = "https://oauth-login.cloud.huawei.com/oauth2/v3/token";

    /// <summary>
    /// POST
    /// </summary>
    public static string API_User { get; set; } = "https://account.cloud.huawei.com/rest.php?nsp_svc=GOpen.User.getInfo";

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
public class HuaweiAuthorizeModel : PublicAuthorizeModel
{
    public HuaweiAuthorizeModel()
    {
        Redirect_Uri = Huawei.Redirect_Uri;
    }

    /// <summary>
    /// 申请应用时分配的应用 ID，可以在应用详情页获取
    /// </summary>
    public string Client_Id { get; set; } = Huawei.AppId;

    public string Response_Type { get; set; } = "code";

    public string Scope { get; set; } = "profile openid";

    /// <summary>
    /// 为offline时，返回响应包含Refresh Token
    /// </summary>
    public string Access_Type { get; set; } = "offline";
}

/// <summary>
/// access token 请求参数
/// </summary>
public class HuaweiAccessTokenModel : PublicAccessTokenModel
{
    public HuaweiAccessTokenModel()
    {
        Redirect_Uri = Huawei.Redirect_Uri;
    }

    /// <summary>
    /// 申请应用时分配的应用 ID
    /// </summary>
    public string Client_Id { get; set; } = Huawei.AppId;

    /// <summary>
    /// 申请应用时分配的 AppSecret
    /// </summary>
    public string Client_Secret { get; set; } = Huawei.AppSecret;

    public string Grant_Type { get; set; } = "authorization_code";
}

/// <summary>
/// refresh token 请求参数
/// </summary>
public class HuaweiRefreshTokenModel
{
    /// <summary>
    /// 申请应用时分配的应用 ID
    /// </summary>
    public string Client_Id { get; set; } = Huawei.AppId;
    /// <summary>
    /// 申请应用时分配的 AppSecret
    /// </summary>
    public string Client_Secret { get; set; } = Huawei.AppSecret;
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
public class HuaweiUserModel
{
    /// <summary>
    /// 昵称、匿名化帐号的顺序
    /// </summary>
    public int GetNickName { get; set; } = 1;
    /// <summary>
    /// token
    /// </summary>
    public string Access_Token { get; set; }
}