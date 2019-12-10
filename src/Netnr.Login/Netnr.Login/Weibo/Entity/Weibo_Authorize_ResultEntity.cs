namespace Netnr.Login
{
    /// <summary>
    /// 请求
    /// </summary>
    public class Weibo_Authorize_ResultEntity
    {
        /// <summary>
        /// 用于第二步调用oauth2/access_token接口，获取授权后的access token。
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 如果传递参数，会回传该参数。
        /// </summary>
        public string state { get; set; }
    }
}