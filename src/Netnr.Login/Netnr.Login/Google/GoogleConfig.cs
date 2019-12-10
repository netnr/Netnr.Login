namespace Netnr.Login
{
    /// <summary>
    /// 配置
    /// 
    /// 步骤：authorize => access_token => user
    /// </summary>
    public class GoogleConfig
    {
        #region API请求接口

        /// <summary>
        /// GET
        /// </summary>
        public static string API_Authorize = "https://accounts.google.com/o/oauth2/v2/auth";

        /// <summary>
        /// POST
        /// </summary>
        public static string API_AccessToken = "https://oauth2.googleapis.com/token";

        /// <summary>
        /// GET
        /// </summary>
        public static string API_User = "https://www.googleapis.com/oauth2/v3/userinfo";

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