# Netnr.Login
第三方 OAuth 授权登录，QQ、微信（WeChat）、微博（Weibo）、GitHub、码云（Gitee）、淘宝（天猫）、微软（Microsoft ）、钉钉（DingTalk）、谷歌（Google）、支付宝（AliPay）、StackOverflow

### 安装 (NuGet)
```
Install-Package Netnr.Login
```

### 支持第三方登录
<table>
    <tr><th>三方</th><th>参考文档</th><th>应用申请（已登录）</th></tr>
    <tr>
        <td><img src="https://s1.netnr.eu.org/static/login/qq.svg" height="30" title="QQ"></td>
        <td><a target="_blank" href="https://wiki.connect.qq.com/准备工作_oauth2-0">参考文档</a></td>
        <td><a target="_blank" href="https://connect.qq.com/manage.html">应用申请</a></td>
    </tr>
    <tr>
        <td><img src="https://s1.netnr.eu.org/static/login/wechat.svg" height="30" title="微信/WeChat"></td>
        <td><a target="_blank" href="https://developers.weixin.qq.com/doc/oplatform/Website_App/WeChat_Login/Wechat_Login.html">参考文档</a></td>
        <td><a target="_blank" href="https://open.weixin.qq.com">应用申请</a></td>
    </tr>
    <tr>
        <td><img src="https://s1.netnr.eu.org/static/login/weibo.svg" height="30" title="新浪微博"></td>
        <td><a target="_blank" href="https://open.weibo.com/wiki/授权机制说明">参考文档</a></td>
        <td><a target="_blank" href="https://open.weibo.com/apps">应用申请</a></td>
    </tr>
    <tr>
        <td><img src="https://s1.netnr.eu.org/static/login/github.svg" height="30" title="GitHub"></td>
        <td><a target="_blank" href="https://docs.github.com/en/developers/apps/building-oauth-apps/authorizing-oauth-apps">参考文档</a></td>
        <td><a target="_blank" href="https://github.com/settings/developers">应用申请</a></td>
    </tr>
    <tr>
        <td><img src="https://s1.netnr.eu.org/static/login/gitee.svg" height="30" title="码云/Gitee"></td>
        <td><a target="_blank" href="https://gitee.com/api/v5/oauth_doc">参考文档</a></td>
        <td><a target="_blank" href="https://gitee.com/oauth/applications">应用申请</a></td>
    </tr>
    <tr>
        <td><img src="https://s1.netnr.eu.org/static/login/taobao.svg" height="30" title="淘宝/天猫"></td>
        <td><a target="_blank" href="https://open.taobao.com/doc.htm?spm=a219a.7386797.0.0.4e00669acnkQy6&source=search&docId=105590&docType=1">参考文档</a></td>
        <td><a target="_blank" href="https://console.open.taobao.com/">应用申请</a></td>
    </tr>
    <tr>
        <td><img src="https://s1.netnr.eu.org/static/login/microsoft.svg" height="30" title="微软/Microsoft"></td>
        <td><a target="_blank" href="https://docs.microsoft.com/zh-cn/graph/auth/">参考文档</a></td>
        <td><a target="_blank" href="https://portal.azure.com/#blade/Microsoft_AAD_IAM/ActiveDirectoryMenuBlade/RegisteredApps">应用申请</a></td>
    </tr>
    <tr>
        <td><img src="https://s1.netnr.eu.org/static/login/dingtalk.svg" height="30" title="钉钉/DingTalk"></td>
        <td><a target="_blank" href="https://developers.dingtalk.com/document/app/scan-qr-code-to-login-isvapp">参考文档</a></td>
        <td><a target="_blank" href="https://open-dev.dingtalk.com/#/loginMan">应用申请</a></td>
    </tr>
    <tr>
        <td><img src="https://s1.netnr.eu.org/static/login/google.svg" height="30" title="谷歌/Google"></td>
        <td><a target="_blank" href="https://developers.google.com/identity/protocols/oauth2/openid-connect">参考文档</a></td>
        <td><a target="_blank" href="https://console.developers.google.com/apis/credentials">应用申请</a></td>
    </tr>
    <tr>
        <td><img src="https://s1.netnr.eu.org/static/login/alipay.svg" height="30" title="支付宝/AliPay"></td>
        <td><a target="_blank" href="https://opendocs.alipay.com/open/263/105809">参考文档</a></td>
        <td><a target="_blank" href="https://openhome.alipay.com/platform/developerIndex.htm">应用申请</a></td>
    </tr>
    <tr>
        <td><img src="https://s1.netnr.eu.org/static/login/stackoverflow.svg" height="30" title="Stack Overflow"></td>
        <td><a target="_blank" href="https://api.stackexchange.com">参考文档</a></td>
        <td><a target="_blank" href="https://stackapps.com/apps/oauth/register">应用申请</a></td>
    </tr>
</table>

### 使用
参考：`Netnr.Test/Controllers/LoginController.cs`  
提醒：一般第三方登录都有一个 **state** 参数，用于防止CSRF攻击（防伪），可以利用该参数添加 登录、注册、解绑等标注前缀