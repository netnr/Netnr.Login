namespace Netnr.Login
{
    /// <summary>
    /// {   
    ///     "uid": 1073880650,
    ///     "appkey": 1352222456,
    ///     "scope": null,
    ///     "create_at": 1352267591,
    ///     "expire_in": 157679471
    /// }
    /// </summary>
    public class Weibo_GetTokenInfo_ResultEntity
    {
        /// <summary>
        /// 授权用户的uid。
        /// </summary>
        public string uid { get; set; }

        /// <summary>
        /// access_token所属的应用appkey。
        /// </summary>
        public string appkey { get; set; }

        /// <summary>
        /// 用户授权的scope权限。
        /// </summary>
        public string scope { get; set; }

        /// <summary>
        /// access_token的创建时间，从1970年到创建时间的秒数。
        /// </summary>
        public string create_at { get; set; }

        /// <summary>
        /// access_token的剩余时间，单位是秒数。
        /// </summary>
        public string expire_in { get; set; }
    }
}