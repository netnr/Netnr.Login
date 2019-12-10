namespace Netnr.Login
{
    /// <summary>
    /// 配置
    /// 
    /// 步骤：authorize => access_token => user
    /// </summary>
    public class GiteeConfig
    {
        #region API请求接口

        /// <summary>
        /// GET
        /// </summary>
        public static string API_Authorize = "https://gitee.com/oauth/authorize";

        /// <summary>
        /// POST
        /// </summary>
        public static string API_AccessToken = "https://gitee.com/oauth/token";

        /// <summary>
        /// GET
        /// </summary>
        public static string API_User = "https://gitee.com/api/v5/user";

        #endregion

        /// <summary>
        /// Client ID
        /// </summary>
        public static string ClientID = "";

        /// <summary>
        /// Client Secret
        /// </summary>
        public static string ClientSecret = "";

        /// <summary>
        /// 回调
        /// </summary>
        public static string Redirect_Uri = "";
    }
}