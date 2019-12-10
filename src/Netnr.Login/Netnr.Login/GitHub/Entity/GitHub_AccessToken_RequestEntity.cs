namespace Netnr.Login
{
    /// <summary>
    /// access token 请求参数
    /// </summary>
    public class GitHub_AccessToken_RequestEntity
    {
        /// <summary>
        /// 注册应用时的获取的client_id
        /// </summary>
        [Required]
        public string client_id { get; set; } = GitHubConfig.ClientID;

        /// <summary>
        /// 注册应用时的获取的client_secret。
        /// </summary>
        [Required]
        public string client_secret { get; set; } = GitHubConfig.ClientSecret;

        /// <summary>
        /// 调用authorize获得的code值。
        /// </summary>
        [Required]
        public string code { get; set; }

        /// <summary>
        /// 回调地址，需需与注册应用里的回调地址一致。
        /// </summary>
        [Required]
        public string redirect_uri { get; set; } = GitHubConfig.Redirect_Uri;

        /// <summary>
        /// Step1 回传的值
        /// </summary>
        public string state { get; set; }
    }
}