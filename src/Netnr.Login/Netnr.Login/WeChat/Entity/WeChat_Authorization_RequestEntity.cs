using System;

namespace Netnr.Login
{
    /// <summary>
    /// Step1：获取Authorization Code
    /// Url：http://wiki.connect.qq.com/%E4%BD%BF%E7%94%A8authorization_code%E8%8E%B7%E5%8F%96access_token
    /// </summary>
    public class WeChat_Authorization_RequestEntity
    {
        /// <summary>
        /// 填code
        /// </summary>
        [Required]
        public string response_type { get; set; } = "code";
        /// <summary>
        /// 申请QQ登录成功后，分配给应用的appid。
        /// </summary>
        [Required]
        public string appid { get; set; } = WeChatConfig.AppId;
        /// <summary>
        /// 请使用urlEncode对链接进行处理
        /// </summary>
        [Required]
        public string redirect_uri { get; set; } = WeChatConfig.Redirect_Uri;
        /// <summary>
        /// 用于保持请求和回调的状态，授权请求后原样带回给第三方。该参数可用于防止csrf攻击（跨站请求伪造攻击），建议第三方带上该参数，可设置为简单的随机数加session进行校验
        /// </summary>
        public string state { get; set; } = Guid.NewGuid().ToString("N");

        /// <summary>
        /// 应用授权作用域，拥有多个作用域用逗号（,）分隔，网页应用目前仅填写snsapi_login即
        /// </summary>
        [Required]
        public string scope { get; set; } = "snsapi_login";
    }
}