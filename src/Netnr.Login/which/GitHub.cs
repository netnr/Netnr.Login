namespace Netnr.Login;

public class GitHub
{
    /// <summary>
    /// GET
    /// </summary>
    public static string API_Authorize { get; set; } = "https://github.com/login/oauth/authorize";

    /// <summary>
    /// POST
    /// </summary>
    public static string API_AccessToken { get; set; } = "https://github.com/login/oauth/access_token";

    /// <summary>
    /// GET
    /// </summary>
    public static string API_User { get; set; } = "https://api.github.com/user";

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
public class GitHubAuthorizeModel : PublicAuthorizeModel
{
    public GitHubAuthorizeModel()
    {
        Redirect_Uri = GitHub.Redirect_Uri;
    }

    /// <summary>
    /// 注册应用时的获取的client_id
    /// </summary>
    public string Client_Id { get; set; } = GitHub.ClientId;

    /// <summary>
    /// 建议用于登录和授权应用的特定帐户
    /// </summary>
    public string Login { get; set; }

    /// <summary>
    /// 该参数可选。需要调用Github哪些信息，可以填写多个，以逗号分割，比如：scope=user public_repo。
    /// 如果不填写，那么你的应用程序将只能读取Github公开的信息，比如公开的用户信息，公开的库(repository)信息以及gists信息
    /// </summary>
    public string Scope { get; set; } = "user,public_repo";

    public string Allow_Signup { get; set; }
}

/// <summary>
/// access token 请求参数
/// </summary>
public class GitHubAccessTokenModel : PublicAccessTokenModel
{
    public GitHubAccessTokenModel()
    {
        Redirect_Uri = GitHub.Redirect_Uri;
    }

    /// <summary>
    /// 注册应用时的获取的client_id
    /// </summary>
    public string Client_Id { get; set; } = GitHub.ClientId;

    /// <summary>
    /// 注册应用时的获取的client_secret。
    /// </summary>
    public string Client_Secret { get; set; } = GitHub.ClientSecret;
}

/// <summary>
/// user 请求参数
/// </summary>
public class GitHubUserModel
{
    /// <summary>
    /// token
    /// </summary>
    public string Access_Token { get; set; }
}