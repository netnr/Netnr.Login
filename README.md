# Netnr.Login
第三方 OAuth2 授权登录，QQ、微信开放平台（Weixin）、微信公众平台（WeixinMP）、微博（Weibo）、淘宝（Taobao）、支付宝（Alipay）、钉钉（DingTalk）、飞书（Feishu）、AtomGit、码云（Gitee）、GitHub、GitLab、微软（Microsoft ）、StackOverflow、谷歌（Google）、ORCID

### 安装 (NuGet)
```
Install-Package Netnr.Login
```

### 支持第三方登录
<table>
    <tr><th>三方</th><th>参考文档</th><th>应用申请（已登录）</th></tr>
    <tr>
        <td><img src="https://gs.zme.ink/static/login/qq.svg" height="30" title="QQ"></td>
        <td><a target="_blank" href="https://wiki.connect.qq.com/准备工作_oauth2-0">参考文档</a></td>
        <td><a target="_blank" href="https://connect.qq.com/manage.html">应用申请</a></td>
    </tr>
    <tr>
        <td><img src="https://gs.zme.ink/static/login/weixin.svg" height="30" title="微信开放平台/Weixin"></td>
        <td><a target="_blank" href="https://developers.weixin.qq.com/doc/oplatform/Website_App/WeChat_Login/Wechat_Login.html">参考文档</a></td>
        <td><a target="_blank" href="https://open.weixin.qq.com">应用申请</a></td>
    </tr>
    <tr>
        <td><img src="https://gs.zme.ink/static/login/weixinmp.svg" height="30" title="微信公众平台/WeixinMP"></td>
        <td><a target="_blank" href="https://developers.weixin.qq.com/doc/offiaccount/OA_Web_Apps/Wechat_webpage_authorization.html">参考文档</a></td>
        <td><a target="_blank" href="https://mp.weixin.qq.com">应用申请</a></td>
    </tr>
    <tr>
        <td><img src="https://gs.zme.ink/static/login/weibo.svg" height="30" title="微博/Weibo"></td>
        <td><a target="_blank" href="https://open.weibo.com/wiki/Connect/login">参考文档</a></td>
        <td><a target="_blank" href="https://open.weibo.com/apps">应用申请</a></td>
    </tr>
    <tr>
        <td><img src="https://gs.zme.ink/static/login/taobao.svg" height="30" title="淘宝"></td>
        <td><a target="_blank" href="https://open.taobao.com/doc.htm?docId=118&docType=1&spm=a219a.7395903.0.0.6a4239715JvKjW">参考文档</a></td>
        <td><a target="_blank" href="https://console.open.taobao.com/">应用申请</a></td>
    </tr>
    <tr>
        <td><img src="https://gs.zme.ink/static/login/alipay.svg" height="30" title="支付宝/Alipay"></td>
        <td><a target="_blank" href="https://opendocs.alipay.com/open/263/105809">参考文档</a></td>
        <td><a target="_blank" href="https://open.alipay.com/develop/manage">应用申请</a></td>
    </tr>
    <tr>
        <td><img src="https://gs.zme.ink/static/login/dingtalk.svg" height="30" title="钉钉/DingTalk"></td>
        <td><a target="_blank" href="https://open.dingtalk.com/document/tutorial/scan-qr-code-to-log-on-to-third-party-websites">参考文档</a></td>
        <td><a target="_blank" href="https://open-dev.dingtalk.com/#/loginMan">应用申请</a></td>
    </tr>
    <tr>
        <td><img src="https://gs.zme.ink/static/login/feishu.svg" height="30" title="钉钉/DingTalk"></td>
        <td><a target="_blank" href="https://open.feishu.cn/document/common-capabilities/sso/web-application-sso/web-app-overview">参考文档</a></td>
        <td><a target="_blank" href="https://open.feishu.cn/app">应用申请</a></td>
    </tr>
    <tr>
        <td><img src="https://gs.zme.ink/static/login/atomgit.svg" height="30" title="AtomGit"></td>
        <td><a target="_blank" href="https://docs.atomgit.com/oauth/">参考文档</a></td>
        <td><a target="_blank" href="https://atomgit.com">应用申请</a></td>
    </tr>
    <tr>
        <td><img src="https://gs.zme.ink/static/login/gitee.svg" height="30" title="码云/Gitee"></td>
        <td><a target="_blank" href="https://gitee.com/api/v5/oauth_doc">参考文档</a></td>
        <td><a target="_blank" href="https://gitee.com/oauth/applications">应用申请</a></td>
    </tr>
    <tr>
        <td><img src="https://gs.zme.ink/static/login/github.svg" height="30" title="GitHub"></td>
        <td><a target="_blank" href="https://docs.github.com/en/developers/apps/building-oauth-apps/authorizing-oauth-apps">参考文档</a></td>
        <td><a target="_blank" href="https://github.com/settings/developers">应用申请</a></td>
    </tr>
    <tr>
        <td><img src="https://gs.zme.ink/static/login/gitlab.svg" height="30" title="GitLab"></td>
        <td><a target="_blank" href="https://docs.gitlab.com/ee/api/oauth2.html">参考文档</a></td>
        <td><a target="_blank" href="https://gitlab.com/oauth/applications">应用申请</a></td>
    </tr>
    <tr>
        <td><img src="https://gs.zme.ink/static/login/microsoft.svg" height="30" title="微软/Microsoft"></td>
        <td><a target="_blank" href="https://docs.microsoft.com/zh-cn/azure/active-directory/develop/v2-oauth2-auth-code-flow">参考文档</a></td>
        <td><a target="_blank" href="https://portal.azure.com/#view/Microsoft_AAD_IAM/ActiveDirectoryMenuBlade/~/RegisteredApps">应用申请</a></td>
    </tr>
    <tr>
        <td><img src="https://gs.zme.ink/static/login/stackoverflow.svg" height="30" title="Stack Overflow"></td>
        <td><a target="_blank" href="https://api.stackexchange.com">参考文档</a></td>
        <td><a target="_blank" href="https://stackapps.com/apps/oauth/register">应用申请</a></td>
    </tr>
    <tr>
        <td><img src="https://gs.zme.ink/static/login/google.svg" height="30" title="谷歌/Google"></td>
        <td><a target="_blank" href="https://developers.google.com/identity/protocols/oauth2/web-server">参考文档</a></td>
        <td><a target="_blank" href="https://console.developers.google.com/apis/credentials">应用申请</a></td>
    </tr>
    <tr>
        <td><img src="https://gs.zme.ink/static/login/orcid.svg" height="30" title="ORCID"></td>
        <td><a target="_blank" href="https://github.com/ORCID/ORCID-Source/blob/main/orcid-web/ORCID_AUTH_WITH_OPENID_CONNECT.md">参考文档</a></td>
        <td><a target="_blank" href="https://orcid.org/developer-tools">应用申请</a></td>
    </tr>    
</table>

### 变更
v5 版本全面重写，不兼容以前，调用方法更简单简洁  
移除 Newtonsoft.Json 组件，改为 System.Text.Json  
微软含新旧模式（注意新旧版本标识不相同）  
钉钉含新旧模式（新：企业内部开发 H5微应用；旧：移动应用接入 扫码登录）  

#### 2024-10-17
新增 AtomGit、ORCID、GitLab  
删除 字段 PublicUserResult.`Gender`  
修改 字段 PublicUserResult.`Intro` 为 `Bio`  

### 使用
v4 旧版本使用示例 `Netnr.Demo/Controllers/LoginController.cs`

极简调用，详情参考 `Netnr.Demo/Controllers/AccountController.cs`
```csharp
// 初始化配置，推荐使用 LoginTo.InitConfig 方法读取配置

QQ.AppId = "";
QQ.AppKey = "";
QQ.Redirect_Uri = "https://devd.io:6651/account/authcallback/qq";
```

```csharp
/// <summary>
/// 登录、绑定
/// </summary>
/// <param name="id">哪家</param>
/// <returns></returns>
[HttpGet]
public IActionResult Auth([FromRoute] LoginWhich? id)
{
    if (id.HasValue)
    {
        //根据 state 字段加前缀 login 或 bind 来区分
        DocModel authResult = LoginTo.EntryOfStep<object, object>(id.Value, LoginStep.Authorize, stateCall: (state) => $"login_{state}");
        if (!string.IsNullOrEmpty(authResult.Raw))
        {
            return Redirect(authResult.Raw);
        }
    }

    return BadRequest();
}
```

```csharp
/// <summary>
/// 回调
/// </summary>
/// <param name="id">哪家</param>
/// <param name="authResult">接收授权码</param>
/// <returns></returns>
[HttpGet]
public IActionResult AuthCallback([FromRoute] LoginWhich id, AuthorizeResult authResult)
{
    //极简拿到最终用户信息，参考详情可得到步骤信息
    var publicUser = LoginTo.Entry(id, authResult);

    var result = publicUser.ToJson(true);
    Console.WriteLine(result);

    return Ok(result);
}
```

### 注意
默认构建的授权调整链接是基于 PC，而有些是区分移动端、扫码等，需要根据客户端来源构建对应的授权跳转链接。