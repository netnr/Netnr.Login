using System;

namespace Netnr.Login
{
    /// <summary>
    /// Step1：获取Authorization Code
    /// Url：http://wiki.connect.qq.com/%E4%BD%BF%E7%94%A8authorization_code%E8%8E%B7%E5%8F%96access_token
    /// </summary>
    public class QQ_Authorization_RequestEntity
    {
        /// <summary>
        /// 授权类型，此值固定为“code”。
        /// </summary>
        [Required]
        public string response_type { get; set; } = "code";

        /// <summary>
        /// 申请QQ登录成功后，分配给应用的appid。
        /// </summary>
        [Required]
        public string client_id { get; set; } = QQConfig.APPID;
        /// <summary>
        /// 成功授权后的回调地址，必须是注册appid时填写的主域名下的地址，
        /// 建议设置为网站首页或网站的用户中心。
        /// 注意需要将url进行URLEncode。
        /// </summary>
        [Required]
        public string redirect_uri { get; set; } = QQConfig.Redirect_Uri;
        /// <summary>
        /// client端的状态值。用于第三方应用防止CSRF攻击，成功授权后回调时会原样带回。
        /// 请务必严格按照流程检查用户与state参数状态的绑定。
        /// </summary>
        [Required]
        public string state { get; set; } = Guid.NewGuid().ToString("N");

        /// <summary>
        /// 请求用户授权时向用户显示的可进行授权的列表。
        /// 可填写的值是API文档中列出的接口，以及一些动作型的授权（目前仅有：do_like），如果要填写多个接口名称，请用逗号隔开。
        /// 例如：scope=get_user_info,list_album,upload_pic,do_like
        /// 不传则默认请求对接口get_user_info进行授权。
        /// 建议控制授权项的数量，只传入必要的接口名称，因为授权项越多，用户越可能拒绝进行任何授权。
        /// </summary>
        public string scope { get; set; } = "get_user_info";

        /// <summary>
        /// 仅PC网站接入时使用。
        /// 用于展示的样式。不传则默认展示为PC下的样式。
        /// 如果传入“mobile”，则展示为mobile端下的样式。
        /// </summary>
        public string display { get; set; }

        /// <summary>
        /// 仅WAP网站接入时使用。
        /// QQ登录页面版本（1：wml版本； 2：xhtml版本），默认值为1。
        /// </summary>
        public string g_ut { get; set; }

    }
}