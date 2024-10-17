#if Full || Login

namespace Netnr.Login;

/// <summary>
/// ORCID
/// </summary>
public class ORCID
{
    /// <summary>
    /// GET
    /// </summary>
    public static string API_Authorize { get; set; } = "https://orcid.org/oauth/authorize";

    /// <summary>
    /// POST
    /// </summary>
    public static string API_AccessToken { get; set; } = "https://orcid.org/oauth/token";

    /// <summary>
    /// GET
    /// </summary>
    public static string API_User { get; set; } = "https://orcid.org/oauth/userinfo";

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
public class ORCIDAuthorizeModel : PublicAuthorizeModel
{
    public ORCIDAuthorizeModel()
    {
        Redirect_Uri = ORCID.Redirect_Uri;
    }

    /// <summary>
    /// 应用的唯一ID
    /// </summary>
    public string Client_Id { get; set; } = ORCID.ClientId;

    /// <summary>
    /// 授权类型，此处必须是 code
    /// </summary>
    public string Response_type { get; set; } = "code";
    /// <summary>
    /// 
    /// </summary>
    public string Scope { get; set; } = "openid";
}

/// <summary>
/// access token 请求参数
/// </summary>
public class ORCIDAccessTokenModel : PublicAccessTokenModel
{
    public ORCIDAccessTokenModel()
    {
        Redirect_Uri = ORCID.Redirect_Uri;
    }

    /// <summary>
    /// OAuth 2.0规定的授权类型，此处必须是 authorization_code
    /// </summary>
    public string Grant_Type { get; set; } = "authorization_code";

    /// <summary>
    /// 应用的唯一ID，在开发者后台【凭证和基础信息】中可以获得
    /// </summary>
    public string Client_Id { get; set; } = ORCID.ClientId;

    /// <summary>
    /// 应用的密钥信息，在开发者后台【凭证和基础信息】中可以获得，使用挑战码模式时不填写此参数，其他情况必须填写
    /// </summary>
    public string Client_Secret { get; set; } = ORCID.ClientSecret;
}

/// <summary>
/// refresh token 请求参数
/// </summary>
public class ORCIDRefreshTokenModel
{
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
public class ORCIDUserModel
{
    /// <summary>
    /// token
    /// </summary>
    public string Access_Token { get; set; }
}

#endif