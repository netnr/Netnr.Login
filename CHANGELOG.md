# 更新日志

### [ⅴ3.5.2] - 2020-01-18
- 修复 支付宝（AliPay）,必填验证改为生成签名之后

### [ⅴ3.5.1] - 2019-12-26
- 修复 `Netnr.Core v1.2.2` 的拓展方法 `ToTimestamp` 与 钉钉（DingTalk） 冲突

### [ⅴ3.5.0] - 2019-11-12
- 添加 StackOverflow

### [ⅴ3.4.1] - 2019-11-11
- 调整 支付宝 签名方法内置，无须手动调用
- 添加 README 给出SVG矢量图标链接，方便大家下载或直接使用

### [ⅴ3.4.0] - 2019-11-09
- 添加 支付宝（AliPay）

### [ⅴ3.3.0] - 2019-10-17
- 添加 Google
- 升级为 `netstandard2.1`

### [ⅴ3.2.0] - 2019-09-16
- 添加 Gitee
- 添加 钉钉
- 类名 `Taobao` 改为 `TaoBao`
- 添加 `LoginBase.AuthorizeResult` 通用的授权返回参数（code、state）

### [ⅴ3.1.0] - 2019-03-21
- NuGet发布的包带注释
- 调整 依赖 `Netnr.Core` 常用类库

### [ⅴ3.0.1] - 2019-03-06
- 更新微信 至 NuGet
- 添加示例代码项目 `Netnr.Login.Sample`

### [ⅴ3.0.0] - 2019-01-23
- LoginBase.RequestTo 类名改为 `HttpTo`
- 添加 微信登录 支持，暂时没更新NuGet，手里没资源，还没有测试，测试后会更新