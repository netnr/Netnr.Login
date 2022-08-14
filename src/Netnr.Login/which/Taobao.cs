namespace Netnr.Login;

public class Taobao
{
    /// <summary>
    /// GET
    /// </summary>
    public static string API_Authorize { get; set; } = "https://oauth.taobao.com/authorize";

    /// <summary>
    /// POST
    /// </summary>
    public static string API_AccessToken { get; set; } = "https://oauth.taobao.com/token";

    /// <summary>
    /// GET
    /// </summary>
    public static string API_User { get; set; } = "https://eco.taobao.com/router/rest";

    /// <summary>
    /// Web 淘宝
    /// Tmall 天猫
    /// Wap
    /// </summary>
    public static string View { get; set; } = "web";

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
/// </summary>
public class TaobaoAuthorizeModel : PublicAuthorizeModel
{
    public TaobaoAuthorizeModel()
    {
        Redirect_Uri = Taobao.Redirect_Uri;
    }

    /// <summary>
    /// 授权类型 ，值为code。
    /// </summary>
    public string Response_Type { get; set; } = "code";

    /// <summary>
    /// 等同于appkey，创建应用时获得。
    /// </summary>
    public string Client_Id { get; set; } = Taobao.AppKey;

    /// <summary>
    /// web,可选web、tmall或wap其中一种，默认为web。
    /// Web对应PC端（淘宝logo）浏览器页面样式；
    /// Tmall对应天猫的浏览器页面样式；
    /// Wap对应无线端的浏览器页面样式。
    /// </summary>
    public string View { get; set; } = Taobao.View;
}

/// <summary>
/// access token 请求参数
/// </summary>
public class TaobaoAccessTokenModel : PublicAccessTokenModel
{
    public TaobaoAccessTokenModel()
    {
        Redirect_Uri = Taobao.Redirect_Uri;
    }

    /// <summary>
    /// 等同于appkey，创建应用时获得。
    /// </summary>
    public string Client_Id { get; set; } = Taobao.AppKey;

    /// <summary>
    /// 等同于AppSecret，创建应用时获得。
    /// </summary>
    public string Client_Secret { get; set; } = Taobao.AppSecret;

    /// <summary>
    /// authorization_code	授权类型 ，值为authorization_code
    /// </summary>
    public string Grant_Type { get; set; } = "authorization_code";

    /// <summary>
    /// 可自定义，如1212等；维持应用的状态，传入值与返回值保持一致。
    /// </summary>
    public string State { get; set; } = DateTime.Now.ToString("yyyyMMddHHmmssfff");

    /// <summary>
    /// 可选web、tmall或wap其中一种，
    /// Web对应PC端（淘宝logo）浏览器页面样式；
    /// Tmall对应天猫的浏览器页面样式；
    /// Wap对应无线端的浏览器页面样式。
    /// </summary>
    public string View { get; set; } = "web";

}

/// <summary>
/// refresh token 请求参数
/// </summary>
public class TaobaoRefreshTokenModel
{
    /// <summary>
    /// 等同于appkey，创建应用时获得。
    /// </summary>
    public string Client_Id { get; set; } = Taobao.AppKey;

    /// <summary>
    /// 等同于AppSecret，创建应用时获得。
    /// </summary>
    public string Client_Secret { get; set; } = Taobao.AppSecret;

    /// <summary>
    /// authorization_code	授权类型 ，值为authorization_code
    /// </summary>
    public string Grant_Type { get; set; } = "refresh_token";

    /// <summary>
    /// 刷新 token
    /// </summary>
    public string Refresh_Token { get; set; }

    /// <summary>
    /// 可自定义，如1212等；维持应用的状态，传入值与返回值保持一致。
    /// </summary>
    public string State { get; set; } = DateTime.Now.ToString("yyyyMMddHHmmssfff");

    /// <summary>
    /// 可选web、tmall或wap其中一种，
    /// Web对应PC端（淘宝logo）浏览器页面样式；
    /// Tmall对应天猫的浏览器页面样式；
    /// Wap对应无线端的浏览器页面样式。
    /// </summary>
    public string View { get; set; } = Taobao.View;
}