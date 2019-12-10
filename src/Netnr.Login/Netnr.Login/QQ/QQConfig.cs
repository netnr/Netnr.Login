namespace Netnr.Login
{
    /// <summary>
    /// 配置
    /// 
    /// 步骤：Authorization => AccessToken => OpenId => OpenAPI（get_user_info）
    /// </summary>
    public class QQConfig
    {
        #region API请求接口

        /// <summary>
        /// PC网站，GET
        /// </summary>
        public static string API_Authorization_PC = "https://graph.qq.com/oauth2.0/authorize";

        /// <summary>
        /// PC网站，GET
        /// </summary>
        public static string API_AccessToken_PC = "https://graph.qq.com/oauth2.0/token";
        /// <summary>
        /// WAP网站，GET
        /// </summary>
        public static string API_AccessToken_WAP = "https://graph.z.qq.com/moc2/token";

        /// <summary>
        /// PC GET
        /// </summary>
        public static string API_OpenID_PC = "https://graph.qq.com/oauth2.0/me";

        /// <summary>
        /// WAP GET
        /// </summary>
        public static string API_OpenID_WAP = "https://graph.z.qq.com/moc2/me";

        /// <summary>
        /// GET
        /// </summary>
        public static string API_Get_User_Info = "https://graph.qq.com/user/get_user_info";

        #endregion

        /// <summary>
        /// APP ID
        /// </summary>
        public static string APPID = "";

        /// <summary>
        /// APP Key
        /// </summary>
        public static string APPKey = "";

        /// <summary>
        /// 回调
        /// </summary>
        public static string Redirect_Uri = "";
    }
}