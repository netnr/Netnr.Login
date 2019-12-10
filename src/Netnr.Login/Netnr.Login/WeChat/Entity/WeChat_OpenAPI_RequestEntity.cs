namespace Netnr.Login
{
    /// <summary>
    /// 开发者可以通过access_token和openid拉取用户信息了
    /// </summary>
    public class WeChat_OpenAPI_RequestEntity
    {
        /// <summary>
        /// 网页授权接口调用凭证,注意：此access_token与基础支持的access_token不同
        /// </summary>
        [Required]
        public string access_token { get; set; }

        /// <summary>
        /// 用户的唯一标识
        /// </summary>
        [Required]
        public string openid { get; set; }

        /// <summary>
        /// 返回国家地区语言版本，zh_CN 简体，zh_TW 繁体，en 英语
        /// </summary>
        [Required]
        public string lang { get; set; } = "zh_CN";
    }
}