namespace Netnr.Login
{
    /// <summary>
    /// OpenAPI调用说明_OAuth2.0
    /// 前提说明
    /// 1. 该appid已经开通了该OpenAPI的使用权限。
    ///    从API列表的接口列表中可以看到，有的接口是完全开放的，有的接口则需要提前提交申请，以获取访问权限。
    /// 2. 准备访问的资源是用户授权可访问的。
    ///    网站调用该OpenAPI读写某个openid（用户）的信息时，必须是该用户已经对你的appid进行了该OpenAPI的授权
    ///    （例如用户已经设置了相册不对外公开，则网站是无法读取照片信息的）。
    ///    用户可以进入QQ空间->设置->授权管理进行访问权限的设置。
    /// 3. 已经成功获取到Access Token，并且Access Token在有效期内。
    /// 
    /// 调用OpenAPI接口
    /// 
    /// QQ登录提供了用户信息/动态同步/日志/相册/微博等OpenAPI（详见API列表），
    /// 网站需要将请求发送到某个具体的OpenAPI接口，以访问或修改用户数据。
    /// </summary>
    public class QQ_OpenAPI_RequestEntity
    {
        /// <summary>
        /// 可通过使用Authorization_Code获取Access_Token 或来获取。 
        /// access_token有3个月有效期。
        /// </summary>
        [Required]
        public string access_token { get; set; }

        /// <summary>
        /// 申请QQ登录成功后，分配给应用的appid
        /// </summary>
        [Required]
        public string oauth_consumer_key { get; set; } = QQConfig.APPID;

        /// <summary>
        /// 用户的ID，与QQ号码一一对应。 
        /// 可通过调用https://graph.qq.com/oauth2.0/me?access_token=YOUR_ACCESS_TOKEN 来获取。
        /// </summary>
        [Required]
        public string openid { get; set; }
    }
}