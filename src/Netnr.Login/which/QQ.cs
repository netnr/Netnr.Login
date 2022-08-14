namespace Netnr.Login;

/// <summary>
/// qq
/// </summary>
public class QQ
{
    /// <summary>
    /// APP ID
    /// </summary>
    public static string AppId { get; set; }

    /// <summary>
    /// APP Key
    /// </summary>
    public static string AppKey { get; set; }

    /// <summary>
    /// 回调
    /// </summary>
    public static string Redirect_Uri { get; set; }

    /// <summary>
    /// GET
    /// </summary>
    public static string API_Authorize { get; set; } = "https://graph.qq.com/oauth2.0/authorize";

    /// <summary>
    /// GET
    /// </summary>
    public static string API_AccessToken { get; set; } = "https://graph.qq.com/oauth2.0/token";

    /// <summary>
    /// GET
    /// </summary>
    public static string API_OpenId { get; set; } = "https://graph.qq.com/oauth2.0/me";

    /// <summary>
    /// GET
    /// </summary>
    public static string API_User { get; set; } = "https://graph.qq.com/user/get_user_info";
}

/// <summary>
/// authorize 请求参数
/// Url：http://wiki.connect.qq.com/%E4%BD%BF%E7%94%A8authorization_code%E8%8E%B7%E5%8F%96access_token
/// </summary>
public class QQAuthorizeModel : PublicAuthorizeModel
{
    /// <summary>
    /// 构造
    /// </summary>
    public QQAuthorizeModel()
    {
        Redirect_Uri = QQ.Redirect_Uri;
    }

    public string Response_Type { get; set; } = "code";

    public string Client_Id { get; set; } = QQ.AppId;

    public string Scope { get; set; } = "get_user_info";
    
    public string Display { get; set; }
}

/// <summary>
/// access token 请求参数
/// </summary>
public class QQAccessTokenModel : PublicAccessTokenModel
{
    public QQAccessTokenModel()
    {
        Redirect_Uri = QQ.Redirect_Uri;
    }

    public string Grant_Type { get; set; } = "authorization_code";

    public string Client_Id { get; set; } = QQ.AppId;

    public string Client_Secret { get; set; } = QQ.AppKey;

    /// <summary>
    /// 返回格式
    /// </summary>
    public string Fmt { get; set; } = "json";
}

/// <summary>
/// refresh token 请求参数
/// </summary>
public class QQRefreshTokenModel
{
    public string Grant_Type { get; set; } = "refresh_token";

    public string Client_Id { get; set; } = QQ.AppId;

    public string Client_Secret { get; set; } = QQ.AppKey;

    /// <summary>
    /// 最新的refresh_token
    /// </summary>
    public string Refresh_Token { get; set; }

    /// <summary>
    /// 返回格式
    /// </summary>
    public string Fmt { get; set; } = "json";
}

/// <summary>
/// openid 请求参数
/// </summary>
public class QQOpenIdModel
{
    /// <summary>
    /// token
    /// </summary>
    public string Access_Token { get; set; }

    /// <summary>
    /// 返回格式
    /// </summary>
    public string Fmt { get; set; } = "json";
}

/// <summary>
/// user 请求参数
/// </summary>
public class QQUserModel
{
    /// <summary>
    /// 可通过使用Authorization_Code获取Access_Token 或来获取。 
    /// access_token有3个月有效期。
    /// </summary>
    public string Access_Token { get; set; }

    /// <summary>
    /// 申请QQ登录成功后，分配给应用的appid
    /// </summary>
    public string Oauth_Consumer_Key { get; set; } = QQ.AppId;

    /// <summary>
    /// 用户的ID，与QQ号码一一对应。 
    /// 可通过调用https://graph.qq.com/oauth2.0/me?access_token=YOUR_ACCESS_TOKEN 来获取。
    /// </summary>
    public string OpenId { get; set; }
}