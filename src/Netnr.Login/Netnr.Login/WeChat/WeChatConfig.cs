namespace Netnr.Login
{
    /// <summary>
    /// 配置
    /// 
    /// 步骤：Authorization => AccessToken => OpenId => OpenAPI（UserInfo）
    /// </summary>
    public class WeChatConfig
    {
        #region API请求接口

        /// <summary>
        /// GET
        /// </summary>
        public static string API_Authorization = "https://open.weixin.qq.com/connect/qrconnect";

        /// <summary>
        /// POST
        /// </summary>
        public static string API_AccessToken = "https://api.weixin.qq.com/sns/oauth2/access_token";

        /// <summary>
        /// GET
        /// </summary>
        public static string API_UserInfo = "https://api.weixin.qq.com/sns/userinfo";

        #endregion

        /// <summary>
        /// APP ID
        /// </summary>
        public static string AppId = "";

        /// <summary>
        /// APP Key
        /// </summary>
        public static string AppSecret = "";

        /// <summary>
        /// 回调
        /// </summary>
        public static string Redirect_Uri = "";
    }
}