namespace Netnr.Login
{
    /// <summary>
    /// Step1：Oauth2/authorize
    /// Url：http://open.weibo.com/wiki/Oauth2/authorize
    /// </summary>
    public class Weibo_Authorize_RequestEntity
    {
        /// <summary>
        /// 授权类型，此值固定为“code”。
        /// </summary>
        [Required]
        public string response_type { get; set; } = "code";

        /// <summary>
        /// 申请应用时分配的AppKey。
        /// </summary>
        [Required]
        public string client_id { get; set; } = WeiboConfig.AppKey;

        /// <summary>
        /// 授权回调地址，站外应用需与设置的回调地址一致，站内应用需填写canvas page的地址。
        /// </summary>
        [Required]
        public string redirect_uri { get; set; } = WeiboConfig.Redirect_Uri;

        /// <summary>
        /// 申请scope权限所需参数，可一次申请多个scope权限，用逗号分隔。http://open.weibo.com/wiki/Scope
        /// </summary>
        public string scope { get; set; }

        /// <summary>
        /// 用于保持请求和回调的状态，在回调时，会在Query Parameter中回传该参数。
        /// 开发者可以用这个参数验证请求有效性，也可以记录用户请求授权页前的位置。
        /// 这个参数可用于防止跨站请求伪造（CSRF）攻击
        /// </summary>
        public string state { get; set; } = System.Guid.NewGuid().ToString("N");

        /// <summary>
        /// 授权页面的终端类型
        /// 
        /// 参数取值 类型说明
        /// default	默认的授权页面，适用于web浏览器。
        /// mobile 移动终端的授权页面，适用于支持html5的手机。注：使用此版授权页请用 https://open.weibo.cn/oauth2/authorize 授权接口
        /// wap wap版授权页面，适用于非智能手机。
        /// client 客户端版本授权页面，适用于PC桌面应用。
        /// apponweibo 默认的站内应用授权页，授权后不返回access_token，只刷新站内应用父框架。
        /// </summary>
        public string display { get; set; }

        /// <summary>
        /// 是否强制用户重新登录，true：是，false：否。默认false。
        /// </summary>
        public string forcelogin { get; set; }

        /// <summary>
        /// 授权页语言，缺省为中文简体版，en为英文版。英文版测试中，开发者任何意见可反馈至 @微博API
        /// </summary>
        public string language { get; set; }
    }
}