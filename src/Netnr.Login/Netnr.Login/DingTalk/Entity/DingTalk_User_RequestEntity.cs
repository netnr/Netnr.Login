using System;

namespace Netnr.Login
{
    /// <summary>
    /// user
    /// </summary>
    public class DingTalk_User_RequestEntity
    {
        /// <summary>
        /// 构造，签名
        /// </summary>
        public DingTalk_User_RequestEntity()
        {
            signature = Core.CalcTo.HMAC_SHA256(timestamp, DingTalkConfig.appSecret);
        }

        /// <summary>
        /// appid
        /// </summary>
        [Required]
        public string accessKey { get; set; } = DingTalkConfig.appId;

        /// <summary>
        /// 当前时间戳，单位是毫秒
        /// </summary>
        [Required]
        public string timestamp { get; set; } = DateTime.Now.ToTimestamp(true).ToString();

        /// <summary>
        /// 通过appSecret计算出来的签名值
        /// </summary>
        [Required]
        public string signature { get; set; }
    }
}