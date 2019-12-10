using System;

namespace Netnr.Login
{
    /// <summary>
    /// Step1：获取authorize Code
    /// </summary>
    public class Gitee_Authorize_RequestEntity
    {
        /// <summary>
        /// 注册应用时的获取的client_id
        /// </summary>
        [Required]
        public string client_id { get; set; } = GiteeConfig.ClientID;
        /// <summary>
        /// Gitee鉴权成功之后，重定向到网站
        /// </summary>
        [Required]
        public string redirect_uri { get; set; } = GiteeConfig.Redirect_Uri;

        /// <summary>
        /// 固定值，传 code
        /// </summary>
        public string response_type { get; set; } = "code";

        /// <summary>
        /// 说明：码云不支持该参数
        /// </summary>
        public string state { get; set; } = Guid.NewGuid().ToString("N");
    }
}