namespace Netnr.Login
{
    /// <summary>
    /// access_token 信息
    /// </summary>
    public class MicroSoft_AccessToken_ResultEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public string token_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int expires_in { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string scope { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string user_id { get; set; }
    }
}