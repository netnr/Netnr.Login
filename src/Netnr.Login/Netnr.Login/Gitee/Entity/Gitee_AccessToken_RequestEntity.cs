namespace Netnr.Login
{
    /// <summary>
    /// access token 请求参数
    /// </summary>
    public class Gitee_AccessToken_RequestEntity
    {
        /// <summary>
        /// 注册应用时的获取的client_id
        /// </summary>
        [Required]
        public string client_id { get; set; } = GiteeConfig.ClientID;

        /// <summary>
        /// 注册应用时的获取的client_secret。
        /// </summary>
        [Required]
        public string client_secret { get; set; } = GiteeConfig.ClientSecret;

        /// <summary>
        /// 调用authorize获得的code值。
        /// </summary>
        [Required]
        public string code { get; set; }

        /// <summary>
        /// 回调地址，需需与注册应用里的回调地址一致。
        /// </summary>
        [Required]
        public string redirect_uri { get; set; } = GiteeConfig.Redirect_Uri;

        /// <summary>
        /// 固定值
        /// </summary>
        public string grant_type { get; set; } = "authorization_code";
    }
}