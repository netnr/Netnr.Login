namespace Netnr.Login
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class AliPay_User_ResultEntity
    {
        /* 正确 */

        /// <summary>
        /// 
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string user_id { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string avatar { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public string province { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string nick_name { get; set; }
        /// <summary>
        /// 学生认证
        /// </summary>
        public string is_student_certified { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string user_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string user_status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string is_certified { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string gender { get; set; }

        /* 错误 */

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