namespace Netnr.Login
{
    /// <summary>
    /// Step2：通过Authorization Code获取Access Token
    /// </summary>
    public class QQ_AccessToken_RequestEntity
    {
        /// <summary>
        /// 授权类型，在本步骤中，此值为“authorization_code”。
        /// </summary>
        [Required]
        public string grant_type { get; set; } = "authorization_code";

        /// <summary>
        /// 申请QQ登录成功后，分配给网站的appid。
        /// </summary>
        [Required]
        public string client_id { get; set; } = QQConfig.APPID;

        /// <summary>
        /// 申请QQ登录成功后，分配给网站的appkey。
        /// </summary>
        [Required]
        public string client_secret { get; set; } = QQConfig.APPKey;

        /// <summary>
        /// 上一步返回的authorization code。
        /// 如果用户成功登录并授权，则会跳转到指定的回调地址，并在URL中带上Authorization Code。
        /// 例如，回调地址为www.qq.com/my.php，则跳转到：http://www.qq.com/my.php?code=520DD95263C1CFEA087******
        /// 注意此code会在10分钟内过期。
        /// </summary>
        [Required]
        public string code { get; set; }

        /// <summary>
        /// 与上面一步中传入的redirect_uri保持一致。
        /// </summary>
        [Required]
        public string redirect_uri { get; set; } = QQConfig.Redirect_Uri;

    }
}