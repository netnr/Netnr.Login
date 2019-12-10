namespace Netnr.Login
{
    /// <summary>
    /// access token 请求参数
    /// </summary>
    public class StackOverflow_AccessToken_RequestEntity
    {
        /// <summary>
        /// 注册应用时的获取的client_id
        /// </summary>
        [Required]
        public string client_id { get; set; } = StackOverflowConfig.ClientId;

        /// <summary>
        /// 应用的密钥
        /// </summary>
        [Required]
        public string client_secret { get; set; } = StackOverflowConfig.ClientSecret;

        /// <summary>
        /// 授权得到的code
        /// </summary>
        [Required]
        public string code { get; set; }

        /// <summary>
        /// 回调地址
        /// </summary>
        [Required]
        public string redirect_uri { get; set; } = StackOverflowConfig.Redirect_Uri;
    }
}