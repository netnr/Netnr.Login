# Netnr.Login
> 第三方OAuth授权登录

### 支持第三方登录
<table>
    <tr><th>三方</th><th>参考文档</th></tr>
    <tr>
        <td><img src="https://static.netnr.com/static/login/qq.svg" height="30" title="QQ"></td>
        <td><a href="https://wiki.connect.qq.com/准备工作_oauth2-0">参考文档</a></td>
    </tr>
    <tr>
        <td><img src="https://static.netnr.com/static/login/wechat.svg" height="30" title="微信/WeChat"></td>
        <td><a href="https://open.weixin.qq.com/cgi-bin/showdocument?action=dir_list&t=resource/res_list&verify=1&id=open1419316505&token=&lang=zh_CN">参考文档</a></td>
    </tr>
    <tr>
        <td><img src="https://static.netnr.com/static/login/weibo.svg" height="30" title="新浪微博"></td>
        <td><a href="https://open.weibo.com/wiki/授权机制说明">参考文档</a></td>
    </tr>
    <tr>
        <td><img src="https://static.netnr.com/static/login/github.svg" height="30" title="GitHub"></td>
        <td><a href="https://developer.github.com/apps/building-oauth-apps/authorizing-oauth-apps">参考文档</a></td>
    </tr>
    <tr>
        <td><img src="https://static.netnr.com/static/login/gitee.svg" height="30" title="码云/Gitee"></td>
        <td><a href="https://gitee.com/api/v5/oauth_doc">参考文档</a></td>
    </tr>
    <tr>
        <td><img src="https://static.netnr.com/static/login/taobao.svg" height="30" title="淘宝/天猫"></td>
        <td><a href="https://open.taobao.com/doc.htm?spm=a219a.7386797.0.0.4e00669acnkQy6&source=search&docId=105590&docType=1">参考文档</a></td>
    </tr>
    <tr>
        <td><img src="https://static.netnr.com/static/login/microsoft.svg" height="30" title="微软/Microsoft"></td>
        <td><a href="https://docs.microsoft.com/zh-cn/graph/auth/">参考文档</a></td>
    </tr>
    <tr>
        <td><img src="https://static.netnr.com/static/login/dingtalk.svg" height="30" title="钉钉/DingTalk"></td>
        <td><a href="https://ding-doc.dingtalk.com/doc#/serverapi2/kymkv6">参考文档</a></td>
    </tr>
    <tr>
        <td><img src="https://static.netnr.com/static/login/google.svg" height="30" title="谷歌/Google"></td>
        <td><a href="https://developers.google.com/identity/protocols/OpenIDConnect">参考文档</a></td>
    </tr>
    <tr>
        <td><img src="https://static.netnr.com/static/login/alipay.svg" height="30" title="支付宝/AliPay"></td>
        <td><a href="https://docs.open.alipay.com/263/105809">参考文档</a></td>
    </tr>
    <tr>
        <td><img src="https://static.netnr.com/static/login/stackoverflow.svg" height="30" title="Stack Overflow"></td>
        <td><a href="https://api.stackexchange.com">参考文档</a></td>
    </tr>
</table>

----------
### [更新日志](CHANGELOG.md)

----------
### 安装 (NuGet)
```
Install-Package Netnr.Login
```
修改配置信息（密钥、回调等）

> 提醒：一般所有第三方登录都有一个 **state** 参数，用于防止CSRF攻击（防伪），可以利用该参数添加 登录、注册 的标注前缀

### 框架
- .NETStandard 2.1
- .NETFramework 4.0

### 使用
```csharp
/*
 * 这是测试代码，只为调通每一个接口，拿到 唯一标识
 * 实际应用中还要处理昵称、邮箱、头像等，可参考个站开源项目：https://github.com/netnr/blog
 */

using System;

namespace Netnr.Login.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var lc = new LoginClient(LoginBase.LoginType.StackOverflow);

            //拷贝授权链接在浏览器打开，授权后拿到code，并手动赋值，手动赋值需解码
            var url = lc.Auth();

            var ar = new LoginBase.AuthorizeResult();
            ar.code = "";
            //此处打断点，赋值上面拿到的code再继续
            ar.code = ar.code.ToDecode();

            lc.AuthCallback(ar);
        }

        public class LoginClient
        {
            private LoginBase.LoginType? loginType;

            public LoginClient(LoginBase.LoginType _loginType)
            {
                loginType = _loginType;

                // 配置
                QQConfig.APPID = "XXX";
                QQConfig.APPKey = "XXX";
                //回调地址，与申请填写的地址保持一致
                QQConfig.Redirect_Uri = "https://rf2.netnr.com/account/authcallback/qq";

                WeChatConfig.AppId = "";
                WeChatConfig.AppSecret = "";
                WeChatConfig.Redirect_Uri = "";

                WeiboConfig.AppKey = "";
                WeiboConfig.AppSecret = "";
                WeiboConfig.Redirect_Uri = "";

                GitHubConfig.ClientID = "";
                GitHubConfig.ClientSecret = "";
                GitHubConfig.Redirect_Uri = "";
                //申请的应用名称，非常重要
                GitHubConfig.ApplicationName = "netnrf";

                TaoBaoConfig.AppKey = "";
                TaoBaoConfig.AppSecret = "";
                TaoBaoConfig.Redirect_Uri = "";

                MicroSoftConfig.ClientID = "";
                MicroSoftConfig.ClientSecret = "";
                MicroSoftConfig.Redirect_Uri = "";

                DingTalkConfig.appId = "";
                DingTalkConfig.appSecret = "";
                DingTalkConfig.Redirect_Uri = "";

                GiteeConfig.ClientID = "";
                GiteeConfig.ClientSecret = "";
                GiteeConfig.Redirect_Uri = "";

                GoogleConfig.ClientID = "";
                GoogleConfig.ClientSecret = "";
                GoogleConfig.Redirect_Uri = "";

                AliPayConfig.AppId = "";
                AliPayConfig.AppPrivateKey = "";
                AliPayConfig.Redirect_Uri = "";

                StackOverflowConfig.ClientId = "";
                StackOverflowConfig.ClientSecret = "";
                StackOverflowConfig.Key = "";
                StackOverflowConfig.Redirect_Uri = "";
            }

            /// <summary>
            /// 生成请求链接
            /// </summary>
            /// <param name="authType">在防伪参数追加信息（可用于登录、注册、绑定、解绑区分）</param>
            /// <returns></returns>
            public string Auth(string authType = "")
            {
                var url = string.Empty;

                switch (loginType)
                {
                    case LoginBase.LoginType.QQ:
                        {
                            var reqe = new QQ_Authorization_RequestEntity();
                            if (!string.IsNullOrWhiteSpace(authType))
                            {
                                reqe.state = authType + reqe.state;
                            }
                            url = QQ.AuthorizationHref(reqe);
                        }
                        break;
                    case LoginBase.LoginType.WeiBo:
                        {
                            var reqe = new Weibo_Authorize_RequestEntity();
                            if (!string.IsNullOrWhiteSpace(authType))
                            {
                                reqe.state = authType + reqe.state;
                            }
                            url = Weibo.AuthorizeHref(reqe);
                        }
                        break;
                    case LoginBase.LoginType.GitHub:
                        {
                            var reqe = new GitHub_Authorize_RequestEntity();
                            if (!string.IsNullOrWhiteSpace(authType))
                            {
                                reqe.state = authType + reqe.state;
                            }
                            url = GitHub.AuthorizeHref(reqe);
                        }
                        break;
                    case LoginBase.LoginType.TaoBao:
                        {
                            var reqe = new TaoBao_Authorize_RequestEntity();
                            if (!string.IsNullOrWhiteSpace(authType))
                            {
                                reqe.state = authType + reqe.state;
                            }
                            url = TaoBao.AuthorizeHref(reqe);
                        }
                        break;
                    case LoginBase.LoginType.MicroSoft:
                        {
                            var reqe = new MicroSoft_Authorize_RequestEntity();
                            if (!string.IsNullOrWhiteSpace(authType))
                            {
                                reqe.state = authType + reqe.state;
                            }
                            url = MicroSoft.AuthorizeHref(reqe);
                        }
                        break;
                    case LoginBase.LoginType.WeChat:
                        {
                            var reqe = new WeChat_Authorization_RequestEntity();
                            if (!string.IsNullOrWhiteSpace(authType))
                            {
                                reqe.state = authType + reqe.state;
                            }
                            url = WeChat.AuthorizationHref(reqe);
                        }
                        break;
                    case LoginBase.LoginType.DingTalk:
                        {
                            var reqe = new DingTalk_Authorize_RequestEntity();
                            if (!string.IsNullOrWhiteSpace(authType))
                            {
                                reqe.state = authType + reqe.state;
                            }
                            //扫描模式
                            url = DingTalk.AuthorizeHref_ScanCode(reqe);

                            //密码模式
                            //url = DingTalk.AuthorizeHref_Password(reqe);
                        }
                        break;
                    case LoginBase.LoginType.Gitee:
                        {
                            var reqe = new Gitee_Authorize_RequestEntity();
                            if (!string.IsNullOrWhiteSpace(authType))
                            {
                                reqe.state = authType + reqe.state;
                            }
                            url = Gitee.AuthorizeHref(reqe);
                        }
                        break;
                    case LoginBase.LoginType.Google:
                        {
                            var reqe = new Google_Authorize_RequestEntity();
                            if (!string.IsNullOrWhiteSpace(authType))
                            {
                                reqe.state = authType + reqe.state;
                            }
                            url = Google.AuthorizeHref(reqe);
                        }
                        break;
                    case LoginBase.LoginType.AliPay:
                        {
                            var reqe = new AliPay_Authorize_RequestEntity();
                            if (!string.IsNullOrWhiteSpace(authType))
                            {
                                reqe.state = authType + reqe.state;
                            }
                            url = AliPay.AuthorizeHref(reqe);
                        }
                        break;
                    case LoginBase.LoginType.StackOverflow:
                        {
                            var reqe = new StackOverflow_Authorize_RequestEntity();
                            if (!string.IsNullOrWhiteSpace(authType))
                            {
                                reqe.state = authType + reqe.state;
                            }
                            url = StackOverflow.AuthorizeHref(reqe);
                        }
                        break;
                }

                return url;
            }

            /// <summary>
            /// 回调方法
            /// </summary>
            /// <param name="authorizeResult">接收授权码、防伪参数</param>
            public void AuthCallback(LoginBase.AuthorizeResult authorizeResult)
            {
                if (string.IsNullOrWhiteSpace(authorizeResult.code))
                {
                    //打开链接没登录授权
                }
                else
                {
                    //唯一标示
                    string OpenId = string.Empty;

                    switch (loginType)
                    {
                        case LoginBase.LoginType.QQ:
                            {
                                //获取 access_token
                                var tokenEntity = QQ.AccessToken(new QQ_AccessToken_RequestEntity()
                                {
                                    code = authorizeResult.code
                                });

                                //获取 OpendId
                                var openidEntity = QQ.OpenId(new QQ_OpenId_RequestEntity()
                                {
                                    access_token = tokenEntity.access_token
                                });

                                //获取 UserInfo
                                _ = QQ.OpenId_Get_User_Info(new QQ_OpenAPI_RequestEntity()
                                {
                                    access_token = tokenEntity.access_token,
                                    openid = openidEntity.openid
                                });

                                //身份唯一标识
                                OpenId = openidEntity.openid;
                            }
                            break;
                        case LoginBase.LoginType.WeiBo:
                            {
                                //获取 access_token
                                var tokenEntity = Weibo.AccessToken(new Weibo_AccessToken_RequestEntity()
                                {
                                    code = authorizeResult.code
                                });

                                //获取 access_token 的授权信息
                                var tokenInfoEntity = Weibo.GetTokenInfo(new Weibo_GetTokenInfo_RequestEntity()
                                {
                                    access_token = tokenEntity.access_token
                                });

                                //获取 users/show
                                _ = Weibo.UserShow(new Weibo_UserShow_RequestEntity()
                                {
                                    access_token = tokenEntity.access_token,
                                    uid = Convert.ToInt64(tokenInfoEntity.uid)
                                });

                                OpenId = tokenEntity.access_token;
                            }
                            break;
                        case LoginBase.LoginType.WeChat:
                            {
                                //获取 access_token
                                var tokenEntity = WeChat.AccessToken(new WeChat_AccessToken_RequestEntity()
                                {
                                    code = authorizeResult.code
                                });

                                //获取 user
                                _ = WeChat.Get_User_Info(new WeChat_OpenAPI_RequestEntity()
                                {
                                    access_token = tokenEntity.access_token,
                                    openid = tokenEntity.openid
                                });

                                //身份唯一标识
                                OpenId = tokenEntity.openid;
                            }
                            break;
                        case LoginBase.LoginType.GitHub:
                            {
                                //获取 access_token
                                var tokenEntity = GitHub.AccessToken(new GitHub_AccessToken_RequestEntity()
                                {
                                    code = authorizeResult.code
                                });

                                //获取 user
                                var userEntity = GitHub.User(new GitHub_User_RequestEntity()
                                {
                                    access_token = tokenEntity.access_token
                                });

                                OpenId = userEntity.id.ToString();
                            }
                            break;
                        case LoginBase.LoginType.TaoBao:
                            {
                                //获取 access_token
                                var tokenEntity = TaoBao.AccessToken(new TaoBao_AccessToken_RequestEntity()
                                {
                                    code = authorizeResult.code
                                });

                                OpenId = tokenEntity.open_uid;
                            }
                            break;
                        case LoginBase.LoginType.MicroSoft:
                            {
                                //获取 access_token
                                var tokenEntity = MicroSoft.AccessToken(new MicroSoft_AccessToken_RequestEntity()
                                {
                                    code = authorizeResult.code
                                });

                                //获取 user
                                var userEntity = MicroSoft.User(new MicroSoft_User_RequestEntity()
                                {
                                    access_token = tokenEntity.access_token
                                });

                                OpenId = userEntity.id.ToString();
                            }
                            break;
                        case LoginBase.LoginType.DingTalk:
                            {
                                //获取 user
                                var userEntity = DingTalk.User(new DingTalk_User_RequestEntity(), authorizeResult.code);

                                OpenId = userEntity?.openid;
                            }
                            break;
                        case LoginBase.LoginType.Gitee:
                            {
                                //获取 access_token
                                var tokenEntity = Gitee.AccessToken(new Gitee_AccessToken_RequestEntity()
                                {
                                    code = authorizeResult.code
                                });

                                //获取 user
                                var userEntity = Gitee.User(new Gitee_User_RequestEntity()
                                {
                                    access_token = tokenEntity.access_token
                                });

                                OpenId = userEntity.id.ToString();
                            }
                            break;
                        case LoginBase.LoginType.Google:
                            {
                                //获取 access_token
                                var tokenEntity = Google.AccessToken(new Google_AccessToken_RequestEntity()
                                {
                                    code = authorizeResult.code
                                });

                                //获取 user
                                var userEntity = Google.User(new Google_User_RequestEntity()
                                {
                                    access_token = tokenEntity.access_token
                                });

                                OpenId = userEntity.sub;
                            }
                            break;
                        case LoginBase.LoginType.AliPay:
                            {
                                //获取 access_token
                                var tokenEntity = AliPay.AccessToken(new AliPay_AccessToken_RequestEntity()
                                {
                                    code = authorizeResult.auth_code
                                });

                                //实际上这一步已经获取到 OpenId，登录验证可以了，获取个人信息还需调用下面的接口
                                //tokenEntity.user_id

                                //获取 user
                                var userEntity = AliPay.User(new AliPay_User_RequestEntity()
                                {
                                    auth_token = tokenEntity.access_token
                                });

                                OpenId = userEntity.user_id;
                            }
                            break;
                        case LoginBase.LoginType.StackOverflow:
                            {
                                //获取 access_token
                                var tokenEntity = StackOverflow.AccessToken(new StackOverflow_AccessToken_RequestEntity()
                                {
                                    code = authorizeResult.code
                                });

                                //获取 user
                                var userEntity = StackOverflow.User(new StackOverflow_User_RequestEntity()
                                {
                                    access_token = tokenEntity.access_token
                                });

                                OpenId = userEntity.user_id;
                            }
                            break;
                    }

                    //拿到登录标识
                    if (string.IsNullOrWhiteSpace(OpenId))
                    {
                        //TO DO
                    }
                }

            }
        }
    }
}
```

### Source
- <https://github.com/netnr/Netnr.Login>
- <https://gitee.com/netnr/Netnr.Login>