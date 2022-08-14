namespace Netnr.Login;

public class Weixin
{
    /// <summary>
    /// GET
    /// </summary>
    public static string API_Authorize { get; set; } = "https://open.weixin.qq.com/connect/qrconnect";

    /// <summary>
    /// GET
    /// </summary>
    public static string API_AccessToken { get; set; } = "https://api.weixin.qq.com/sns/oauth2/access_token";

    /// <summary>
    /// GET
    /// </summary>
    public static string API_RefreshToken { get; set; } = "https://api.weixin.qq.com/sns/oauth2/refresh_token";

    /// <summary>
    /// GET
    /// </summary>
    public static string API_User { get; set; } = "https://api.weixin.qq.com/sns/userinfo";

    /// <summary>
    /// APP ID
    /// </summary>
    public static string AppId { get; set; }

    /// <summary>
    /// APP Key
    /// </summary>
    public static string AppSecret { get; set; }

    /// <summary>
    /// 回调
    /// </summary>
    public static string Redirect_Uri { get; set; }
}

/// <summary>
/// authorize 请求参数
/// </summary>
public class WeixinAuthorizeModel : PublicAuthorizeModel
{
    public WeixinAuthorizeModel()
    {
        Redirect_Uri = Weixin.Redirect_Uri;
    }

    /// <summary>
    /// 应用唯一标识
    /// </summary>
    public string AppId { get; set; } = Weixin.AppId;

    public string Response_Type { get; set; } = "code";

    /// <summary>
    /// 应用授权作用域，拥有多个作用域用逗号（,）分隔，网页应用目前仅填写snsapi_login
    /// </summary>
    public string Scope { get; set; } = "snsapi_login";

    /// <summary>
    /// 界面语言，支持cn（中文简体）与en（英文），默认为cn
    /// </summary>
    public string Lang { get; set; } = "cn";
}

/// <summary>
/// access token 请求参数
/// </summary>
public class WeixinAccessTokenModel : PublicAccessTokenModel
{
    public WeixinAccessTokenModel()
    {
        Redirect_Uri = Weixin.Redirect_Uri;
    }

    /// <summary>
    /// 应用唯一标识
    /// </summary>
    public string AppId { get; set; } = Weixin.AppId;

    /// <summary>
    /// 应用密钥AppSecret
    /// </summary>
    public string Secret { get; set; } = Weixin.AppSecret;

    public string Grant_Type { get; set; } = "authorization_code";
}

/// <summary>
/// refresh token 请求参数
/// </summary>
public class WeixinRefreshTokenModel 
{
    /// <summary>
    /// 应用唯一标识
    /// </summary>
    public string AppId { get; set; } = Weixin.AppId;

    public string Grant_Type { get; set; } = "refresh_token";

    /// <summary>
    /// 刷新 token
    /// </summary>
    public string Refresh_Token { get; set; }
}

/// <summary>
/// user 请求参数
/// </summary>
public class WeixinUserModel
{
    /// <summary>
    /// 调用凭证
    /// </summary>
    public string Access_Token { get; set; }

    /// <summary>
    /// 普通用户的标识，对当前开发者帐号唯一
    /// </summary>
    public string OpenId { get; set; }

    /// <summary>
    /// 国家地区语言版本，zh_CN 简体，zh_TW 繁体，en 英语，默认为en
    /// </summary>
    public string Lang { get; set; } = "zh_CN";
}