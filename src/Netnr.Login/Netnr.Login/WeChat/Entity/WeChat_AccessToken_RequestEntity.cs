namespace Netnr.Login
{
    /// <summary>
    /// Step2：通过Authorization Code获取Access Token
    /// </summary>
    public class WeChat_AccessToken_RequestEntity
    {
        /// <summary>
        /// 填authorization_code
        /// </summary>
        [Required]
        public string grant_type { get; set; } = "authorization_code";

        /// <summary>
        /// 应用唯一标识，在微信开放平台提交应用审核通过后获得
        /// </summary>
        [Required]
        public string appid { get; set; } = WeChatConfig.AppId;

        /// <summary>
        /// 应用密钥AppSecret，在微信开放平台提交应用审核通过后获得
        /// </summary>
        [Required]
        public string secret { get; set; } = WeChatConfig.AppSecret;

        /// <summary>
        /// 填写第一步获取的code参数
        /// </summary>
        [Required]
        public string code { get; set; }
    }
}