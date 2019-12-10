namespace Netnr.Login
{
    /// <summary>
    /// 配置
    /// 
    /// 步骤：authorize => access_token
    /// </summary>
    public class AliPayConfig
    {
        #region API请求接口

        /// <summary>
        /// GET
        /// </summary>
        public static string API_Authorize = "https://openauth.alipay.com/oauth2/publicAppAuthorize.htm";

        /// <summary>
        /// 网关
        /// </summary>
        public static string API_Gateway = "https://openapi.alipay.com/gateway.do";

        #endregion

        /// <summary>
        /// App Key
        /// </summary>
        public static string AppId = "";

        /// <summary>
        /// App Secret
        /// </summary>
        public static string AppPrivateKey = "";

        /// <summary>
        /// 回调
        /// </summary>
        public static string Redirect_Uri = "";
    }
}