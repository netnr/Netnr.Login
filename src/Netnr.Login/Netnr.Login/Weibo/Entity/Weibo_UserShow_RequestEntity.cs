namespace Netnr.Login
{
    /// <summary>
    /// Step4：users/show
    /// Url：http://open.weibo.com/wiki/2/users/show
    /// </summary>
    public class Weibo_UserShow_RequestEntity
    {
        /// <summary>
        /// 采用OAuth授权方式为必填参数，OAuth授权后获得。
        /// </summary>
        [Required]
        public string access_token { get; set; }

        /// <summary>
        /// 需要查询的用户ID。
        /// </summary>
        public long uid { get; set; }

        /// <summary>
        /// 需要查询的用户昵称。
        /// </summary>
        public string screen_name { get; set; }
    }
}