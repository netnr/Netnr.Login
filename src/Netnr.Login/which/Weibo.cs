namespace Netnr.Login;

/// <summary>
/// Weibo 微博
/// </summary>
public class Weibo
{
    /// <summary>
    /// GET
    /// </summary>
    public static string API_Authorize { get; set; } = "https://api.weibo.com/oauth2/authorize";

    /// <summary>
    /// POST
    /// </summary>
    public static string API_AccessToken { get; set; } = "https://api.weibo.com/oauth2/access_token";

    /// <summary>
    /// GET
    /// </summary>
    public static string API_User { get; set; } = "https://api.weibo.com/2/users/show.json";

    /// <summary>
    /// App Key
    /// </summary>
    public static string AppKey { get; set; }

    /// <summary>
    /// App Secret
    /// </summary>
    public static string AppSecret { get; set; }

    /// <summary>
    /// 回调
    /// </summary>
    public static string Redirect_Uri { get; set; }
}

/// <summary>
/// authorize 请求参数
/// http://open.weibo.com/wiki/Oauth2/authorize
/// </summary>
public class WeiboAuthorizeModel : PublicAuthorizeModel
{
    public WeiboAuthorizeModel()
    {
        Redirect_Uri = Weibo.Redirect_Uri;
    }

    /// <summary>
    /// 授权类型，此值固定为“code”。
    /// </summary>
    public string Response_Type { get; set; } = "code";

    /// <summary>
    /// 申请应用时分配的AppKey。
    /// </summary>
    public string Client_Id { get; set; } = Weibo.AppKey;

    /// <summary>
    /// 申请scope权限所需参数，可一次申请多个scope权限，用逗号分隔。http://open.weibo.com/wiki/Scope
    /// </summary>
    public string Scope { get; set; }

    /// <summary>
    /// 授权页面的终端类型
    /// 参数取值 类型说明
    /// default	默认的授权页面，适用于web浏览器。
    /// mobile 移动终端的授权页面，适用于支持html5的手机。注：使用此版授权页请用 https://open.weibo.cn/oauth2/authorize 授权接口
    /// wap wap版授权页面，适用于非智能手机。
    /// client 客户端版本授权页面，适用于PC桌面应用。
    /// apponweibo 默认的站内应用授权页，授权后不返回access_token，只刷新站内应用父框架。
    /// </summary>
    public string Display { get; set; }

    /// <summary>
    /// 是否强制用户重新登录，true：是，false：否。默认false。
    /// </summary>
    public string ForceLogin { get; set; }

    /// <summary>
    /// 授权页语言，缺省为中文简体版，en为英文版。英文版测试中，开发者任何意见可反馈至 @微博API
    /// </summary>
    public string Language { get; set; }
}

/// <summary>
/// access token 请求参数
/// http://open.weibo.com/wiki/Oauth2/access_token
/// </summary>
public class WeiboAccessTokenModel : PublicAccessTokenModel
{
    public WeiboAccessTokenModel()
    {
        Redirect_Uri = Weibo.Redirect_Uri;
    }

    /// <summary>
    /// 申请应用时分配的AppKey。
    /// </summary>
    public string Client_Id { get; set; } = Weibo.AppKey;

    /// <summary>
    /// 申请应用时分配的AppSecret。
    /// </summary>
    public string Client_Secret { get; set; } = Weibo.AppSecret;

    /// <summary>
    /// 请求的类型，填写authorization_code
    /// </summary>
    public string Grant_Type { get; set; } = "authorization_code";
}

/// <summary>
/// user 请求参数
/// http://open.weibo.com/wiki/2/users/show
/// </summary>
public class WeiboUserModel
{
    /// <summary>
    /// 采用OAuth授权方式为必填参数，OAuth授权后获得。
    /// </summary>
    public string Access_Token { get; set; }

    /// <summary>
    /// 需要查询的用户ID。
    /// </summary>
    public long Uid { get; set; }

    /// <summary>
    /// 需要查询的用户昵称。
    /// </summary>
    public string Screen_Name { get; set; }
}