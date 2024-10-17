namespace Netnr.Login;

/// <summary>
/// AtomGit
/// </summary>
public class AtomGit
{
    /// <summary>
    /// GET
    /// </summary>
    public static string API_Authorize { get; set; } = "https://atomgit.com/login/oauth/authorize";

    /// <summary>
    /// POST
    /// </summary>
    public static string API_AccessToken { get; set; } = "https://api.atomgit.com/login/oauth/access_token";

    /// <summary>
    /// GET
    /// </summary>
    public static string API_User { get; set; } = "https://api.atomgit.com/user/info";

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
public class AtomGitAuthorizeModel : PublicAuthorizeModel
{
    public AtomGitAuthorizeModel()
    {
        Redirect_Uri = AtomGit.Redirect_Uri;
    }

    /// <summary>
    /// 应用的唯一ID
    /// </summary>
    public string Client_Id { get; set; } = AtomGit.ClientId;
}

/// <summary>
/// access token 请求参数
/// </summary>
public class AtomGitAccessTokenModel : PublicAccessTokenModel
{
    public AtomGitAccessTokenModel()
    {
        Redirect_Uri = AtomGit.Redirect_Uri;
    }

    /// <summary>
    /// 应用的唯一ID
    /// </summary>
    public string Client_Id { get; set; } = AtomGit.ClientId;

    /// <summary>
    /// 应用的密钥信息
    /// </summary>
    public string Client_Secret { get; set; } = AtomGit.ClientSecret;
}

/// <summary>
/// refresh token 请求参数
/// </summary>
public class AtomGitRefreshTokenModel
{
    /// <summary>
    /// 应用的唯一ID
    /// </summary>
    public string Client_Id { get; set; } = AtomGit.ClientId;
    /// <summary>
    /// 应用的密钥信息
    /// </summary>
    public string Client_Secret { get; set; } = AtomGit.ClientSecret;
    /// <summary>
    /// OAuth 2.0规定的授权类型，此处必须是 refresh_token
    /// </summary>
    public string Grant_Type { get; set; } = "refresh_token";
    /// <summary>
    /// 获取的 refresh_token
    /// </summary>
    public string Refresh_Token { get; set; }
}

/// <summary>
/// user 请求参数
/// </summary>
public class AtomGitUserModel
{
    /// <summary>
    /// token
    /// </summary>
    public string Access_Token { get; set; }
}