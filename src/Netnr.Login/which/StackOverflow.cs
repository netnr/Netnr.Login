namespace Netnr.Login;

/// <summary>
/// StackOverflow
/// </summary>
public class StackOverflow
{
    /// <summary>
    /// Client Id
    /// </summary>
    public static string ClientId { get; set; }

    /// <summary>
    /// Client Secret
    /// </summary>
    public static string ClientSecret { get; set; }

    /// <summary>
    /// Key
    /// </summary>
    public static string Key { get; set; }

    /// <summary>
    /// 回调
    /// </summary>
    public static string Redirect_Uri { get; set; }

    /// <summary>
    /// GET
    /// </summary>
    public static string API_Authorize { get; set; } = "https://stackoverflow.com/oauth";

    /// <summary>
    /// POST
    /// </summary>
    public static string API_AccessToken { get; set; } = "https://stackoverflow.com/oauth/access_token/json";

    /// <summary>
    /// POST
    /// </summary>
    public static string API_User { get; set; } = "https://api.stackexchange.com/2.3/me";
}

/// <summary>
/// authorize 请求参数
/// </summary>
public class StackOverflowAuthorizeModel : PublicAuthorizeModel
{
    public StackOverflowAuthorizeModel()
    {
        Redirect_Uri = StackOverflow.Redirect_Uri;
    }

    public string Client_Id { get; set; } = StackOverflow.ClientId;

    public string Scope { get; set; } = "";
}

/// <summary>
/// access token 请求参数
/// </summary>
public class StackOverflowAccessTokenModel : PublicAccessTokenModel
{
    public StackOverflowAccessTokenModel()
    {
        Redirect_Uri = StackOverflow.Redirect_Uri;
    }

    public string Client_Id { get; set; } = StackOverflow.ClientId;

    public string Client_Secret { get; set; } = StackOverflow.ClientSecret;
}

/// <summary>
/// user 请求参数
/// </summary>
public class StackOverflowUserModel
{
    public string Key { get; set; } = StackOverflow.Key;

    public string Site { get; set; } = "stackoverflow";

    public string Order { get; set; } = "desc";

    public string Sort { get; set; } = "reputation";

    /// <summary>
    /// token
    /// </summary>
    public string Access_Token { get; set; }

    public string Filter { get; set; } = "default";

}