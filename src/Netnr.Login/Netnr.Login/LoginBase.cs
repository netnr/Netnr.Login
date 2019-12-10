using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Netnr.Login
{
    /// <summary>
    /// 基础支持
    /// </summary>
    public class LoginBase
    {
        /// <summary>
        /// 登录类型枚举
        /// </summary>
        public enum LoginType
        {
            /// <summary>
            /// 腾讯QQ
            /// </summary>
            QQ,
            /// <summary>
            /// 新浪微博
            /// </summary>
            WeiBo,
            /// <summary>
            /// 腾讯微信
            /// </summary>
            WeChat,
            /// <summary>
            /// GitHub
            /// </summary>
            GitHub,
            /// <summary>
            /// Gitee
            /// </summary>
            Gitee,
            /// <summary>
            /// 淘宝（天猫）
            /// </summary>
            TaoBao,
            /// <summary>
            /// 微软
            /// </summary>
            MicroSoft,
            /// <summary>
            /// 钉钉
            /// </summary>
            DingTalk,
            /// <summary>
            /// 谷歌
            /// </summary>
            Google,
            /// <summary>
            /// 支付宝
            /// </summary>
            AliPay,
            /// <summary>
            /// Stack Overflow
            /// </summary>
            StackOverflow
        }

        /// <summary>
        /// 接收授权码、防伪标识
        /// </summary>
        public class AuthorizeResult
        {
            /// <summary>
            /// 授权码
            /// </summary>
            public string code { get; set; }

            /// <summary>
            /// 授权码，AliPay支付宝
            /// </summary>
            public string auth_code { get; set; }

            /// <summary>
            /// 防伪参数，如果传递参数，会回传该参数。
            /// </summary>
            public string state { get; set; }
        }

        /// <summary>
        /// 实体 转 Pars
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string EntityToPars<T>(T entity)
        {
            string result = string.Empty;
            var pis = entity.GetType().GetProperties();
            foreach (var pi in pis)
            {
                string value = pi.GetValue(entity, null)?.ToString();
                if (value != null)
                {
                    result += "&" + pi.Name + "=" + value.ToEncode();
                }
            }
            return result.TrimStart('&');
        }

        /// <summary>
        /// 处理结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">请求的结果</param>
        /// <param name="resultNeedJObject">处理的类型，默认JObject</param>
        /// <returns></returns>
        public static T ResultOutput<T>(string result, List<string> resultNeedJObject = null) where T : class, new()
        {
            var mo = new T();
            var pis = mo.GetType().GetProperties();
            var jo = JObject.Parse(result);
            foreach (var pi in pis)
            {
                object value;
                try
                {
                    Type type;
                    if (pi.PropertyType.FullName.Contains("System.Nullable"))
                    {
                        type = Type.GetType("System." + pi.PropertyType.FullName.Split(',')[0].Split('.')[2]);
                    }
                    else
                    {
                        type = pi.PropertyType;
                    }
                    value = Convert.ChangeType(jo[pi.Name].ToString(), type);
                }
                catch (Exception)
                {
                    value = null;
                }

                if (resultNeedJObject?.Count > 0)
                {
                    try
                    {
                        if (resultNeedJObject.Contains(pi.Name))
                        {
                            value = JObject.Parse(jo[pi.Name].ToString());
                        }
                    }
                    catch (Exception)
                    {
                        value = null;
                    }
                }
                pi.SetValue(mo, value, null);
            }

            return mo;
        }

        /// <summary>
        /// 验证对象是否有效
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool IsValid<T>(T entity) where T : new()
        {
            bool b = true;
            var reqName = typeof(Required).Name;
            var pis = entity.GetType().GetProperties();
            foreach (var pi in pis)
            {
                var isReq = false;
                object[] attrs = pi.GetCustomAttributes(true);
                foreach (var attr in attrs)
                {
                    var agt = attr.GetType();
                    if (agt.Name == reqName)
                    {
                        isReq = true;
                        break;
                    }
                }
                if (isReq)
                {
                    var value = pi.GetValue(entity, null);
                    if (value == null || value.ToString() == "")
                    {
                        b = false;
                        break;
                    }
                }
            }
            return b;
        }
    }
}