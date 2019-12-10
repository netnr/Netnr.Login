namespace Netnr.Login
{
    /// <summary>
    /// Step2：Oauth2/get token info
    /// Url：http://open.weibo.com/wiki/Oauth2/get_token_info
    /// </summary>
    public class Weibo_GetTokenInfo_RequestEntity
    {
        /// <summary>
        /// 用户授权时生成的access_token。
        /// </summary>
        [Required]
        public string access_token { get; set; }
    }
}