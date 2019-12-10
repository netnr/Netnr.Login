using System;

namespace Netnr.Login
{
    /// <summary>
    /// Step1：获取authorize Code
    /// </summary>
    public class StackOverflow_Authorize_RequestEntity
    {
        /// <summary>
        /// 注册应用时的获取的client_id
        /// </summary>
        [Required]
        public string client_id { get; set; } = StackOverflowConfig.ClientId;

        /// <summary>
        /// github鉴权成功之后，重定向到网站
        /// </summary>
        [Required]
        public string redirect_uri { get; set; } = StackOverflowConfig.Redirect_Uri;

        /// <summary>
        /// 自己设定，用于防止跨站请求伪造攻击
        /// </summary>
        [Required]
        public string state { get; set; } = Guid.NewGuid().ToString("N");

        /// <summary>
        /// 
        /// </summary>
        public string scope { get; set; } = "";
    }
}