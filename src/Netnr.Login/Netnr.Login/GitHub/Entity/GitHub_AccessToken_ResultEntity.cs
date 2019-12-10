namespace Netnr.Login
{
    /// <summary>
    /// access_token 信息
    /// </summary>
    public class GitHub_AccessToken_ResultEntity
    {
        /// <summary>
        /// access_token
        /// </summary>
        public string access_token { get; set; }
        
        /// <summary>
        /// 类型
        /// </summary>
        public string token_type { get; set; }

        /// <summary>
        /// 授权的信息
        /// </summary>
        public string scope { get; set; }
    }
}