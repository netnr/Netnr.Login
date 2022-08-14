namespace Netnr.Login;

public partial class Microsoft
{
    /// <summary>
    /// 旧版本 v4
    /// </summary>
    public static bool IsOld { get; set; } = false;

    /// <summary>
    /// GET
    /// </summary>
    public static string API_Authorize_Old { get; set; } = "https://login.live.com/oauth20_authorize.srf";

    /// <summary>
    /// POST
    /// </summary>
    public static string API_AccessToken_Old { get; set; } = "https://login.live.com/oauth20_token.srf";

    /// <summary>
    /// GET
    /// </summary>
    public static string API_User_Old { get; set; } = "https://apis.live.net/v5.0/me";
}

/// <summary>
/// authorize 请求参数
/// </summary>
public class MicrosoftAuthorizeOldModel : PublicAuthorizeModel
{
    public MicrosoftAuthorizeOldModel()
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
    public string Scope { get; set; } = "wl.signin";
}

/// <summary>
/// access token 请求参数
/// </summary>
public class MicrosoftAccessTokenOldModel : PublicAccessTokenModel
{
    public MicrosoftAccessTokenOldModel()
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
    /// 固定值
    /// </summary>
    public string Grant_Type { get; set; } = "authorization_code";
}