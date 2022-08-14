namespace Netnr.Login;

/// <summary>
/// Gitee 码云
/// </summary>
public class Gitee
{
    /// <summary>
    /// client_id
    /// </summary>
    public static string ClientId { get; set; }

    /// <summary>
    /// Client Secret
    /// </summary>
    public static string ClientSecret { get; set; }

    /// <summary>
    /// redirect_uri
    /// </summary>
    public static string Redirect_Uri { get; set; }

    /// <summary>
    /// GET
    /// </summary>
    public static string API_Authorize { get; set; } = "https://gitee.com/oauth/authorize";

    /// <summary>
    /// POST/GET
    /// </summary>
    public static string API_AccessToken { get; set; } = "https://gitee.com/oauth/token";

    /// <summary>
    /// GET
    /// </summary>
    public static string API_User { get; set; } = "https://gitee.com/api/v5/user";
}

/// <summary>
/// authorize 请求参数
/// </summary>
public class GiteeAuthorizeModel : PublicAuthorizeModel
{
    public GiteeAuthorizeModel()
    {
        Redirect_Uri = Gitee.Redirect_Uri;
    }

    public string Client_Id { get; set; } = Gitee.ClientId;

    /// <summary>
    /// 固定值，传 code
    /// </summary>
    public string Response_Type { get; set; } = "code";
}

/// <summary>
/// access token 请求参数
/// </summary>
public class GiteeAccessTokenModel : PublicAccessTokenModel
{
    public GiteeAccessTokenModel()
    {
        Redirect_Uri = Gitee.Redirect_Uri;
    }
    public string Client_Id { get; set; } = Gitee.ClientId;
    public string Client_Secret { get; set; } = Gitee.ClientSecret;
    /// <summary>
    /// 固定值
    /// </summary>
    public string Grant_Type { get; set; } = "authorization_code";
}

/// <summary>
/// refresh token 请求参数
/// </summary>
public class GiteeRefreshTokenModel
{
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
public class GiteeUserModel
{
    /// <summary>
    /// token
    /// </summary>
    public string Access_Token { get; set; }
}