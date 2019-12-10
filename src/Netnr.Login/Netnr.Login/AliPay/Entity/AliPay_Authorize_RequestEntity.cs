namespace Netnr.Login
{
    /// <summary>
    /// Step1：Oauth2/authorize
    /// </summary>
    public class AliPay_Authorize_RequestEntity
    {
        /// <summary>
        /// 商户的APPID
        /// </summary>
        [Required]
        public string app_id { get; set; } = AliPayConfig.AppId;

        /// <summary>
        /// 页面跳回地址（重定向地址）
        /// </summary>
        [Required]
        public string redirect_uri { get; set; } = AliPayConfig.Redirect_Uri;

        /// <summary>
        /// 商户自定义参数
        /// </summary>
        public string state { get; set; } = System.Guid.NewGuid().ToString("N");

        /// <summary>
        /// 参数传递auth_user
        /// </summary>
        [Required]
        public string scope { get; set; } = "auth_user";
    }
}