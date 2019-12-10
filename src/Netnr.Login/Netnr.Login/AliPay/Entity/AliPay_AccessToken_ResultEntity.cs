namespace Netnr.Login
{
    /// <summary>
    /// 返回  access_token
    /// </summary>
    public class AliPay_AccessToken_ResultEntity
    {
        /* 正确信息 */

        /// <summary>
        /// 
        /// </summary>
        public string user_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string expires_in { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string refresh_token { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string re_expires_in { get; set; }

        /* 错误信息 */

        /// <summary>
        /// 
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sub_code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sub_msg { get; set; }
    }
}