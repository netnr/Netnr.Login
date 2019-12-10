namespace Netnr.Login
{
    /// <summary>
    /// 配置
    /// 
    /// 步骤：authorize => access_token => get_token_info => users/show
    /// </summary>
    public class WeiboConfig
    {
        #region API请求接口
        
        /// <summary>
        /// GET
        /// </summary>
        public static string API_Authorize = "https://api.weibo.com/oauth2/authorize";

        /// <summary>
        /// POST
        /// </summary>
        public static string API_AccessToken = "https://api.weibo.com/oauth2/access_token";
        
        /// <summary>
        /// POST
        /// </summary>
        public static string API_GetTokenInfo = "https://api.weibo.com/oauth2/get_token_info";

        /// <summary>
        /// GET
        /// </summary>
        public static string API_UserShow = "https://api.weibo.com/2/users/show.json";

        #endregion
        
        /// <summary>
        /// App Key
        /// </summary>
        public static string AppKey = "";

        /// <summary>
        /// App Secret
        /// </summary>
        public static string AppSecret = "";

        /// <summary>
        /// 回调
        /// </summary>
        public static string Redirect_Uri = "";
    }
}