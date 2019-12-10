namespace Netnr.Login
{
    /// <summary>
    /// access token 请求参数
    /// </summary>
    public class MicroSoft_AccessToken_RequestEntity
    {
        /// <summary>
        /// 注册应用时的获取的client_id
        /// </summary>
        [Required]
        public string client_id { get; set; } = MicroSoftConfig.ClientID;

        /// <summary>
        /// 注册应用时的获取的client_secret。
        /// </summary>
        [Required]
        public string client_secret { get; set; } = MicroSoftConfig.ClientSecret;

        /// <summary>
        /// 固定值
        /// </summary>
        [Required]
        public string grant_type { get; set; } = "authorization_code";

        /// <summary>
        /// 调用authorize获得的code值。
        /// </summary>
        [Required]
        public string code { get; set; }

        /// <summary>
        /// 用于获取 authorization_code 的相同 redirect_uri 值
        /// </summary>
        [Required]
        public string redirect_uri { get; set; } = MicroSoftConfig.Redirect_Uri;
    }
}