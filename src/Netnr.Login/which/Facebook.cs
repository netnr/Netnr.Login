namespace Netnr.Login;

/// <summary>
/// Facebook
/// </summary>
public class Facebook
{
    /// <summary>
    /// GET
    /// </summary>
    public static string API_Authorize { get; set; } = "https://www.facebook.com/v22.0/dialog/oauth";

    /// <summary>
    /// POST
    /// </summary>
    public static string API_AccessToken { get; set; } = "https://graph.facebook.com/v22.0/oauth/access_token";

    /// <summary>
    /// GET
    /// </summary>
    public static string API_User { get; set; } = "https://graph.facebook.com/me";

    /// <summary>
    /// Client ID
    /// </summary>
    public static string ClientId { get; set; } = "";

    /// <summary>
    /// Client Secret
    /// </summary>
    public static string ClientSecret { get; set; } = "";

    /// <summary>
    /// 回调
    /// </summary>
    public static string Redirect_Uri { get; set; } = "";
}

/// <summary>
/// authorize 请求参数
/// </summary>
public class FacebookAuthorizeModel : PublicAuthorizeModel
{
    public FacebookAuthorizeModel()
    {
        Redirect_Uri = Facebook.Redirect_Uri;
    }

    /// <summary>
    /// 注册应用时的获取的client_id
    /// </summary>
    public string Client_Id { get; set; } = Facebook.ClientId;

    public string Response_Type { get; set; } = "code";

    /// <summary>
    /// 权限 https://developers.facebook.com/docs/permissions
    /// </summary>
    public string Scope { get; set; } = "email,public_profile";
}

/// <summary>
/// access token 请求参数
/// </summary>
public class FacebookAccessTokenModel : PublicAccessTokenModel
{
    public FacebookAccessTokenModel()
    {
        Redirect_Uri = Facebook.Redirect_Uri;
    }

    /// <summary>
    /// 注册应用时的获取的client_id
    /// </summary>
    public string Client_Id { get; set; } = Facebook.ClientId;

    /// <summary>
    /// 注册应用时的获取的client_secret。
    /// </summary>
    public string Client_Secret { get; set; } = Facebook.ClientSecret;
}

/// <summary>
/// user 请求参数
/// </summary>
public class FacebookUserModel
{
    /// <summary>
    /// token
    /// </summary>
    public string Access_Token { get; set; }

    public string Fields { get; set; } = "id,name,email,picture.width(512).height(512)";
}
