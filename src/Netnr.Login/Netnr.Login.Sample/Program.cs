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
            var lc = new LoginClient(LoginBase.LoginType.AliPay);

            //拷贝授权链接在浏览器打开，授权后拿到code，并手动赋值，手动赋值需解码
            var URL = lc.Auth();
            Console.WriteLine(URL);

            var ar = new LoginBase.AuthorizeResult();

            ar.code = "";
            ar.auth_code = "";
            //此处打断点，赋值上面拿到的code再继续
            ar.code = ar.code.ToDecode();

            lc.AuthCallback(ar);
        }

        public class LoginClient
        {
            private readonly LoginBase.LoginType? loginType;

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
                if (!string.IsNullOrWhiteSpace(authorizeResult.code) || !string.IsNullOrWhiteSpace(authorizeResult.auth_code))
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