using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Globalization;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Netnr.Login
{
    /// <summary>
    /// 扩展方法
    /// </summary>
    public class NetnrCore
    {
        /// <summary>
        /// object 转 JSON 字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="DateTimeFormat">时间格式化</param>
        /// <returns></returns>
        public static string ToJson(object obj, string DateTimeFormat = "yyyy-MM-dd HH:mm:ss")
        {
            Newtonsoft.Json.Converters.IsoDateTimeConverter dtFmt = new()
            {
                DateTimeFormat = DateTimeFormat
            };
            return JsonConvert.SerializeObject(obj, dtFmt);
        }

        /// <summary>
        /// JSON字符串 转 类型
        /// </summary>
        /// <param name="json">JSON字符串</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static object ToType(string json, Type type)
        {
            var mo = JsonConvert.DeserializeObject(json, type);
            return mo;
        }

        /// <summary>
        /// JSON字符串 转 实体
        /// </summary>
        /// <typeparam name="T">实体泛型</typeparam>
        /// <param name="json">JSON字符串</param>
        public static T ToEntity<T>(string json)
        {
            var mo = JsonConvert.DeserializeObject<T>(json);
            return mo;
        }

        /// <summary>
        /// JSON字符串 转 实体
        /// </summary>
        /// <typeparam name="T">实体泛型</typeparam>
        /// <param name="json">JSON字符串</param>
        public static List<T> ToEntitys<T>(string json)
        {
            var list = JsonConvert.DeserializeObject<List<T>>(json);
            return list;
        }

        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="uri">内容</param>
        /// <param name="charset">编码格式</param>
        /// <returns></returns>
        public static string ToEncode(string uri, string charset = "utf-8")
        {
            string URL_ALLOWED_CHARS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";

            if (string.IsNullOrEmpty(uri))
                return string.Empty;

            const string escapeFlag = "%";
            var encodedUri = new StringBuilder(uri.Length * 2);
            var bytes = Encoding.GetEncoding(charset).GetBytes(uri);
            foreach (var b in bytes)
            {
                char ch = (char)b;
                if (URL_ALLOWED_CHARS.IndexOf(ch) != -1)
                    encodedUri.Append(ch);
                else
                {
                    encodedUri.Append(escapeFlag).Append(string.Format(CultureInfo.InstalledUICulture, "{0:X2}", (int)b));
                }
            }
            return encodedUri.ToString();
        }

        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="uriToDecode">内容</param>
        /// <returns></returns>
        public static string ToDecode(string uriToDecode)
        {
            if (!string.IsNullOrEmpty(uriToDecode))
            {
                uriToDecode = uriToDecode.Replace("+", " ");
                return Uri.UnescapeDataString(uriToDecode);
            }

            return string.Empty;
        }

        /// <summary>
        /// 将Datetime转换成时间戳，10位：秒 或 13位：毫秒
        /// </summary>
        /// <param name="datetime"></param>
        /// <param name="isms">毫秒，默认false为秒，设为true，返回13位，毫秒</param>
        /// <returns></returns>
        public static long ToTimestamp(DateTime datetime, bool isms = false)
        {
            var t = datetime.ToUniversalTime().Ticks - 621355968000000000;
            var tc = t / (isms ? 10000 : 10000000);
            return tc;
        }

        /// <summary>
        /// HTTP请求
        /// </summary>
        public class HttpTo
        {
            /// <summary>
            /// HttpWebRequest对象
            /// </summary>
            /// <param name="url">地址</param>
            /// <param name="type">请求类型，默认GET</param>
            /// <param name="data">发送数据，非GET、DELETE请求</param>
            /// <param name="charset">编码，默认utf-8</param>
            /// <returns></returns>
            public static HttpWebRequest HWRequest(string url, string type = "GET", string data = null, string charset = "utf-8")
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = type;
                request.KeepAlive = true;
                request.AllowAutoRedirect = true;
                request.MaximumAutomaticRedirections = 4;
                request.Timeout = short.MaxValue * 3;//MS
                request.ContentType = "application/x-www-form-urlencoded";

                if (type != "GET" && type != "DELETE" && data != null)
                {
                    //发送内容
                    byte[] bytes = Encoding.GetEncoding(charset).GetBytes(data);
                    request.ContentLength = Encoding.GetEncoding(charset).GetBytes(data).Length;
                    Stream outputStream = request.GetRequestStream();
                    outputStream.Write(bytes, 0, bytes.Length);
                    outputStream.Close();
                }
                return request;
            }

            /// <summary>
            /// HTTP请求
            /// </summary>
            /// <param name="request">HttpWebRequest对象</param>
            /// <param name="charset">编码，默认utf-8</param>
            /// <returns></returns>
            public static string Url(HttpWebRequest request, string charset = "utf-8")
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                if (string.Compare(response.ContentEncoding, "gzip", true) >= 0)
                    responseStream = new System.IO.Compression.GZipStream(responseStream, System.IO.Compression.CompressionMode.Decompress);

                using var sr = new StreamReader(responseStream, Encoding.GetEncoding(charset));
                var result = sr.ReadToEnd();
                return result;
            }

            /// <summary>
            /// GET请求
            /// </summary>
            /// <param name="url">地址</param>
            /// <param name="charset">编码，默认utf-8</param>
            /// <returns></returns>
            public static string Get(string url, string charset = "utf-8")
            {
                var request = HWRequest(url, "GET", null, charset);
                return Url(request, charset);
            }

            /// <summary>
            /// POST请求
            /// </summary>
            /// <param name="url">地址</param>
            /// <param name="data">发送数据</param>
            /// <param name="charset">编码，默认utf-8</param>
            /// <returns></returns>
            public static string Post(string url, string data, string charset = "utf-8")
            {
                var request = HWRequest(url, "POST", data, charset);
                return Url(request, charset);
            }
        }

        /// <summary>
        /// 算法、加密、解密
        /// </summary>
        public class CalcTo
        {
            /// <summary>
            /// MD5加密 小写
            /// </summary>
            /// <param name="s">需加密的字符串</param>
            /// <param name="len">长度 默认32 可选16</param>
            /// <returns></returns>
            public static string MD5(string s, int len = 32)
            {
                string result;
                using MD5CryptoServiceProvider md5Hasher = new();
                byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(s));
                StringBuilder sb = new();
                for (int i = 0; i < data.Length; i++)
                {
                    sb.Append(data[i].ToString("x2"));
                }
                result = sb.ToString();

                //result = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(s, "MD5").ToLower();
                return len == 32 ? result : result.Substring(8, 16);
            }

            #region DES 加解密

            /// <summary> 
            /// DES 加密 
            /// </summary> 
            /// <param name="Text">内容</param> 
            /// <param name="sKey">密钥</param> 
            /// <returns></returns> 
            public static string EnDES(string Text, string sKey)
            {
                DESCryptoServiceProvider des = new();
                byte[] inputByteArray;
                inputByteArray = Encoding.Default.GetBytes(Text);
                des.Key = Encoding.ASCII.GetBytes(MD5(sKey).Substring(0, 8));
                des.IV = Encoding.ASCII.GetBytes(MD5(sKey).Substring(0, 8));
                MemoryStream ms = new();
                using CryptoStream cs = new(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                StringBuilder ret = new();
                foreach (byte b in ms.ToArray())
                {
                    ret.AppendFormat("{0:X2}", b);
                }
                return ret.ToString();
            }

            /// <summary> 
            /// DES 解密 
            /// </summary> 
            /// <param name="Text">内容</param> 
            /// <param name="sKey">密钥</param> 
            /// <returns></returns> 
            public static string DeDES(string Text, string sKey)
            {
                DESCryptoServiceProvider des = new();
                int len;
                len = Text.Length / 2;
                byte[] inputByteArray = new byte[len];
                int x, i;
                for (x = 0; x < len; x++)
                {
                    i = Convert.ToInt32(Text.Substring(x * 2, 2), 16);
                    inputByteArray[x] = (byte)i;
                }
                des.Key = Encoding.ASCII.GetBytes(MD5(sKey).Substring(0, 8));
                des.IV = Encoding.ASCII.GetBytes(MD5(sKey).Substring(0, 8));
                MemoryStream ms = new();
                using CryptoStream cs = new(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Encoding.Default.GetString(ms.ToArray());
            }

            #endregion

            #region SHA1 加密

            /// <summary>
            /// 20字节,160位
            /// </summary>
            /// <param name="str">内容</param>
            /// <returns></returns>
            public static string SHA128(string str)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(str);
                using SHA1CryptoServiceProvider SHA1 = new();
                byte[] byteArr = SHA1.ComputeHash(buffer);
                return BitConverter.ToString(byteArr);
            }

            /// <summary>
            /// 32字节,256位
            /// </summary>
            /// <param name="str">内容</param>
            /// <returns></returns>
            public static string SHA256(string str)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(str);
                using SHA256CryptoServiceProvider SHA256 = new();
                byte[] byteArr = SHA256.ComputeHash(buffer);
                return BitConverter.ToString(byteArr);
            }

            /// <summary>
            /// 48字节,384位
            /// </summary>
            /// <param name="str">内容</param>
            /// <returns></returns>
            public static string SHA384(string str)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(str);
                using SHA384CryptoServiceProvider SHA384 = new();
                byte[] byteArr = SHA384.ComputeHash(buffer);
                return BitConverter.ToString(byteArr);
            }

            /// <summary>
            /// 64字节,512位
            /// </summary>
            /// <param name="str">内容</param>
            /// <returns></returns>
            public static string SHA512(string str)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(str);
                using SHA512CryptoServiceProvider SHA512 = new();
                byte[] byteArr = SHA512.ComputeHash(buffer);
                return BitConverter.ToString(byteArr);
            }
            #endregion

            /// <summary>
            /// HMAC_SHA1 加密
            /// </summary>
            /// <param name="str">内容</param>
            /// <param name="key">密钥</param>
            /// <returns></returns>
            public static string HMAC_SHA1(string str, string key)
            {
                using HMACSHA1 hmacsha1 = new()
                {
                    Key = Encoding.UTF8.GetBytes(key)
                };
                byte[] dataBuffer = Encoding.UTF8.GetBytes(str);
                byte[] hashBytes = hmacsha1.ComputeHash(dataBuffer);
                return Convert.ToBase64String(hashBytes);
            }

            /// <summary>
            /// HMAC_SHA256 加密
            /// </summary>
            /// <param name="str">内容</param>
            /// <param name="key">密钥</param>
            /// <returns></returns>
            public static string HMAC_SHA256(string str, string key)
            {
                using HMACSHA256 hmacsha256 = new()
                {
                    Key = Encoding.UTF8.GetBytes(key)
                };
                byte[] dataBuffer = Encoding.UTF8.GetBytes(str);
                byte[] hashBytes = hmacsha256.ComputeHash(dataBuffer);
                return Convert.ToBase64String(hashBytes);
            }

            /// <summary>
            /// HMACSHA384 加密
            /// </summary>
            /// <param name="str">内容</param>
            /// <param name="key">密钥</param>
            /// <returns></returns>
            public static string HMACSHA384(string str, string key)
            {
                using HMACSHA384 hmacsha384 = new()
                {
                    Key = Encoding.UTF8.GetBytes(key)
                };
                byte[] dataBuffer = Encoding.UTF8.GetBytes(str);
                byte[] hashBytes = hmacsha384.ComputeHash(dataBuffer);
                return Convert.ToBase64String(hashBytes);
            }

            /// <summary>
            /// HMACSHA512 加密
            /// </summary>
            /// <param name="str">内容</param>
            /// <param name="key">密钥</param>
            /// <returns></returns>
            public static string HMACSHA512(string str, string key)
            {
                using HMACSHA512 hmacsha512 = new()
                {
                    Key = Encoding.UTF8.GetBytes(key)
                };
                byte[] dataBuffer = Encoding.UTF8.GetBytes(str);
                byte[] hashBytes = hmacsha512.ComputeHash(dataBuffer);
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
