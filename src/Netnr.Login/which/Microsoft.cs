namespace Netnr.Login;

public partial class Microsoft
{
    /// <summary>
    /// GET https://docs.microsoft.com/zh-cn/azure/active-directory/develop/v2-oauth2-auth-code-flow
    /// </summary>
    public static string API_Authorize { get; set; } = "https://login.microsoftonline.com/common/oauth2/v2.0/authorize";

    /// <summary>
    /// POST
    /// </summary>
    public static string API_AccessToken { get; set; } = "https://login.microsoftonline.com/common/oauth2/v2.0/token";

    /// <summary>
    /// GET/POST
    /// </summary>
    public static string API_User { get; set; } = "https://graph.microsoft.com/oidc/userinfo";

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
public class MicrosoftAuthorizeModel : PublicAuthorizeModel
{
    public MicrosoftAuthorizeModel()
    {
        Redirect_Uri = Microsoft.Redirect_Uri;
    }

    /// <summary>
    /// 注册应用时的获取的client_id
    /// </summary>
    public string Client_Id { get; set; } = Microsoft.ClientId;

    /// <summary>
    /// 必须包括授权代码流的 code
    /// </summary>
    public string Response_Type { get; set; } = "code";

    /// <summary>
    /// 作用域
    /// </summary>
    public string Scope { get; set; } = "openid offline_access profile email";

    /// <summary>
    /// 请求访问令牌时的默认值 query
    /// </summary>
    public string Response_Mode { get; set; } = "query";
}

/// <summary>
/// access token 请求参数
/// </summary>
public class MicrosoftAccessTokenModel : PublicAccessTokenModel
{
    public MicrosoftAccessTokenModel()
    {
        Redirect_Uri = Microsoft.Redirect_Uri;
    }

    /// <summary>
    /// 注册应用时的获取的client_id
    /// </summary>
    public string Client_Id { get; set; } = Microsoft.ClientId;

    /// <summary>
    /// 注册应用时的获取的client_secret
    /// </summary>
    public string Client_Secret { get; set; } = Microsoft.ClientSecret;

    /// <summary>
    /// 作用域
    /// </summary>
    public string Scope { get; set; } = "openid offline_access profile email";

    /// <summary>
    /// 固定值
    /// </summary>
    public string Grant_Type { get; set; } = "authorization_code";

    public string Code_Verifier { get; set; }
}

/// <summary>
/// refresh token 请求参数
/// </summary>
public class MicrosoftRefreshTokenModel
{
    /// <summary>
    /// 注册应用时的获取的client_id
    /// </summary>
    public string Client_Id { get; set; } = Microsoft.ClientId;

    /// <summary>
    /// 注册应用时的获取的client_secret
    /// </summary>
    public string Client_Secret { get; set; } = Microsoft.ClientSecret;

    public string Grant_Type { get; set; } = "refresh_token";

    /// <summary>
    /// 作用域
    /// </summary>
    public string Scope { get; set; } = "openid offline_access profile email";

    /// <summary>
    /// 最新的refresh_token
    /// </summary>
    public string Refresh_Token { get; set; }
}

/// <summary>
/// user 请求参数
/// </summary>
public class MicrosoftUserModel
{
    /// <summary>
    /// token
    /// </summary>
    public string Access_Token { get; set; }
}