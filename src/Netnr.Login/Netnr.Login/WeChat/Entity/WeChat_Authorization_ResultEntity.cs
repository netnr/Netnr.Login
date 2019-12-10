namespace Netnr.Login
{
    /// <summary>
    /// 用户允许授权后，将会重定向到redirect_uri的网址上，并且带上code和state参数
    /// 若用户禁止授权，则重定向后不会带上code参数，仅会带上state参数
    /// </summary>
    public class WeChat_Authorization_ResultEntity
    {
        /// <summary>
        /// 授权码
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string state { get; set; }
    }
}