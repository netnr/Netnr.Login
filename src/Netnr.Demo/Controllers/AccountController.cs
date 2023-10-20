﻿using Netnr.Login;

namespace Netnr.Demo.Controllers.LoginDemo
{
    /// <summary>
    /// Netnr.Login v5
    /// </summary>
    public class AccountController : Controller
    {
        /// <summary>
        /// 说明
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            /*
                LoginTo.EntryOfStep<TBefore, TReq>(LoginWhich, LoginStep, Func<string, string> stateCall)
                每个步骤入口，接收5个参数：LoginWhich、LoginStep、TBefore、TReq、stateCall

                LoginWhich 哪家，枚举对象，如 QQ GitHub 等
                LoginStep 步骤，枚举对象，顺序 Authorize（跳转授权链接）、AccessToken（根据授权码 code 请求令牌）、RefreshToken（刷新令牌，可选）、OpenId（仅QQ）、User（用户信息，不支持Taobao）

                TBefore 之前的结果（上一步返回的结果，用于自动生成请求对象 TReq）
                TReq 请求对象，自定义构建请求参数，传值则不从 TBefore 构建，两者二选一

                stateCall 步骤为 Authorize 构建授权链接 state 字段回调方法

                请求参数类名遵循 LoginWhich + LoginStep + Model
                如 GitHub Authorize Model => GitHub AccessToken Model => GitHub User Model

                AuthorizeResult 为统一接收授权码对象，其它步骤返回的对象均为 DocModel
                DocModel 对象中 Raw 为原始结果字符串，Doc 为 System.Text.Json 组件下的仅读对象            
             */

            return Ok();
        }

        /// <summary>
        /// 赋值 KEY
        /// </summary>
        /// <returns></returns>
        internal static void AssignKey()
        {
            #region 初始化配置
            QQ.AppId = "";
            QQ.AppKey = "";
            QQ.Redirect_Uri = "https://localhost/account/authcallback/qq";

            DingTalk.AppId = "";
            DingTalk.AppSecret = "";
            DingTalk.Redirect_Uri = "";
            //DingTalk.IsScanCode = false; //默认扫码登录，false 密码登录
            //DingTalk.IsOld = true; //默认新模式
            //旧模式授权流程为 Authorize（访问授权链接得到 code ）、User（根据 code 获取用户信息）
            //艹（2022/08/06 辣鸡文档）

            #endregion

            #region 自动读取 appsettings.json 
            
            /*

              "OAuthLogin": {
                //是否启用
                "enable": true,
                "Redirect_Uri": "https://localhost/account/authcallback/{0}", //回调地址
                "QQ": {
                  "AppId": "123",
                  "AppKey": "456"
                },
                "Weixin": {
                  "AppId": "123",
                  "AppSecret": "456"
                },
                "WeixinMP": {
                  "AppId": "123",
                  "AppSecret": "456"
                },
                "Weibo": {
                  "AppKey": "123",
                  "AppSecret": "456"
                },
                "Taobao": {
                  "AppKey": "123",
                  "AppSecret": "456"
                },
                "Alipay": {
                  "AppId": "123",
                  "AppPrivateKey": "456"
                },
                "DingTalk": {
                  "AppId": "123",
                  "AppSecret": "456",
                  "IsOld": true
                },
                "Feishu": {
                  "ClientId": "123",
                  "ClientSecret": "456"
                },
                "Gitee": {
                  "ClientId": "123",
                  "ClientSecret": "456"
                },
                "GitHub": {
                  "ClientId": "123",
                  "ClientSecret": "456"
                },
                "Microsoft": {
                  "ClientId": "123",
                  "ClientSecret": "456",
                  "IsOld": true
                },
                "StackOverflow": {
                  "ClientId": "123",
                  "ClientSecret": "456",
                  "Key": "kkk"
                },
                "Google": {
                  "ClientId": "123",
                  "ClientSecret": "456"
                }
              }

            */

            // AppTo.GetValue 是从 IConfiguration 对象取值的封装
            LoginTo.InitConfig((loginType, field) =>
            {
                object val = null;
                if (field == "Redirect_Uri")
                {
                    val = string.Format(AppTo.GetValue($"OAuthLogin:Redirect_Uri"), loginType.ToString().ToLower());
                }
                else if (field.StartsWith("Is"))
                {
                    val = AppTo.GetValue<bool?>($"OAuthLogin:{loginType}:{field}");
                }
                else if (!field.StartsWith("API_"))
                {
                    val = AppTo.GetValue($"OAuthLogin:{loginType}:{field}");
                }
                return val;
            });

            #endregion
        }

        /// <summary>
        /// 三方登录并跳转授权页面
        /// </summary>
        /// <param name="id">哪家</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Auth([FromRoute] LoginWhich? id)
        {
            AssignKey();

            if (id.HasValue)
            {
                var loginType = id.Value;

                //默认构建请求链接
                DocModel authResult = LoginTo.EntryOfStep<object, object>(loginType, LoginStep.Authorize, stateCall: (state) => $"login_{state}");
                if (!string.IsNullOrEmpty(authResult.Raw))
                {
                    return Redirect(authResult.Raw);
                }

                //自定义构建请求链接
                authResult = LoginTo.EntryOfStep<object, QQAuthorizeModel>(loginType, LoginStep.Authorize, reqModel: new()
                {
                    State = $"bind_{DateTime.Now:yyyyMMddHHmmss}"
                });
                Console.WriteLine(authResult.Raw);
            }

            return BadRequest();
        }

        /// <summary>
        /// 三方登录回调
        /// </summary>
        /// <param name="id">哪家</param>
        /// <param name="authResult">接收授权码</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AuthCallback([FromRoute] LoginWhich id, AuthorizeResult authResult)
        {
            //极简拿到最终用户信息
            var publicUser = LoginTo.Entry(id, authResult);

            var result = publicUser.ToJson(true);
            Console.WriteLine(result);

            return Ok(result);
        }

        /// <summary>
        /// 三方登录回调，所有步骤的信息
        /// </summary>
        /// <param name="id">哪家</param>
        /// <param name="authResult">接收授权码</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AuthCallback_Steps([FromRoute] LoginWhich id, AuthorizeResult authResult)
        {
            //含步骤信息
            (DocModel tokenResult, DocModel openidResult, DocModel userResult, PublicUserResult publicUser) = LoginTo.EntryOfSteps(id, authResult);

            var result = new
            {
                tokenResult,
                openidResult,
                userResult,
                publicUser
            }.ToJson(true);
            Console.WriteLine(result);

            return Ok(result);
        }

        /// <summary>
        /// 三方登录回调，逐步
        /// </summary>
        /// <param name="id">哪家</param>
        /// <param name="authResult">接收授权码</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AuthCallback_Step([FromRoute] LoginWhich? id, AuthorizeResult authResult)
        {
            try
            {
                if (id == null)
                {
                    throw new Exception($"不支持该方式授权 {RouteData.Values["id"]?.ToString()}");
                }
                else if (authResult.NoAuthCode())
                {
                    throw new Exception($"授权失败");
                }
                else
                {
                    var loginType = id.Value;
                    Console.WriteLine($"\r\n------- Sign in with {loginType} {DateTime.Now:yyyy-MM-dd HH:mm:ss}\r\n");

                    //step: access token（非 旧版 DingTalk）
                    DocModel tokenResult = null;
                    //step: openid (仅 QQ)
                    DocModel openidResult = null;
                    //step: user (非 Taobao)
                    DocModel userResult = null;

                    if (!(loginType == LoginWhich.DingTalk && DingTalk.IsOld))
                    {
                        tokenResult = LoginTo.EntryOfStep<AuthorizeResult, object>(loginType, LoginStep.AccessToken, beforeResult: authResult);
                        Console.WriteLine($"\r\n{nameof(LoginStep.AccessToken)}");
                        Console.WriteLine(tokenResult.Doc.ToJson(true));

                        //step: refresh token （可选，仅支持部分）
                        if (!new[] { LoginWhich.Weibo, LoginWhich.Taobao, LoginWhich.GitHub, LoginWhich.StackOverflow }.Contains(loginType)
                            && !(loginType == LoginWhich.Microsoft && Login.Microsoft.IsOld))
                        {
                            tokenResult = LoginTo.EntryOfStep<DocModel, object>(loginType, LoginStep.RefreshToken, beforeResult: tokenResult);
                            Console.WriteLine($"\r\n{nameof(LoginStep.RefreshToken)}");
                            Console.WriteLine(tokenResult.Doc.ToJson(true));
                        }
                    }
                    if (loginType == LoginWhich.QQ)
                    {
                        openidResult = LoginTo.EntryOfStep<DocModel, object>(loginType, LoginStep.OpenId, beforeResult: tokenResult);
                        userResult = LoginTo.EntryOfStep<DocModel[], object>(loginType, LoginStep.User, beforeResult: new[] { tokenResult, openidResult });
                    }
                    else if (loginType == LoginWhich.DingTalk && DingTalk.IsOld)
                    {
                        userResult = LoginTo.EntryOfStep<object, AuthorizeResult>(loginType, LoginStep.User, reqModel: authResult);
                    }
                    else if (loginType != LoginWhich.Taobao)
                    {
                        userResult = LoginTo.EntryOfStep<DocModel, object>(loginType, LoginStep.User, beforeResult: tokenResult);
                    }

                    if (openidResult != null)
                    {
                        Console.WriteLine($"\r\n{nameof(LoginStep.OpenId)}");
                        Console.WriteLine(openidResult.Doc.ToJson(true));
                    }
                    if (userResult != null)
                    {
                        Console.WriteLine($"\r\n{nameof(LoginStep.User)}");
                        Console.WriteLine(userResult.Doc.ToJson(true));
                    }

                    return Ok("Done!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest($"授权失败 {ex.Message}");
            }
        }

        /// <summary>
        /// 三方登录回调，自定义构建请求参数
        /// </summary>
        /// <param name="code">接收授权码</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AuthCallback_GitHub(string code)
        {
            //step: access token
            DocModel tokenResult = LoginTo.EntryOfStep<object, GitHubAccessTokenModel>(LoginWhich.GitHub, LoginStep.AccessToken, reqModel: new GitHubAccessTokenModel()
            {
                Code = code
            });
            Console.WriteLine(tokenResult.Doc.ToJson(true));

            //step: user
            DocModel userResult = LoginTo.EntryOfStep<object, GitHubUserModel>(LoginWhich.GitHub, LoginStep.User, reqModel: new GitHubUserModel()
            {
                Access_Token = tokenResult.Doc.GetValue("access_token")
            });

            Console.WriteLine(userResult.Doc.ToJson(true));

            return Content(userResult.Raw);
        }
    }
}
