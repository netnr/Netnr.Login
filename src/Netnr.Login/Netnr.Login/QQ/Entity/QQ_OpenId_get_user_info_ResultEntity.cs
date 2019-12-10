namespace Netnr.Login
{
    /// <summary>
    /// 获取登录用户的昵称、头像、性别
    /// Url：http://wiki.connect.qq.com/get_user_info
    /// </summary>
    public class QQ_OpenId_get_user_info_ResultEntity
    {
        /// <summary>
        /// 返回码
        /// </summary>
        public int ret { get; set; }
        /// <summary>
        /// 如果ret 小于 0，会有相应的错误信息提示，返回数据全部用UTF-8编码。
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 用户在QQ空间的昵称。
        /// </summary>
        public string nickname { get; set; }
        /// <summary>
        /// 大小为30×30像素的QQ空间头像URL。
        /// </summary>
        public string figureurl { get; set; }
        /// <summary>
        /// 大小为50×50像素的QQ空间头像URL。
        /// </summary>
        public string figureurl_1 { get; set; }
        /// <summary>
        /// 大小为100×100像素的QQ空间头像URL。
        /// </summary>
        public string figureurl_2 { get; set; }
        /// <summary>
        /// 大小为40×40像素的QQ头像URL。
        /// </summary>
        public string figureurl_qq_1 { get; set; }
        /// <summary>
        /// 大小为100×100像素的QQ头像URL。需要注意，不是所有的用户都拥有QQ的100x100的头像，但40x40像素则是一定会有。
        /// </summary>
        public string figureurl_qq_2 { get; set; }
        /// <summary>
        /// 性别。 如果获取不到则默认返回"男"
        /// </summary>
        public string gender { get; set; }
        /// <summary>
        /// 标识用户是否为黄钻用户（0：不是；1：是）。
        /// </summary>
        public string is_yellow_vip { get; set; }
        /// <summary>
        /// 标识用户是否为黄钻用户（0：不是；1：是）
        /// </summary>
        public string vip { get; set; }
        /// <summary>
        /// 黄钻等级
        /// </summary>
        public string yellow_vip_level { get; set; }
        /// <summary>
        /// 黄钻等级
        /// </summary>
        public string level { get; set; }
        /// <summary>
        /// 标识是否为年费黄钻用户（0：不是； 1：是）
        /// </summary>
        public string is_yellow_year_vip { get; set; }
    }
}