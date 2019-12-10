namespace Netnr.Login
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class Google_User_ResultEntity
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public string sub { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 名
        /// </summary>
        public string given_name { get; set; }
        /// <summary>
        /// 姓
        /// </summary>
        public string family_name { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string picture { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// 邮箱是否验证
        /// </summary>
        public bool email_verified { get; set; }
        /// <summary>
        /// 语言，国家
        /// </summary>
        public string locale { get; set; }
    }
}