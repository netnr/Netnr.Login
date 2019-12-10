using System;

namespace Netnr.Login
{
    /// <summary>
    /// user
    /// </summary>
    public class StackOverflow_User_RequestEntity
    {
        /// <summary>
        /// 注册应用的Key
        /// </summary>
        [Required]
        public string key { get; set; } = StackOverflowConfig.Key;

        [Required]
        public string site { get; set; } = "stackoverflow";

        [Required]
        public string order { get; set; } = "desc";

        [Required]
        public string sort { get; set; } = "reputation";

        /// <summary>
        /// token
        /// </summary>
        [Required]
        public string access_token { get; set; }

        [Required]
        public string filter { get; set; } = "default";

    }
}