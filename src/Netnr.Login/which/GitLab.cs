#if Full || Login

namespace Netnr.Login;

/// <summary>
/// GitLab
/// </summary>
public class GitLab
{
    /// <summary>
    /// GET
    /// </summary>
    public static string API_Authorize { get; set; } = "http://gitlab.com/oauth/authorize";

    /// <summary>
    /// POST
    /// </summary>
    public static string API_AccessToken { get; set; } = "https://gitlab.com/oauth/token";

    /// <summary>
    /// GET
    /// </summary>
    public static string API_User { get; set; } = "https://gitlab.com/api/v4/user";

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
public class GitLabAuthorizeModel : PublicAuthorizeModel
{
    public GitLabAuthorizeModel()
    {
        Redirect_Uri = GitLab.Redirect_Uri;
    }

    /// <summary>
    /// 注册应用时的获取的client_id
    /// </summary>
    public string Client_Id { get; set; } = GitLab.ClientId;
    /// <summary>
    /// 
    /// </summary>
    public string Response_Type { get; set; } = "code";
    /// <summary>
    /// 
    /// </summary>
    public string Scope { get; set; } = "read_user";
}

/// <summary>
/// access token 请求参数
/// </summary>
public class GitLabAccessTokenModel : PublicAccessTokenModel
{
    public GitLabAccessTokenModel()
    {
        Redirect_Uri = GitLab.Redirect_Uri;
    }

    /// <summary>
    /// 注册应用时的获取的client_id
    /// </summary>
    public string Client_Id { get; set; } = GitLab.ClientId;

    /// <summary>
    /// 注册应用时的获取的client_secret。
    /// </summary>
    public string Client_Secret { get; set; } = GitLab.ClientSecret;

    public string Grant_Type { get; set; } = "authorization_code";
}

/// <summary>
/// refresh token 请求参数
/// </summary>
public class GitLabRefreshTokenModel
{
    /// <summary>
    /// 注册应用时的获取的client_id
    /// </summary>
    public string Client_Id { get; set; } = GitLab.ClientId;
    /// <summary>
    /// 重定向回调链接
    /// </summary>
    public string Redirect_Uri { get; set; } = GitLab.Redirect_Uri;
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
public class GitLabUserModel
{
    /// <summary>
    /// token
    /// </summary>
    public string Access_Token { get; set; }
}

#endif