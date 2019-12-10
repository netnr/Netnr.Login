using System;

namespace Netnr.Login
{
    /// <summary>
    /// Step1：获取authorize Code
    /// </summary>
    public class Google_Authorize_RequestEntity
    {
        /// <summary>
        /// 注册应用时的获取的client_id
        /// </summary>
        [Required]
        public string client_id { get; set; } = GoogleConfig.ClientID;

        /// <summary>
        /// 固定值，传 code
        /// </summary>
        [Required]
        public string response_type { get; set; } = "code";

        /// <summary>
        /// 范围值必须以字符串开始openid，然后包括profile或email或两者兼而有之
        /// </summary>
        [Required]
        public string scope { get; set; } = "openid email profile";

        /// <summary>
        /// 鉴权成功之后，重定向到网站
        /// </summary>
        [Required]
        public string redirect_uri { get; set; } = GoogleConfig.Redirect_Uri;

        /// <summary>
        /// 如果您的应用程序在浏览器中不存在用户时需要刷新访问令牌，则将该值设置为offline。 
        /// 此值指示Google授权服务器在您的应用程序第一次将授权代码交换为令牌时返回刷新令牌和访问令牌。
        /// </summary>
        public string access_type = "offline";

        /// <summary>
        /// 请求防伪
        /// </summary>
        public string state { get; set; } = Guid.NewGuid().ToString("N");
    }
}