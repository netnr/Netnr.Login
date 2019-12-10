namespace Netnr.Login
{
    /// <summary>
    /// 根据用户ID获取用户信息
    /// Url：http://open.weibo.com/wiki/2/users/show
    /// </summary>
    public class Weibo_UserShow_ResultEntity
    {
        /// <summary>
        /// 用户UID
        /// </summary>
        public long id { get; set; }
        /// <summary>
        /// 字符串型的用户UID
        /// </summary>
        public string idstr { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string screen_name { get; set; }
        /// <summary>
        /// 友好显示名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 用户所在省级ID
        /// </summary>
        public int province { get; set; }
        /// <summary>
        /// 用户所在城市ID
        /// </summary>
        public int city { get; set; }
        /// <summary>
        /// 用户所在地
        /// </summary>
        public string location { get; set; }
        /// <summary>
        /// 用户个人描述
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 用户博客地址
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 用户头像地址（中图），50×50像素
        /// </summary>
        public string profile_image_url { get; set; }
        /// <summary>
        /// 用户的微博统一URL地址
        /// </summary>
        public string profile_url { get; set; }
        /// <summary>
        /// 用户的个性化域名
        /// </summary>
        public string domain { get; set; }
        /// <summary>
        /// 用户的微号
        /// </summary>
        public string weihao { get; set; }
        /// <summary>
        /// 性别，m：男、f：女、n：未知
        /// </summary>
        public string gender { get; set; }
        /// <summary>
        /// {get;set;}粉丝数
        /// </summary>
        public int followers_count { get; set; }
        /// <summary>
        /// 关注数
        /// </summary>
        public int friends_count { get; set; }
        /// <summary>
        /// 微博数
        /// </summary>
        public int statuses_count { get; set; }
        /// <summary>
        /// 收藏数
        /// </summary>
        public int favourites_count { get; set; }
        /// <summary>
        /// 用户创建（注册）时间
        /// </summary>
        public string created_at { get; set; }
        /// <summary>
        /// 暂未支持
        /// </summary>
        public bool following { get; set; }
        /// <summary>
        /// 是否允许所有人给我发私信，true：是，false：否
        /// </summary>
        public bool allow_all_act_msg { get; set; }
        /// <summary>
        /// 是否允许标识用户的地理位置，true：是，false：否
        /// </summary>
        public bool geo_enabled { get; set; }
        /// <summary>
        /// 是否是微博认证用户，即加V用户，true：是，false：否
        /// </summary>
        public bool verified { get; set; }
        /// <summary>
        /// 暂未支持
        /// </summary>
        public int verified_type { get; set; }
        /// <summary>
        /// 用户备注信息，只有在查询用户关系时才返回此字段
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 用户的最近一条微博信息字段 详细
        /// </summary>
        public Newtonsoft.Json.Linq.JObject status { get; set; }
        /// <summary>
        /// 是否允许所有人对我的微博进行评论，true：是，false：否
        /// </summary>
        public bool allow_all_comment { get; set; }
        /// <summary>
        /// 用户头像地址（大图），180×180像素
        /// </summary>
        public string avatar_large { get; set; }
        /// <summary>
        /// 用户头像地址（高清），高清头像原图
        /// </summary>
        public string avatar_hd { get; set; }
        /// <summary>
        /// 认证原因
        /// </summary>
        public string verified_reason { get; set; }
        /// <summary>
        /// boolean{get;set;}该用户是否关注当前登录用户，true：是，false：否
        /// </summary>
        public string follow_me { get; set; }
        /// <summary>
        /// 用户的在线状态，0：不在线、1：在线
        /// </summary>
        public int online_status { get; set; }
        /// <summary>
        /// 用户的互粉数
        /// </summary>
        public int bi_followers_count { get; set; }
        /// <summary>
        /// 用户当前的语言版本，zh-cn：简体中文，zh-tw：繁体中文，en：英语
        /// </summary>
        public string lang { get; set; }
    }
}