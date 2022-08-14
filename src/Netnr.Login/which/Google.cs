namespace Netnr.Login;

public class Google
{
    /// <summary>
    /// GET
    /// </summary>
    public static string API_Authorize { get; set; } = "https://accounts.google.com/o/oauth2/v2/auth";

    /// <summary>
    /// POST
    /// </summary>
    public static string API_AccessToken { get; set; } = "https://oauth2.googleapis.com/token";

    /// <summary>
    /// GET
    /// </summary>
    public static string API_User { get; set; } = "https://openidconnect.googleapis.com/v1/userinfo";

    /// <summary>
    /// Client ID
    /// </summary>
    public static string ClientId { get; set; }

    /// <summary>
    /// Client Secret
    /// </summary>
    public static string ClientSecret { get; set; }

    /// <summary>
    /// 回调
    /// </summary>
    public static string Redirect_Uri { get; set; }
}

/// <summary>
/// authorize 请求参数
/// </summary>
public class GoogleAuthorizeModel : PublicAuthorizeModel
{
    public GoogleAuthorizeModel()
    {
        Redirect_Uri = Google.Redirect_Uri;
    }

    /// <summary>
    /// 注册应用时的获取的client_id
    /// </summary>
    public string Client_Id { get; set; } = Google.ClientId;

    /// <summary>
    /// 固定值，传 code
    /// </summary>
    public string Response_Type { get; set; } = "code";

    /// <summary>
    /// 范围值必须以字符串开始openid，然后包括profile或email或两者兼而有之
    /// </summary>
    public string Scope { get; set; } = "openid profile email";

    /// <summary>
    /// 仅当在向 Google 授权服务器发出的初始请求中将 access_type 参数设置为 offline 时，refresh_token 字段才会显示
    /// </summary>
    public string Access_Type { get; set; } = "offline";

    public string Login_Hint { get; set; }

    /// <summary>
    /// 修改参数 Access_Type=offline 需配置 prompt=consent 提示用户同意，否则无法获取 refresh_token
    /// none 不显示任何身份验证或同意屏幕。不得使用其他值指定
    /// consent 提示用户同意
    /// select_account 提示用户选择帐号
    /// </summary>
    public string Prompt { get; set; } = "consent";
}

/// <summary>
/// access token 请求参数
/// </summary>
public class GoogleAccessTokenModel : PublicAccessTokenModel
{
    public GoogleAccessTokenModel()
    {
        Redirect_Uri = Google.Redirect_Uri;
    }

    /// <summary>
    /// 注册应用时的获取的client_id
    /// </summary>
    public string Client_Id { get; set; } = Google.ClientId;

    /// <summary>
    /// 注册应用时的获取的client_secret。
    /// </summary>
    public string Client_Secret { get; set; } = Google.ClientSecret;

    /// <summary>
    /// 固定值
    /// </summary>
    public string Grant_Type { get; set; } = "authorization_code";
}

/// <summary>
/// refresh token 请求参数
/// </summary>
public class GoogleRefreshTokenModel
{
    /// <summary>
    /// 注册应用时的获取的client_id
    /// </summary>
    public string Client_Id { get; set; } = Google.ClientId;

    /// <summary>
    /// 注册应用时的获取的client_secret。
    /// </summary>
    public string Client_Secret { get; set; } = Google.ClientSecret;

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
public class GoogleUserModel
{
    /// <summary>
    /// token
    /// </summary>
    public string Access_Token { get; set; }
}