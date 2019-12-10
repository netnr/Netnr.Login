using System;

namespace Netnr.Login
{
    /// <summary>
    /// Step1：获取authorize Code
    /// </summary>
    public class DingTalk_Authorize_RequestEntity
    {
        /// <summary>
        /// 注册应用时的获取的client_id
        /// </summary>
        [Required]
        public string appid { get; set; } = DingTalkConfig.appId;
        /// <summary>
        /// github鉴权成功之后，重定向到网站
        /// </summary>
        [Required]
        public string redirect_uri { get; set; } = DingTalkConfig.Redirect_Uri;
        /// <summary>
        /// 自己设定，用于防止跨站请求伪造攻击
        /// </summary>
        [Required]
        public string state { get; set; } = Guid.NewGuid().ToString("N");

        /// <summary>
        /// 
        /// </summary>
        public string scope { get; set; } = "snsapi_login";

        /// <summary>
        /// 
        /// </summary>
        public string response_type { get; set; } = "code";
    }
}