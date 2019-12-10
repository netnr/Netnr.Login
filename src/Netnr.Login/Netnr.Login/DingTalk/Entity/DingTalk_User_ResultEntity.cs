namespace Netnr.Login
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class DingTalk_User_ResultEntity
    {
        /// <summary>
        /// 用户在钉钉上面的昵称
        /// </summary>
        public string nick { get; set; }
        /// <summary>
        /// 用户在当前开放应用内的唯一标识
        /// </summary>
        public string openid { get; set; }
        /// <summary>
        /// 用户在当前开放应用所属企业的唯一标识
        /// </summary>
        public string unionid { get; set; }
    }
}