namespace Netnr.Login
{
    /// <summary>
    /// access token 请求参数
    /// </summary>
    public class DingTalk_AccessToken_ResultEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public int errcode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string errmsg { get; set; }
        /// <summary>
        /// token
        /// </summary>
        public string access_token { get; set; }
    }
}