namespace Netnr.Login
{
    /// <summary>
    /// 配置
    /// 
    /// 步骤：authorize => user
    /// </summary>
    public class DingTalkConfig
    {
        #region API请求接口

        // 扫码模式

        /// <summary>
        /// GET
        /// </summary>
        public static string API_Authorize_ScanCode = "https://oapi.dingtalk.com/connect/qrconnect";

        // 密码模式

        /// <summary>
        /// GET
        /// </summary>
        public static string API_Authorize_Password = "https://oapi.dingtalk.com/connect/oauth2/sns_authorize";

        /// <summary>
        /// GET
        /// </summary>
        public static string API_AccessToken = "https://oapi.dingtalk.com/sns/gettoken";

        /// <summary>
        /// POST
        /// </summary>
        public static string API_User = "https://oapi.dingtalk.com/sns/getuserinfo_bycode";

        #endregion

        /// <summary>
        /// appId
        /// </summary>
        public static string appId = "";

        /// <summary>
        /// appSecret
        /// </summary>
        public static string appSecret = "";

        /// <summary>
        /// 回调
        /// </summary>
        public static string Redirect_Uri = "";
    }
}