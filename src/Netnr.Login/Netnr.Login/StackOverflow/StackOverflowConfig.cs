namespace Netnr.Login
{
    /// <summary>
    /// 配置
    /// 
    /// 步骤：authorize => user
    /// </summary>
    public class StackOverflowConfig
    {
        #region API请求接口

        /// <summary>
        /// GET
        /// </summary>
        public static string API_Authorize = "https://stackoverflow.com/oauth";

        /// <summary>
        /// GET
        /// </summary>
        public static string API_AccessToken = "https://stackoverflow.com/oauth/access_token";

        /// <summary>
        /// POST
        /// </summary>
        public static string API_User = "https://api.stackexchange.com/2.2/me";

        #endregion

        /// <summary>
        /// Client Id
        /// </summary>
        public static string ClientId = "";

        /// <summary>
        /// Client Secret
        /// </summary>
        public static string ClientSecret = "";

        /// <summary>
        /// Key
        /// </summary>
        public static string Key = "";

        /// <summary>
        /// 回调
        /// </summary>
        public static string Redirect_Uri = "";
    }
}