namespace Netnr.Login
{
    /// <summary>
    /// 
    /// </summary>
    public class QQ_OpenId_RequestEntity
    {
        /// <summary>
        /// Step3：在Step1中获取到的access token。
        /// Url：http://wiki.connect.qq.com/%E8%8E%B7%E5%8F%96%E7%94%A8%E6%88%B7openid_oauth2-0
        /// </summary>
        [Required]
        public string access_token { get; set; }
    }
}