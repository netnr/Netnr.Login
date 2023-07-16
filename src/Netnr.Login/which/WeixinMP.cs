namespace Netnr.Login;

/// <summary>
/// WeixinMP 微信（公众平台）
/// </summary>
public class WeixinMP
{
    /// <summary>
    /// GET
    /// </summary>
    public static string API_Authorize { get; set; } = "https://open.weixin.qq.com/connect/oauth2/authorize";

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
public class WeixinMPAuthorizeModel : PublicAuthorizeModel
{
    public WeixinMPAuthorizeModel()
    {
        Redirect_Uri = WeixinMP.Redirect_Uri;
    }

    /// <summary>
    /// 应用唯一标识
    /// </summary>
    public string AppId { get; set; } = WeixinMP.AppId;

    public string Response_Type { get; set; } = "code";

    /// <summary>
    /// 应用授权作用域
    /// snsapi_base （不弹出授权页面，直接跳转，只能获取用户openid）
    /// snsapi_userinfo （弹出授权页面，可通过 openid 拿到昵称、性别、所在地， 即使在未关注的情况下，只要用户授权，也能获取其信息 ）
    /// </summary>
    public string Scope { get; set; } = "snsapi_userinfo";

    /// <summary>
    /// 无论直接打开还是做页面302重定向时候，必须带此参数
    /// </summary>
    public string API_Hash { get; set; } = "#wechat_redirect";

    /// <summary>
    /// 强制此次授权需要用户弹窗确认；默认为 false
    /// </summary>
    public string ForcePopup { get; set; } = "false";
}

/// <summary>
/// access token 请求参数
/// </summary>
public class WeixinMPAccessTokenModel : PublicAccessTokenModel
{
    public WeixinMPAccessTokenModel()
    {
        Redirect_Uri = WeixinMP.Redirect_Uri;
    }

    /// <summary>
    /// 应用唯一标识
    /// </summary>
    public string AppId { get; set; } = WeixinMP.AppId;

    /// <summary>
    /// 应用密钥AppSecret
    /// </summary>
    public string Secret { get; set; } = WeixinMP.AppSecret;

    public string Grant_Type { get; set; } = "authorization_code";
}

/// <summary>
/// refresh token 请求参数
/// </summary>
public class WeixinMPRefreshTokenModel
{
    /// <summary>
    /// 应用唯一标识
    /// </summary>
    public string AppId { get; set; } = WeixinMP.AppId;

    public string Grant_Type { get; set; } = "refresh_token";

    /// <summary>
    /// 刷新 token
    /// </summary>
    public string Refresh_Token { get; set; }
}

/// <summary>
/// user 请求参数
/// </summary>
public class WeixinMPUserModel
{
    /// <summary>
    /// 调用凭证
    /// </summary>
    public string Access_Token { get; set; }

    /// <summary>
    /// 普通用户的标识，对当前开发者账号唯一
    /// </summary>
    public string OpenId { get; set; }

    /// <summary>
    /// 国家地区语言版本，zh_CN 简体，zh_TW 繁体，en 英语，默认为en
    /// </summary>
    public string Lang { get; set; } = "zh_CN";
}