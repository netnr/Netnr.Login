namespace Netnr.Login
{
    /// <summary>
    /// access_token 信息
    /// </summary>
    public class Google_AccessToken_ResultEntity
    {
        /// <summary>
        /// token
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public int expires_in { get; set; }
        /// <summary>
        /// 授权的作用域
        /// </summary>
        public string scope { get; set; }
        /// <summary>
        /// 固定 Bearer
        /// </summary>
        public string token_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string id_token { get; set; }
    }
}