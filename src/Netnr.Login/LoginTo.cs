namespace Netnr.Login;

/// <summary>
/// 登录
/// </summary>
public class LoginTo
{
    /// <summary>
    /// 授权链接
    /// </summary>
    /// <param name="url"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    internal static string AuthorizeLink<TModel>(string url, TModel model = default) where TModel : class, new()
    {
        var result = $"{url}?{(model ?? new TModel()).ToParameters()}";
        return result;
    }

    /// <summary>
    /// GET
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <param name="url"></param>
    /// <param name="model"></param>
    /// <param name="headers">头部参数</param>
    /// <returns></returns>
    internal static string Get<TModel>(string url, TModel model, Dictionary<string, string> headers = null) where TModel : class, new()
    {
        var hwr = HttpTo.HWRequest($"{url}?{model.ToParameters()}");
        if (headers != null)
        {
            foreach (var key in headers.Keys)
            {
                hwr.Headers.Add(key, headers[key]);
            }
        }
        var result = HttpTo.Url(hwr);
        return result;
    }

    /// <summary>
    /// POST
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <param name="url"></param>
    /// <param name="model"></param>
    /// <param name="sendJson">发送 JSON</param>
    /// <returns></returns>
    internal static string Post<TModel>(string url, TModel model, bool sendJson = false) where TModel : class, new()
    {
        var hwr = HttpTo.HWRequest(url, "POST", sendJson ? model.ToJson() : model.ToParameters());
        hwr.Accept = "application/json";
        if (sendJson)
        {
            hwr.ContentType = hwr.Accept;
        }
        var result = HttpTo.Url(hwr);
        return result;
    }

    /// <summary>
    /// 初始化配置
    /// </summary>
    /// <param name="varCall"></param>
    public static void InitConfig(Func<LoginWhich, string, object> varCall)
    {
        var arr = new[] {
            typeof(QQ),
            typeof(Weixin),
            typeof(WeixinMP),
            typeof(Weibo),
            typeof(Taobao),
            typeof(Alipay),
            typeof(DingTalk),
            typeof(Feishu),
            typeof(Huawei),
            typeof(Xiaomi),
            typeof(AtomGit),
            typeof(Gitee),
            typeof(GitHub),
            typeof(GitLab),
            typeof(Microsoft),
            typeof(StackOverflow),
            typeof(Google),
            typeof(Facebook),
            typeof(ORCID)
        };
        foreach (var item in arr)
        {
            Enum.TryParse(item.Name, true, out LoginWhich loginType);

            var pis = item.GetProperties();
            foreach (var pi in pis)
            {
                var val = varCall.Invoke(loginType, pi.Name);
                if (val != null)
                {
                    pi.SetValue(item, val);
                }
            }
        }
    }

    /// <summary>
    /// 逐步调用
    /// </summary>
    /// <typeparam name="TBefore"></typeparam>
    /// <typeparam name="TReq"></typeparam>
    /// <param name="which">哪家</param>
    /// <param name="step">步骤</param>
    /// <param name="beforeResult">之前结果（用于自动生成请求参数）</param>
    /// <param name="reqModel">请求参数（默认根据 beforeResult 生成）</param>
    /// <param name="stateCall">授权链接 state 自定义字段回调</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static DocModel EntryOfStep<TBefore, TReq>(LoginWhich which, LoginStep step, TBefore beforeResult = null, TReq reqModel = null, Func<string, string> stateCall = null) where TBefore : class where TReq : class
    {
        var result = new DocModel()
        {
            Which = which,
            Step = step
        };

        switch (step)
        {
            case LoginStep.Authorize:
                {
                    switch (which)
                    {
                        case LoginWhich.QQ:
                            {
                                var authModel = reqModel == null ? new QQAuthorizeModel() : reqModel as QQAuthorizeModel;
                                if (stateCall != null)
                                {
                                    authModel.State = stateCall.Invoke(authModel.State);
                                }
                                result.Raw = AuthorizeLink(QQ.API_Authorize, authModel);
                            }
                            break;
                        case LoginWhich.Weixin:
                            {
                                var authModel = reqModel == null ? new WeixinAuthorizeModel() : reqModel as WeixinAuthorizeModel;
                                if (stateCall != null)
                                {
                                    authModel.State = stateCall.Invoke(authModel.State);
                                }
                                result.Raw = AuthorizeLink(Weixin.API_Authorize, authModel);
                            }
                            break;
                        case LoginWhich.WeixinMP:
                            {
                                var authModel = reqModel == null ? new WeixinMPAuthorizeModel() : reqModel as WeixinMPAuthorizeModel;
                                if (stateCall != null)
                                {
                                    authModel.State = stateCall.Invoke(authModel.State);
                                }
                                result.Raw = AuthorizeLink(WeixinMP.API_Authorize, authModel);
                            }
                            break;
                        case LoginWhich.Weibo:
                            {
                                var authModel = reqModel == null ? new WeiboAuthorizeModel() : reqModel as WeiboAuthorizeModel;
                                if (stateCall != null)
                                {
                                    authModel.State = stateCall.Invoke(authModel.State);
                                }
                                result.Raw = AuthorizeLink(Weibo.API_Authorize, authModel);
                            }
                            break;
                        case LoginWhich.Alipay:
                            {
                                var authModel = reqModel == null ? new AlipayAuthorizeModel() : reqModel as AlipayAuthorizeModel;
                                if (stateCall != null)
                                {
                                    authModel.State = stateCall.Invoke(authModel.State);
                                }
                                result.Raw = AuthorizeLink(Alipay.API_Authorize, authModel);
                            }
                            break;
                        case LoginWhich.Taobao:
                            {
                                var authModel = reqModel == null ? new TaobaoAuthorizeModel() : reqModel as TaobaoAuthorizeModel;
                                if (stateCall != null)
                                {
                                    authModel.State = stateCall.Invoke(authModel.State);
                                }
                                result.Raw = AuthorizeLink(Taobao.API_Authorize, authModel);
                            }
                            break;
                        case LoginWhich.DingTalk:
                            {
                                if (DingTalk.IsOld)
                                {
                                    var authModel = reqModel == null ? new DingTalkOldAuthorizeModel() : reqModel as DingTalkOldAuthorizeModel;
                                    if (stateCall != null)
                                    {
                                        authModel.State = stateCall.Invoke(authModel.State);
                                    }

                                    result.Raw = AuthorizeLink(DingTalk.API_Authorize(), authModel);
                                }
                                else
                                {
                                    var authModel = reqModel == null ? new DingTalkAuthorizeModel() : reqModel as DingTalkAuthorizeModel;
                                    if (stateCall != null)
                                    {
                                        authModel.State = stateCall.Invoke(authModel.State);
                                    }

                                    result.Raw = AuthorizeLink(DingTalk.API_Authorize(), authModel);
                                }
                            }
                            break;
                        case LoginWhich.Feishu:
                            {
                                var authModel = reqModel == null ? new FeishuAuthorizeModel() : reqModel as FeishuAuthorizeModel;
                                if (stateCall != null)
                                {
                                    authModel.State = stateCall.Invoke(authModel.State);
                                }
                                result.Raw = AuthorizeLink(Feishu.API_Authorize, authModel);
                            }
                            break;
                        case LoginWhich.Huawei:
                            {
                                var authModel = reqModel == null ? new HuaweiAuthorizeModel() : reqModel as HuaweiAuthorizeModel;
                                if (stateCall != null)
                                {
                                    authModel.State = stateCall.Invoke(authModel.State);
                                }
                                result.Raw = AuthorizeLink(Huawei.API_Authorize, authModel);
                            }
                            break;
                        case LoginWhich.Xiaomi:
                            {
                                var authModel = reqModel == null ? new XiaomiAuthorizeModel() : reqModel as XiaomiAuthorizeModel;
                                if (stateCall != null)
                                {
                                    authModel.State = stateCall.Invoke(authModel.State);
                                }
                                result.Raw = AuthorizeLink(Xiaomi.API_Authorize, authModel);
                            }
                            break;
                        case LoginWhich.AtomGit:
                            {
                                var authModel = reqModel == null ? new AtomGitAuthorizeModel() : reqModel as AtomGitAuthorizeModel;
                                if (stateCall != null)
                                {
                                    authModel.State = stateCall.Invoke(authModel.State);
                                }
                                result.Raw = AuthorizeLink(AtomGit.API_Authorize, authModel);
                            }
                            break;
                        case LoginWhich.Gitee:
                            {
                                var authModel = reqModel == null ? new GiteeAuthorizeModel() : reqModel as GiteeAuthorizeModel;
                                if (stateCall != null)
                                {
                                    authModel.State = stateCall.Invoke(authModel.State);
                                }
                                result.Raw = AuthorizeLink(Gitee.API_Authorize, authModel);
                            }
                            break;
                        case LoginWhich.GitHub:
                            {
                                var authModel = reqModel == null ? new GitHubAuthorizeModel() : reqModel as GitHubAuthorizeModel;
                                if (stateCall != null)
                                {
                                    authModel.State = stateCall.Invoke(authModel.State);
                                }
                                result.Raw = AuthorizeLink(GitHub.API_Authorize, authModel);
                            }
                            break;
                        case LoginWhich.GitLab:
                            {
                                var authModel = reqModel == null ? new GitLabAuthorizeModel() : reqModel as GitLabAuthorizeModel;
                                if (stateCall != null)
                                {
                                    authModel.State = stateCall.Invoke(authModel.State);
                                }
                                result.Raw = AuthorizeLink(GitLab.API_Authorize, authModel);
                            }
                            break;
                        case LoginWhich.Microsoft:
                            {
                                if (Microsoft.IsOld)
                                {
                                    var authModel = reqModel == null ? new MicrosoftAuthorizeOldModel() : reqModel as MicrosoftAuthorizeOldModel;
                                    if (stateCall != null)
                                    {
                                        authModel.State = stateCall.Invoke(authModel.State);
                                    }
                                    result.Raw = AuthorizeLink(Microsoft.API_Authorize_Old, authModel);
                                }
                                else
                                {
                                    var authModel = reqModel == null ? new MicrosoftAuthorizeModel() : reqModel as MicrosoftAuthorizeModel;
                                    if (stateCall != null)
                                    {
                                        authModel.State = stateCall.Invoke(authModel.State);
                                    }
                                    result.Raw = AuthorizeLink(Microsoft.API_Authorize, authModel);
                                }
                            }
                            break;
                        case LoginWhich.StackOverflow:
                            {
                                var authModel = reqModel == null ? new StackOverflowAuthorizeModel() : reqModel as StackOverflowAuthorizeModel;
                                if (stateCall != null)
                                {
                                    authModel.State = stateCall.Invoke(authModel.State);
                                }
                                result.Raw = AuthorizeLink(StackOverflow.API_Authorize, authModel);
                            }
                            break;
                        case LoginWhich.Google:
                            {
                                var authModel = reqModel == null ? new GoogleAuthorizeModel() : reqModel as GoogleAuthorizeModel;
                                if (stateCall != null)
                                {
                                    authModel.State = stateCall.Invoke(authModel.State);
                                }
                                result.Raw = AuthorizeLink(Google.API_Authorize, authModel);
                            }
                            break;
                        case LoginWhich.Facebook:
                            {
                                var authModel = reqModel == null ? new FacebookAuthorizeModel() : reqModel as FacebookAuthorizeModel;
                                if (stateCall != null)
                                {
                                    authModel.State = stateCall.Invoke(authModel.State);
                                }
                                result.Raw = AuthorizeLink(Facebook.API_Authorize, authModel);
                            }
                            break;
                        case LoginWhich.ORCID:
                            {
                                var authModel = reqModel == null ? new ORCIDAuthorizeModel() : reqModel as ORCIDAuthorizeModel;
                                if (stateCall != null)
                                {
                                    authModel.State = stateCall.Invoke(authModel.State);
                                }
                                result.Raw = AuthorizeLink(ORCID.API_Authorize, authModel);
                            }
                            break;
                    }
                }
                break;
            case LoginStep.AccessToken:
                {
                    //授权码
                    var authModel = beforeResult as AuthorizeResult;
                    if (authModel == null && reqModel == null)
                    {
                        throw new Exception($"请求 {step} 需要 {nameof(AuthorizeResult)} 或 自定义构建 AccessTokenModel");
                    }

                    switch (which)
                    {
                        case LoginWhich.QQ:
                            {
                                if (reqModel is not QQAccessTokenModel sendModel)
                                {
                                    sendModel = new QQAccessTokenModel()
                                    {
                                        Code = authModel.Code
                                    };
                                }
                                result.Raw = Get(QQ.API_AccessToken, sendModel);
                            }
                            break;
                        case LoginWhich.Weixin:
                            {
                                if (reqModel is not WeixinAccessTokenModel sendModel)
                                {
                                    sendModel = new WeixinAccessTokenModel()
                                    {
                                        Code = authModel.Code
                                    };
                                }
                                result.Raw = Get(Weixin.API_AccessToken, sendModel);
                            }
                            break;
                        case LoginWhich.WeixinMP:
                            {
                                if (reqModel is not WeixinMPAccessTokenModel sendModel)
                                {
                                    sendModel = new WeixinMPAccessTokenModel()
                                    {
                                        Code = authModel.Code
                                    };
                                }
                                result.Raw = Get(WeixinMP.API_AccessToken, sendModel);
                            }
                            break;
                        case LoginWhich.Weibo:
                            {
                                if (reqModel is not WeiboAccessTokenModel sendModel)
                                {
                                    sendModel = new WeiboAccessTokenModel()
                                    {
                                        Code = authModel.Code
                                    };
                                }
                                result.Raw = Post(Weibo.API_AccessToken, sendModel);
                            }
                            break;
                        case LoginWhich.Taobao:
                            {
                                if (reqModel is not TaobaoAccessTokenModel sendModel)
                                {
                                    sendModel = new TaobaoAccessTokenModel()
                                    {
                                        Code = authModel.Code
                                    };
                                }
                                result.Raw = Post(Taobao.API_AccessToken, sendModel);
                            }
                            break;
                        case LoginWhich.Alipay:
                            {
                                if (reqModel is not AlipayAccessTokenModel sendModel)
                                {
                                    sendModel = new AlipayAccessTokenModel()
                                    {
                                        Code = authModel.Auth_Code
                                    };
                                }
                                sendModel.GenerateSignature(); //生成签名
                                result.Raw = Get(Alipay.API_Gateway, sendModel);
                            }
                            break;
                        case LoginWhich.DingTalk:
                            {
                                if (DingTalk.IsOld)
                                {
                                    throw new Exception("Older versions are not supported");
                                }
                                else
                                {
                                    if (reqModel is not DingTalkAccessTokenModel sendModel)
                                    {
                                        sendModel = new DingTalkAccessTokenModel()
                                        {
                                            Code = authModel.AuthCode
                                        };
                                    }
                                    result.Raw = Post(DingTalk.API_AccessToken, sendModel, true);
                                }
                            }
                            break;
                        case LoginWhich.Feishu:
                            {
                                if (reqModel is not FeishuAccessTokenModel sendModel)
                                {
                                    sendModel = new FeishuAccessTokenModel()
                                    {
                                        Code = authModel.Code
                                    };
                                }
                                result.Raw = Post(Feishu.API_AccessToken, sendModel);
                            }
                            break;
                        case LoginWhich.Huawei:
                            {
                                if (reqModel is not HuaweiAccessTokenModel sendModel)
                                {
                                    sendModel = new HuaweiAccessTokenModel()
                                    {
                                        Code = authModel.Code
                                    };
                                }
                                result.Raw = Post(Huawei.API_AccessToken, sendModel);
                            }
                            break;
                        case LoginWhich.Xiaomi:
                            {
                                if (reqModel is not XiaomiAccessTokenModel sendModel)
                                {
                                    sendModel = new XiaomiAccessTokenModel()
                                    {
                                        Code = authModel.Code
                                    };
                                }
                                result.Raw = Post(Xiaomi.API_AccessToken, sendModel);
                            }
                            break;
                        case LoginWhich.AtomGit:
                            {
                                if (reqModel is not AtomGitAccessTokenModel sendModel)
                                {
                                    sendModel = new AtomGitAccessTokenModel()
                                    {
                                        Code = authModel.Code
                                    };
                                }
                                result.Raw = Post(AtomGit.API_AccessToken, sendModel);
                            }
                            break;
                        case LoginWhich.Gitee:
                            {
                                if (reqModel is not GiteeAccessTokenModel sendModel)
                                {
                                    sendModel = new GiteeAccessTokenModel()
                                    {
                                        Code = authModel.Code
                                    };
                                }
                                result.Raw = Post(Gitee.API_AccessToken, sendModel);
                            }
                            break;
                        case LoginWhich.GitHub:
                            {
                                if (reqModel is not GitHubAccessTokenModel sendModel)
                                {
                                    sendModel = new GitHubAccessTokenModel()
                                    {
                                        Code = authModel.Code
                                    };
                                }
                                result.Raw = Post(GitHub.API_AccessToken, sendModel);
                            }
                            break;
                        case LoginWhich.GitLab:
                            {
                                if (reqModel is not GitLabAccessTokenModel sendModel)
                                {
                                    sendModel = new GitLabAccessTokenModel()
                                    {
                                        Code = authModel.Code
                                    };
                                }
                                result.Raw = Post(GitLab.API_AccessToken, sendModel);
                            }
                            break;
                        case LoginWhich.Microsoft:
                            {
                                if (Microsoft.IsOld)
                                {
                                    if (reqModel is not MicrosoftAccessTokenOldModel sendModel)
                                    {
                                        sendModel = new MicrosoftAccessTokenOldModel()
                                        {
                                            Code = authModel.Code
                                        };
                                    }
                                    result.Raw = Post(Microsoft.API_AccessToken_Old, sendModel);
                                }
                                else
                                {
                                    if (reqModel is not MicrosoftAccessTokenModel sendModel)
                                    {
                                        sendModel = new MicrosoftAccessTokenModel()
                                        {
                                            Code = authModel.Code
                                        };
                                    }
                                    result.Raw = Post(Microsoft.API_AccessToken, sendModel);
                                }
                            }
                            break;
                        case LoginWhich.StackOverflow:
                            {
                                if (reqModel is not StackOverflowAccessTokenModel sendModel)
                                {
                                    sendModel = new StackOverflowAccessTokenModel()
                                    {
                                        Code = authModel.Code
                                    };
                                }
                                result.Raw = Post(StackOverflow.API_AccessToken, sendModel);
                            }
                            break;
                        case LoginWhich.Google:
                            {
                                if (reqModel is not GoogleAccessTokenModel sendModel)
                                {
                                    sendModel = new GoogleAccessTokenModel()
                                    {
                                        Code = authModel.Code
                                    };
                                }
                                result.Raw = Post(Google.API_AccessToken, sendModel);
                            }
                            break;
                        case LoginWhich.Facebook:
                            {
                                if (reqModel is not FacebookAccessTokenModel sendModel)
                                {
                                    sendModel = new FacebookAccessTokenModel()
                                    {
                                        Code = authModel.Code
                                    };
                                }
                                result.Raw = Post(Facebook.API_AccessToken, sendModel);
                            }
                            break;
                        case LoginWhich.ORCID:
                            {
                                if (reqModel is not ORCIDAccessTokenModel sendModel)
                                {
                                    sendModel = new ORCIDAccessTokenModel()
                                    {
                                        Code = authModel.Code
                                    };
                                }
                                result.Raw = Post(ORCID.API_AccessToken, sendModel);
                            }
                            break;
                    }
                }
                break;
            case LoginStep.RefreshToken:
                {
                    switch (which)
                    {
                        case LoginWhich.QQ:
                            {
                                if (reqModel is not QQRefreshTokenModel sendModel)
                                {
                                    var beforeModel = beforeResult as DocModel;
                                    sendModel = new QQRefreshTokenModel()
                                    {
                                        Refresh_Token = beforeModel.Doc.GetValue("refresh_token")
                                    };
                                }
                                result.Raw = Get(QQ.API_AccessToken, sendModel);
                            }
                            break;
                        case LoginWhich.Weixin:
                            {
                                if (reqModel is not WeixinRefreshTokenModel sendModel)
                                {
                                    var beforeModel = beforeResult as DocModel;
                                    sendModel = new WeixinRefreshTokenModel()
                                    {
                                        Refresh_Token = beforeModel.Doc.GetValue("refresh_token")
                                    };
                                }
                                result.Raw = Get(Weixin.API_RefreshToken, sendModel);
                            }
                            break;
                        case LoginWhich.WeixinMP:
                            {
                                if (reqModel is not WeixinMPRefreshTokenModel sendModel)
                                {
                                    var beforeModel = beforeResult as DocModel;
                                    sendModel = new WeixinMPRefreshTokenModel()
                                    {
                                        Refresh_Token = beforeModel.Doc.GetValue("refresh_token")
                                    };
                                }
                                result.Raw = Get(WeixinMP.API_RefreshToken, sendModel);
                            }
                            break;
                        case LoginWhich.Taobao:
                            {
                                if (reqModel is not TaobaoRefreshTokenModel sendModel)
                                {
                                    var beforeModel = beforeResult as DocModel;
                                    sendModel = new TaobaoRefreshTokenModel()
                                    {
                                        Refresh_Token = beforeModel.Doc.GetValue("refresh_token")
                                    };
                                }
                                result.Raw = Post(Taobao.API_AccessToken, sendModel);
                            }
                            break;
                        case LoginWhich.Alipay:
                            {
                                if (reqModel is not AlipayRefreshTokenModel sendModel)
                                {
                                    var beforeModel = beforeResult as DocModel;
                                    sendModel = new AlipayRefreshTokenModel()
                                    {
                                        Refresh_Token = beforeModel.Doc.GetProperty("alipay_system_oauth_token_response").GetValue("refresh_token")
                                    };
                                }
                                sendModel.GenerateSignature(); //生成签名
                                result.Raw = Get(Alipay.API_Gateway, sendModel);
                            }
                            break;
                        case LoginWhich.DingTalk:
                            {
                                if (DingTalk.IsOld)
                                {
                                    throw new Exception("Older versions are not supported");
                                }
                                else
                                {
                                    if (reqModel is not DingTalkRefreshTokenModel sendModel)
                                    {
                                        var beforeModel = beforeResult as DocModel;
                                        sendModel = new DingTalkRefreshTokenModel()
                                        {
                                            RefreshToken = beforeModel.Doc.GetValue("refreshToken")
                                        };
                                    }
                                    result.Raw = Post(DingTalk.API_AccessToken, sendModel, true);
                                }
                            }
                            break;
                        case LoginWhich.Feishu:
                            {
                                if (reqModel is not FeishuRefreshTokenModel sendModel)
                                {
                                    var beforeModel = beforeResult as DocModel;
                                    sendModel = new FeishuRefreshTokenModel()
                                    {
                                        Refresh_Token = beforeModel.Doc.GetValue("refresh_token")
                                    };
                                }
                                result.Raw = Post(Feishu.API_AccessToken, sendModel);
                            }
                            break;
                        case LoginWhich.Huawei:
                            {
                                if (reqModel is not HuaweiRefreshTokenModel sendModel)
                                {
                                    var beforeModel = beforeResult as DocModel;
                                    sendModel = new HuaweiRefreshTokenModel()
                                    {
                                        Refresh_Token = beforeModel.Doc.GetValue("refresh_token")
                                    };
                                }
                                result.Raw = Post(Huawei.API_AccessToken, sendModel);
                            }
                            break;
                        case LoginWhich.Xiaomi:
                            {
                                if (reqModel is not XiaomiRefreshTokenModel sendModel)
                                {
                                    var beforeModel = beforeResult as DocModel;
                                    sendModel = new XiaomiRefreshTokenModel()
                                    {
                                        Refresh_Token = beforeModel.Doc.GetValue("refresh_token")
                                    };
                                }
                                result.Raw = Post(Xiaomi.API_AccessToken, sendModel);
                            }
                            break;
                        case LoginWhich.AtomGit:
                            {
                                if (reqModel is not AtomGitRefreshTokenModel sendModel)
                                {
                                    var beforeModel = beforeResult as DocModel;
                                    sendModel = new AtomGitRefreshTokenModel()
                                    {
                                        Refresh_Token = beforeModel.Doc.GetValue("refresh_token")
                                    };
                                }
                                result.Raw = Post(AtomGit.API_AccessToken, sendModel);
                            }
                            break;
                        case LoginWhich.Gitee:
                            {
                                if (reqModel is not GiteeRefreshTokenModel sendModel)
                                {
                                    var beforeModel = beforeResult as DocModel;
                                    sendModel = new GiteeRefreshTokenModel()
                                    {
                                        Refresh_Token = beforeModel.Doc.GetValue("refresh_token")
                                    };
                                }
                                result.Raw = Post(Gitee.API_AccessToken, sendModel);
                            }
                            break;
                        case LoginWhich.GitLab:
                            {
                                if (reqModel is not GitLabRefreshTokenModel sendModel)
                                {
                                    var beforeModel = beforeResult as DocModel;
                                    sendModel = new GitLabRefreshTokenModel()
                                    {
                                        Refresh_Token = beforeModel.Doc.GetValue("refresh_token")
                                    };
                                }
                                result.Raw = Post(GitLab.API_AccessToken, sendModel);
                            }
                            break;
                        case LoginWhich.Microsoft:
                            {
                                if (Microsoft.IsOld)
                                {
                                    throw new Exception("Older versions are not supported");
                                }
                                else
                                {
                                    if (reqModel is not MicrosoftRefreshTokenModel sendModel)
                                    {
                                        var beforeModel = beforeResult as DocModel;
                                        sendModel = new MicrosoftRefreshTokenModel()
                                        {
                                            Refresh_Token = beforeModel.Doc.GetValue("refresh_token")
                                        };
                                    }
                                    result.Raw = Post(Microsoft.API_AccessToken, sendModel);
                                }
                            }
                            break;
                        case LoginWhich.Google:
                            {
                                if (reqModel is not GoogleRefreshTokenModel sendModel)
                                {
                                    var beforeModel = beforeResult as DocModel;
                                    sendModel = new GoogleRefreshTokenModel()
                                    {
                                        Refresh_Token = beforeModel.Doc.GetValue("refresh_token")
                                    };
                                }
                                result.Raw = Post(Google.API_AccessToken, sendModel);
                            }
                            break;
                        case LoginWhich.Weibo:
                        case LoginWhich.GitHub:
                        case LoginWhich.Facebook:
                        case LoginWhich.StackOverflow:
                            throw new Exception("not support");
                    }
                }
                break;
            case LoginStep.OpenId:
                {
                    if (which != LoginWhich.QQ)
                    {
                        throw new Exception("仅限 QQ");
                    }

                    if (reqModel is not QQOpenIdModel sendModel)
                    {
                        var beforeModel = (beforeResult as DocModel);
                        sendModel = new QQOpenIdModel()
                        {
                            Access_Token = beforeModel.Doc.GetValue("access_token")
                        };
                    }
                    result.Raw = Get(QQ.API_OpenId, sendModel);
                }
                break;
            case LoginStep.User:
                {
                    switch (which)
                    {
                        case LoginWhich.QQ:
                            {
                                if (reqModel is not QQUserModel sendModel)
                                {
                                    //之前（数组 tokenResult 和 openidResult）
                                    var beforeArray = beforeResult as DocModel[];
                                    sendModel = new QQUserModel()
                                    {
                                        Access_Token = beforeArray[0].Doc.GetValue("access_token"),
                                        OpenId = beforeArray[1].Doc.GetValue("openid")
                                    };
                                }
                                result.Raw = Get(QQ.API_User, sendModel);
                            }
                            break;
                        case LoginWhich.Weixin:
                            {
                                if (reqModel is not WeixinUserModel sendModel)
                                {
                                    var beforeModel = beforeResult as DocModel;
                                    sendModel = new WeixinUserModel()
                                    {
                                        Access_Token = beforeModel.Doc.GetValue("access_token"),
                                        OpenId = beforeModel.Doc.GetValue("openid")
                                    };
                                }
                                result.Raw = Get(Weixin.API_User, sendModel);
                            }
                            break;
                        case LoginWhich.WeixinMP:
                            {
                                if (reqModel is not WeixinMPUserModel sendModel)
                                {
                                    var beforeModel = beforeResult as DocModel;
                                    sendModel = new WeixinMPUserModel()
                                    {
                                        Access_Token = beforeModel.Doc.GetValue("access_token"),
                                        OpenId = beforeModel.Doc.GetValue("openid")
                                    };
                                }
                                result.Raw = Get(WeixinMP.API_User, sendModel);
                            }
                            break;
                        case LoginWhich.Weibo:
                            {
                                if (reqModel is not WeiboUserModel sendModel)
                                {
                                    var beforeModel = beforeResult as DocModel;
                                    sendModel = new WeiboUserModel()
                                    {
                                        Uid = beforeModel.Doc.GetValue<long>("uid"),
                                        Access_Token = beforeModel.Doc.GetValue("access_token")
                                    };
                                }
                                result.Raw = Get(Weibo.API_User, sendModel);
                            }
                            break;
                        case LoginWhich.Taobao: throw new Exception("Not support");
                        case LoginWhich.Alipay:
                            {
                                if (reqModel is not AlipayUserModel sendModel)
                                {
                                    var beforeModel = beforeResult as DocModel;
                                    sendModel = new AlipayUserModel()
                                    {
                                        Auth_Token = beforeModel.Doc.GetProperty("alipay_system_oauth_token_response").GetValue("access_token")
                                    };
                                }
                                sendModel.GenerateSignature(); //生成签名
                                result.Raw = Get(Alipay.API_Gateway, sendModel);
                            }
                            break;
                        case LoginWhich.DingTalk:
                            {
                                if (DingTalk.IsOld)
                                {
                                    if (reqModel is not AuthorizeResult sendModel)
                                    {
                                        sendModel = beforeResult as AuthorizeResult;
                                    }
                                    var queryModel = new DingTalOldkUserModel();

                                    var url = $"{DingTalk.API_User_Old}?{queryModel.ToParameters()}".Replace("accesskey", "accessKey");
                                    var hwr = HttpTo.HWRequest(url, "POST", new { tmp_auth_code = sendModel.Code }.ToJson());
                                    hwr.ContentType = "application/json";
                                    result.Raw = HttpTo.Url(hwr);
                                }
                                else
                                {
                                    if (reqModel is not DingTalkUserModel sendModel)
                                    {
                                        var beforeModel = beforeResult as DocModel;
                                        sendModel = new DingTalkUserModel()
                                        {
                                            Access_Token = beforeModel.Doc.GetValue("accessToken")
                                        };
                                    }
                                    result.Raw = Get(DingTalk.API_User, sendModel, new Dictionary<string, string> { { "x-acs-dingtalk-access-token", sendModel.Access_Token } });
                                }
                            }
                            break;
                        case LoginWhich.Feishu:
                            {
                                if (reqModel is not FeishuUserModel sendModel)
                                {
                                    var beforeModel = beforeResult as DocModel;
                                    sendModel = new FeishuUserModel()
                                    {
                                        Access_Token = beforeModel.Doc.GetValue("access_token")
                                    };
                                }
                                result.Raw = Get(Feishu.API_User, sendModel, new Dictionary<string, string> { { "Authorization", $"token {sendModel.Access_Token}" } });
                            }
                            break;
                        case LoginWhich.Huawei:
                            {
                                if (reqModel is not HuaweiUserModel sendModel)
                                {
                                    var beforeModel = beforeResult as DocModel;
                                    sendModel = new HuaweiUserModel()
                                    {
                                        Access_Token = beforeModel.Doc.GetValue("access_token")
                                    };
                                }
                                result.Raw = Post(Huawei.API_User, sendModel);
                            }
                            break;
                        case LoginWhich.Xiaomi:
                            {
                                if (reqModel is not XiaomiUserModel sendModel)
                                {
                                    var beforeModel = beforeResult as DocModel;
                                    sendModel = new XiaomiUserModel()
                                    {
                                        Token = beforeModel.Doc.GetValue("access_token")
                                    };
                                }
                                result.Raw = Get(Xiaomi.API_User, sendModel);
                            }
                            break;
                        case LoginWhich.AtomGit:
                            {
                                if (reqModel is not AtomGitUserModel sendModel)
                                {
                                    var beforeModel = beforeResult as DocModel;
                                    sendModel = new AtomGitUserModel()
                                    {
                                        Access_Token = beforeModel.Doc.GetValue("access_token")
                                    };
                                }
                                result.Raw = Get(AtomGit.API_User, sendModel, new Dictionary<string, string> { { "Authorization", $"Bearer {sendModel.Access_Token}" } });
                            }
                            break;
                        case LoginWhich.Gitee:
                            {
                                if (reqModel is not GiteeUserModel sendModel)
                                {
                                    var beforeModel = beforeResult as DocModel;
                                    sendModel = new GiteeUserModel()
                                    {
                                        Access_Token = beforeModel.Doc.GetValue("access_token")
                                    };
                                }
                                result.Raw = Get(Gitee.API_User, sendModel);
                            }
                            break;
                        case LoginWhich.GitHub:
                            {
                                if (reqModel is not GitHubUserModel sendModel)
                                {
                                    var beforeModel = beforeResult as DocModel;
                                    sendModel = new GitHubUserModel()
                                    {
                                        Access_Token = beforeModel.Doc.GetValue("access_token")
                                    };
                                }
                                result.Raw = Get(GitHub.API_User, sendModel, new Dictionary<string, string> { { "Authorization", $"token {sendModel.Access_Token}" } });
                            }
                            break;
                        case LoginWhich.GitLab:
                            {
                                if (reqModel is not GitLabUserModel sendModel)
                                {
                                    var beforeModel = beforeResult as DocModel;
                                    sendModel = new GitLabUserModel()
                                    {
                                        Access_Token = beforeModel.Doc.GetValue("access_token")
                                    };
                                }
                                result.Raw = Get(GitLab.API_User, sendModel);
                            }
                            break;
                        case LoginWhich.Microsoft:
                            {
                                if (Microsoft.IsOld)
                                {
                                    if (reqModel is not MicrosoftUserModel sendModel)
                                    {
                                        var beforeModel = beforeResult as DocModel;
                                        sendModel = new MicrosoftUserModel()
                                        {
                                            Access_Token = beforeModel.Doc.GetValue("access_token")
                                        };
                                    }
                                    var hwr = HttpTo.HWRequest($"{Microsoft.API_User_Old}?{sendModel.ToParameters()}");
                                    hwr.ContentType = null;
                                    result.Raw = HttpTo.Url(hwr);
                                }
                                else
                                {
                                    if (reqModel is not MicrosoftUserModel sendModel)
                                    {
                                        var beforeModel = beforeResult as DocModel;
                                        sendModel = new MicrosoftUserModel()
                                        {
                                            Access_Token = beforeModel.Doc.GetValue("access_token")
                                        };
                                    }
                                    result.Raw = Get(Microsoft.API_User, sendModel, new Dictionary<string, string> { { "Authorization", $"Bearer {sendModel.Access_Token}" } });
                                }
                            }
                            break;
                        case LoginWhich.StackOverflow:
                            {
                                if (reqModel is not StackOverflowUserModel sendModel)
                                {
                                    var beforeModel = (beforeResult as DocModel);
                                    sendModel = new StackOverflowUserModel()
                                    {
                                        Access_Token = beforeModel.Doc.GetValue("access_token")
                                    };
                                }
                                result.Raw = Get(StackOverflow.API_User, sendModel);
                            }
                            break;
                        case LoginWhich.Google:
                            {
                                if (reqModel is not GoogleUserModel sendModel)
                                {
                                    var beforeModel = beforeResult as DocModel;
                                    sendModel = new GoogleUserModel()
                                    {
                                        Access_Token = beforeModel.Doc.GetValue("access_token")
                                    };
                                }
                                result.Raw = Get(Google.API_User, sendModel, new Dictionary<string, string> { { "Authorization", $"Bearer {sendModel.Access_Token}" } });
                            }
                            break;
                        case LoginWhich.Facebook:
                            {
                                if (reqModel is not FacebookUserModel sendModel)
                                {
                                    var beforeModel = beforeResult as DocModel;
                                    sendModel = new FacebookUserModel()
                                    {
                                        Access_Token = beforeModel.Doc.GetValue("access_token")
                                    };
                                }
                                result.Raw = Get(Facebook.API_User, sendModel);
                            }
                            break;
                        case LoginWhich.ORCID:
                            {
                                if (reqModel is not ORCIDUserModel sendModel)
                                {
                                    var beforeModel = beforeResult as DocModel;
                                    sendModel = new ORCIDUserModel()
                                    {
                                        Access_Token = beforeModel.Doc.GetValue("access_token")
                                    };
                                }
                                result.Raw = Get(ORCID.API_User, sendModel, new Dictionary<string, string> { { "Authorization", $"Bearer {sendModel.Access_Token}" } });
                            }
                            break;
                    }
                }
                break;
        }

        if (!string.IsNullOrEmpty(result.Raw))
        {
            if (step != LoginStep.Authorize)
            {
                result.Doc = result.Raw.DeJson();
            }

            return result;
        }

        return default;
    }

    /// <summary>
    /// 得到最终用户信息，包含每个步骤的信息
    /// </summary>
    /// <param name="loginType"></param>
    /// <param name="authResult"></param>
    /// <returns></returns>
    public static ValueTuple<DocModel, DocModel, DocModel, PublicUserResult> EntryOfSteps(LoginWhich loginType, AuthorizeResult authResult)
    {
        //step: access token（非 旧版 DingTalk）
        DocModel tokenResult = null;
        //step: openid (仅 QQ)
        DocModel openidResult = null;
        //step: user (非 Taobao)
        DocModel userResult = null;

        if (!(loginType == LoginWhich.DingTalk && DingTalk.IsOld))
        {
            tokenResult = EntryOfStep<AuthorizeResult, object>(loginType, LoginStep.AccessToken, beforeResult: authResult);
        }
        if (loginType == LoginWhich.QQ)
        {
            openidResult = EntryOfStep<DocModel, object>(loginType, LoginStep.OpenId, beforeResult: tokenResult);
            userResult = EntryOfStep<DocModel[], object>(loginType, LoginStep.User, beforeResult: [tokenResult, openidResult]);
        }
        else if (loginType == LoginWhich.DingTalk && DingTalk.IsOld)
        {
            userResult = EntryOfStep<object, AuthorizeResult>(loginType, LoginStep.User, reqModel: authResult);
        }
        else if (loginType != LoginWhich.Taobao)
        {
            userResult = EntryOfStep<DocModel, object>(loginType, LoginStep.User, beforeResult: tokenResult);
        }

        //提取为统一实体
        PublicUserResult publicUser = new();
        switch (loginType)
        {
            case LoginWhich.QQ:
                {
                    publicUser.OpenId = openidResult.Doc.GetValue("openid");

                    publicUser.Avatar = userResult.Doc.GetValue("figureurl_qq");
                    if (string.IsNullOrWhiteSpace(publicUser.Avatar))
                    {
                        publicUser.Avatar = userResult.Doc.GetValue("figureurl_2");
                    }

                    publicUser.Nickname = userResult.Doc.GetValue("nickname");
                    publicUser.Location = $"{userResult.Doc.GetValue("province")}{userResult.Doc.GetValue("city")}";
                }
                break;
            case LoginWhich.Weixin:
            case LoginWhich.WeixinMP:
                {
                    publicUser.UnionId = userResult.Doc.GetValue("unionid");
                    publicUser.OpenId = userResult.Doc.GetValue("openid");
                    publicUser.Avatar = userResult.Doc.GetValue("headimgurl");
                    publicUser.Nickname = userResult.Doc.GetValue("nickname");
                    publicUser.Location = $"{userResult.Doc.GetValue("province")}{userResult.Doc.GetValue("city")}";
                }
                break;
            case LoginWhich.Weibo:
                {
                    publicUser.OpenId = userResult.Doc.GetValue("idstr");
                    publicUser.Avatar = userResult.Doc.GetValue("avatar_hd");
                    if (string.IsNullOrWhiteSpace(publicUser.Avatar))
                    {
                        publicUser.Avatar = userResult.Doc.GetValue("avatar_large");
                    }

                    publicUser.Name = userResult.Doc.GetValue("name");
                    publicUser.Nickname = userResult.Doc.GetValue("screen_name");

                    publicUser.Site = userResult.Doc.GetValue("url");
                    if (string.IsNullOrWhiteSpace(publicUser.Site))
                    {
                        publicUser.Site = userResult.Doc.GetValue("domain");
                    }
                    if (string.IsNullOrWhiteSpace(publicUser.Site))
                    {
                        publicUser.Site = $"https://weibo.com/{userResult.Doc.GetValue("profile_url")}";
                    }

                    publicUser.Bio = userResult.Doc.GetValue("description");
                    publicUser.Location = userResult.Doc.GetValue("location");
                }
                break;
            case LoginWhich.Taobao:
                {
                    publicUser.OpenId = tokenResult.Doc.GetValue("open_uid");
                }
                break;
            case LoginWhich.Alipay:
                {
                    var userObj = userResult.Doc.GetProperty("alipay_user_info_share_response");

                    publicUser.OpenId = userObj.GetValue("user_id");
                    publicUser.Avatar = userObj.GetValue("avatar");
                    publicUser.Nickname = userObj.GetValue("nick_name");
                    publicUser.Location = $"{userObj.GetValue("province")}{userObj.GetValue("city")}";
                }
                break;
            case LoginWhich.DingTalk:
                {
                    if (DingTalk.IsOld)
                    {
                        var userObj = userResult.Doc.GetProperty("user_info");

                        publicUser.UnionId = userObj.GetValue("unionid");
                        publicUser.OpenId = userObj.GetValue("openid");
                        publicUser.Nickname = userObj.GetValue("nick");
                    }
                    else
                    {
                        publicUser.UnionId = userResult.Doc.GetValue("unionId");
                        publicUser.OpenId = userResult.Doc.GetValue("openId");
                        publicUser.Avatar = userResult.Doc.GetValue("avatarUrl");
                        publicUser.Nickname = userResult.Doc.GetValue("nick");
                        publicUser.Email = userResult.Doc.GetValue("email");
                    }
                }
                break;
            case LoginWhich.Feishu:
                {
                    publicUser.UnionId = userResult.Doc.GetValue("union_id");
                    publicUser.OpenId = userResult.Doc.GetValue("open_id");
                    publicUser.Avatar = userResult.Doc.GetValue("avatar_big");
                    publicUser.Name = userResult.Doc.GetValue("name");
                    publicUser.Email = userResult.Doc.GetValue("email");
                }
                break;
            case LoginWhich.Huawei:
                {
                    publicUser.UnionId = userResult.Doc.GetValue("unionID");
                    publicUser.OpenId = userResult.Doc.GetValue("openID");
                    publicUser.Nickname = userResult.Doc.GetValue("displayName");
                    publicUser.Avatar = userResult.Doc.GetValue("headPictureURL");
                    publicUser.Email = userResult.Doc.GetValue("email");
                }
                break;
            case LoginWhich.Xiaomi:
                {
                    publicUser.UnionId = tokenResult.Doc.GetValue("union_id");
                    publicUser.OpenId = tokenResult.Doc.GetValue("openId");

                    var userObj = userResult.Doc.GetProperty("data");
                    if (userObj.ValueKind != JsonValueKind.Null)
                    {
                        publicUser.Avatar = userObj.GetValue("miliaoIcon");
                        publicUser.Nickname = userObj.GetValue("miliaoNick");
                    }
                }
                break;
            case LoginWhich.AtomGit:
            case LoginWhich.Gitee:
            case LoginWhich.GitHub:
                {
                    publicUser.OpenId = userResult.Doc.GetValue("id");
                    publicUser.Avatar = userResult.Doc.GetValue("avatar_url");
                    publicUser.Name = userResult.Doc.GetValue("login");
                    publicUser.Nickname = userResult.Doc.GetValue("name");
                    publicUser.Email = userResult.Doc.GetValue("email");
                    publicUser.Site = userResult.Doc.GetValue("blog");
                    publicUser.Bio = userResult.Doc.GetValue("bio");
                }
                break;
            case LoginWhich.GitLab:
                {
                    publicUser.OpenId = userResult.Doc.GetValue("id");
                    publicUser.Avatar = userResult.Doc.GetValue("avatar_url");
                    publicUser.Name = userResult.Doc.GetValue("username");
                    publicUser.Nickname = userResult.Doc.GetValue("pronouns") ?? userResult.Doc.GetValue("name");
                    publicUser.Email = userResult.Doc.GetValue("email");
                    publicUser.Site = userResult.Doc.GetValue("website_url");
                    publicUser.Bio = userResult.Doc.GetValue("bio");
                    publicUser.Location = userResult.Doc.GetValue("location");
                }
                break;
            case LoginWhich.Microsoft:
                {
                    if (Microsoft.IsOld)
                    {
                        publicUser.OpenId = userResult.Doc.GetValue("id");
                        publicUser.Nickname = userResult.Doc.GetValue("name");

                        var emailObj = userResult.Doc.GetProperty("emails");
                        publicUser.Email = emailObj.GetValue("preferred");
                        if (string.IsNullOrWhiteSpace(publicUser.Email))
                        {
                            publicUser.Email = emailObj.GetValue("account");
                        }
                    }
                    else
                    {
                        //与v4 版本获取的 ID 不一样
                        publicUser.OpenId = userResult.Doc.GetValue("sub");
                        //https://graph.microsoft.com/v1.0/me/photo/$value
                        publicUser.Avatar = userResult.Doc.GetValue("picture"); //请求下载异常
                        publicUser.Nickname = userResult.Doc.GetValue("name");
                        publicUser.Email = userResult.Doc.GetValue("email");
                    }
                }
                break;
            case LoginWhich.StackOverflow:
                {
                    var userObj = userResult.Doc.GetProperty("items").EnumerateArray().First();

                    publicUser.OpenId = userObj.GetValue("account_id");
                    publicUser.OpenId = userObj.GetValue("user_id");
                    publicUser.Avatar = userObj.GetValue("profile_image");
                    publicUser.Nickname = userObj.GetValue("display_name");

                    publicUser.Site = userObj.GetValue("website_url");
                    if (string.IsNullOrWhiteSpace(publicUser.Site))
                    {
                        publicUser.Site = userObj.GetValue("link");
                    }

                    publicUser.Location = userObj.GetValue("location");
                }
                break;
            case LoginWhich.Google:
                {
                    publicUser.OpenId = userResult.Doc.GetValue("sub");
                    publicUser.Avatar = userResult.Doc.GetValue("picture");
                    publicUser.Nickname = userResult.Doc.GetValue("name");
                    publicUser.Email = userResult.Doc.GetValue("email");
                }
                break;
            case LoginWhich.Facebook:
                {
                    publicUser.OpenId = userResult.Doc.GetValue("id");
                    publicUser.Nickname = userResult.Doc.GetValue("name");
                    publicUser.Email = userResult.Doc.GetValue("email");

                    if (userResult.Doc.TryGetProperty("picture", out JsonElement fb_picture))
                    {
                        if (fb_picture.TryGetProperty("data", out JsonElement fb_picture_data))
                        {
                            publicUser.Avatar = fb_picture_data.GetValue("url");
                        }
                    }
                }
                break;
            case LoginWhich.ORCID:
                {
                    publicUser.OpenId = userResult.Doc.GetValue("sub");
                    publicUser.Nickname = userResult.Doc.GetValue("given_name");
                }
                break;
        }

        return new(tokenResult, openidResult, userResult, publicUser);
    }

    /// <summary>
    /// 得到最终用户信息
    /// </summary>
    /// <param name="loginType"></param>
    /// <param name="authResult"></param>
    /// <returns></returns>
    public static PublicUserResult Entry(LoginWhich loginType, AuthorizeResult authResult) => EntryOfSteps(loginType, authResult).Item4;
}

/// <summary>
/// 登录类型
/// </summary>
public enum LoginWhich
{
    /// <summary>
    /// 腾讯QQ
    /// </summary>
    QQ,
    /// <summary>
    /// 微信（开放平台）
    /// </summary>
    Weixin,
    /// <summary>
    /// 微信（公众平台）
    /// </summary>
    WeixinMP,
    /// <summary>
    /// 新浪微博
    /// </summary>
    Weibo,
    /// <summary>
    /// 淘宝
    /// </summary>
    Taobao,
    /// <summary>
    /// 支付宝
    /// </summary>
    Alipay,
    /// <summary>
    /// 钉钉
    /// </summary>
    DingTalk,
    /// <summary>
    /// 飞书
    /// </summary>
    Feishu,
    /// <summary>
    /// 华为
    /// </summary>
    Huawei,
    /// <summary>
    /// 小米
    /// </summary>
    Xiaomi,
    /// <summary>
    /// AtomGit
    /// </summary>
    AtomGit,
    /// <summary>
    /// Gitee
    /// </summary>
    Gitee,
    /// <summary>
    /// GitHub
    /// </summary>
    GitHub,
    /// <summary>
    /// GitLab
    /// </summary>
    GitLab,
    /// <summary>
    /// 微软
    /// </summary>
    Microsoft,
    /// <summary>
    /// Stack Overflow
    /// </summary>
    StackOverflow,
    /// <summary>
    /// 谷歌
    /// </summary>
    Google,
    /// <summary>
    /// Meta
    /// </summary>
    Facebook,
    /// <summary>
    /// ORCID
    /// </summary>
    ORCID
}

/// <summary>
/// 步骤
/// </summary>
public enum LoginStep
{
    /// <summary>
    /// 授权链接
    /// </summary>
    Authorize,
    /// <summary>
    /// access token
    /// </summary>
    AccessToken,
    /// <summary>
    /// refresh token
    /// </summary>
    RefreshToken,
    /// <summary>
    /// 仅限 QQ
    /// </summary>
    OpenId,
    /// <summary>
    /// user（不支持 Taobao）
    /// </summary>
    User
}

/// <summary>
/// 授权码结果
/// </summary>
public class AuthorizeResult
{
    /// <summary>
    /// 授权码
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// 授权码，DingTalk 钉钉
    /// </summary>
    public string AuthCode { get; set; }

    /// <summary>
    /// 授权码，Alipay 支付宝
    /// </summary>
    public string Auth_Code { get; set; }

    /// <summary>
    /// 防伪参数，如果传递参数，会回传该参数。
    /// </summary>
    public string State { get; set; }

    /// <summary>
    /// 无授权码
    /// </summary>
    /// <returns></returns>
    public bool NoAuthCode() => string.IsNullOrWhiteSpace(Code) && string.IsNullOrWhiteSpace(AuthCode) && string.IsNullOrWhiteSpace(Auth_Code);
}

/// <summary>
/// Doc Model
/// </summary>
public class DocModel
{
    /// <summary>
    /// 原始数据
    /// </summary>
    public string Raw { get; set; }
    /// <summary>
    /// 类型
    /// </summary>
    public LoginWhich Which { get; set; }
    /// <summary>
    /// 方法
    /// </summary>
    public LoginStep Step { get; set; }
    /// <summary>
    /// 结果
    /// </summary>
    public JsonElement Doc { get; set; }
}

/// <summary>
/// Public Authorize
/// </summary>
public class PublicAuthorizeModel
{
    /// <summary>
    /// 重定向回调链接
    /// </summary>
    public string Redirect_Uri { get; set; }

    /// <summary>
    /// 自定义字段，防伪验证，可加 登录、注册、解绑等标记
    /// </summary>
    public string State { get; set; } = DateTime.Now.ToString("yyyyMMddHHmmssfff");
}

/// <summary>
/// Public Access Token
/// </summary>
public class PublicAccessTokenModel
{
    /// <summary>
    /// 重定向回调链接
    /// </summary>
    public string Redirect_Uri { get; set; }

    /// <summary>
    /// 授权码
    /// </summary>
    public string Code { get; set; }
}

/// <summary>
/// 用户信息
/// </summary>
public class PublicUserResult
{
    /// <summary>
    /// 应用唯一，始终有值
    /// </summary>
    public string OpenId { get; set; }
    /// <summary>
    /// 跨应用唯一，可能有值
    /// </summary>
    public string UnionId { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 昵称
    /// </summary>
    public string Nickname { get; set; }

    /// <summary>
    /// 头像
    /// </summary>
    public string Avatar { get; set; }

    /// <summary>
    /// 邮箱
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// 站点
    /// </summary>
    public string Site { get; set; }

    /// <summary>
    /// 介绍
    /// </summary>
    public string Bio { get; set; }

    /// <summary>
    /// 地点
    /// </summary>
    public string Location { get; set; }

    /// <summary>
    /// 获取标识 优先取 UnionId 再取 OpenId
    /// </summary>
    /// <returns></returns>
    public string GetId() => UnionId ?? OpenId;
}
