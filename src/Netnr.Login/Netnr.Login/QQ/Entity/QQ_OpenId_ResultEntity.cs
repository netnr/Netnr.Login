namespace Netnr.Login
{
    /// <summary>
    /// 
    /// </summary>
    public class QQ_OpenId_ResultEntity
    {
        /// <summary>
        /// client id
        /// </summary>
        public string client_id { get; set; }

        /// <summary>
        /// openid是此网站上唯一对应用户身份的标识，
        /// 网站可将此ID进行存储便于用户下次登录时辨识其身份，
        /// 或将其与用户在网站上的原有账号进行绑定。
        /// </summary>
        public string openid { get; set; }
    }
}
