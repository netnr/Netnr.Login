using Newtonsoft.Json.Linq;

namespace Netnr.Login
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class MicroSoft_User_ResultEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string first_name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string last_name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string link { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string gender { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public JObject emails { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string locale { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string updated_time { get; set; }
    }
}