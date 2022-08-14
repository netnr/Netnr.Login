# Netnr.Login
第三方 OAuth2 授权登录，QQ、微信（Weixin）、微博（Weibo）、淘宝（Taobao）、支付宝（AliPay）、钉钉（DingTalk）、码云（Gitee）、GitHub、微软（Microsoft ）、StackOverflow、谷歌（Google）

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
        <td><img src="https://gs.zme.ink/static/login/weixin.svg" height="30" title="微信/Weixin"></td>
        <td><a target="_blank" href="https://developers.weixin.qq.com/doc/oplatform/Website_App/WeChat_Login/Wechat_Login.html">参考文档</a></td>
        <td><a target="_blank" href="https://open.weixin.qq.com">应用申请</a></td>
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
</table>

### 变更
- v5 版本全面重写，不兼容以前，调用方法更简单简洁
- 移除 Newtonsoft.Json 组件，改为 System.Text.Json
- 微软含新旧模式（注意新旧版本标识不相同）
- 钉钉含新旧模式（新版本：企业内部开发 H5微应用；旧版本：移动应用接入 扫码登录）
- 微信需要企业认证，没有测试，如有测试用户请反馈，谢谢

### 使用
- v4 旧版本使用示例 `Netnr.Demo/Controllers/LoginController.cs`
- 新版本使用示例 `Netnr.Demo/Controllers/AccountController.cs`