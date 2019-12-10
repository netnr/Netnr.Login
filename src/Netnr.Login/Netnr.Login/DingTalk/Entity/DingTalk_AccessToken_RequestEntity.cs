namespace Netnr.Login
{
    /// <summary>
    /// access token 请求参数
    /// </summary>
    public class DingTalk_AccessToken_RequestEntity
    {
        /// <summary>
        /// 应用的唯一标识key
        /// </summary>
        [Required]
        public string appid { get; set; } = DingTalkConfig.appId;

        /// <summary>
        /// 应用的密钥
        /// </summary>
        [Required]
        public string appsecret { get; set; } = DingTalkConfig.appSecret;
    }
}