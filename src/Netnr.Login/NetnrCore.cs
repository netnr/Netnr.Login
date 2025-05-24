global using System;
global using System.IO;
global using System.Net;
global using System.Linq;
global using System.Reflection;
global using System.ComponentModel;
global using System.Globalization;
global using System.Text;
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using System.Text.Encodings.Web;
global using System.Collections.Generic;
global using System.Security.Cryptography;

namespace Netnr.Login;

/// <summary>
/// Common
/// </summary>
internal static partial class NetnrCore
{
    /// <summary>
    /// STJ 时间格式化
    /// </summary>
    public class DateTimeJsonConverterTo(string formatter = DateTimeJsonConverterTo.DefaultFormatter) : JsonConverter<DateTime>
    {
        public const string DefaultFormatter = "yyyy-MM-dd HH:mm:ss.fff";

        public string Formatter { get; set; } = formatter;

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(Formatter));
        }
    }

    /// <summary>
    /// 构建 JSON 序列化选项
    /// </summary>
    /// <param name="formatter">时间格式</param>
    /// <param name="useStrict">严格模式</param>
    /// <returns></returns>
    public static JsonSerializerOptions JSOptions(string formatter = DateTimeJsonConverterTo.DefaultFormatter, bool useStrict = false)
    {
        var options = new JsonSerializerOptions()
        {
            //忽略大小写
            PropertyNameCaseInsensitive = !useStrict,
            //允许注释
            ReadCommentHandling = useStrict ? JsonCommentHandling.Disallow : JsonCommentHandling.Skip,
            //允许带引号的数字
            NumberHandling = useStrict ? JsonNumberHandling.Strict : JsonNumberHandling.AllowReadingFromString,
            //原样输出
            PropertyNamingPolicy = null,
            //编码
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            //格式化
            Converters = {
                new DateTimeJsonConverterTo(formatter), //时间格式化
                new JsonStringEnumConverter(), //枚举字符串
            }
        };

        return options;
    }

    /// <summary>
    /// JsonNode 反序列化选项
    /// </summary>
    /// <returns></returns>
    public static JsonDocumentOptions JDOptions() => new()
    {
        CommentHandling = JsonCommentHandling.Skip,
        AllowTrailingCommas = true
    };

    /// <summary>
    /// 序列化，对象转为 JSON 字符串
    /// </summary>
    /// <param name="obj">对象</param>
    /// <param name="indented">缩进输出</param>
    /// <param name="dateTimeFormatter">时间格式化</param>
    /// <returns></returns>
    public static string ToJson(this object obj, bool indented = false, string dateTimeFormatter = DateTimeJsonConverterTo.DefaultFormatter)
    {
        var options = JSOptions(dateTimeFormatter);
        options.WriteIndented = indented;

        var result = JsonSerializer.Serialize(obj, options);
        return result;
    }

    /// <summary>
    /// [只读]反序列化，JSON 字符串转为对象
    /// </summary>
    /// <param name="json"></param>
    /// <returns></returns>
    public static JsonElement DeJson(this string json) => JsonDocument.Parse(json, JDOptions()).RootElement;

    /// <summary>
    /// 反序列化，JSON 字符串转为类型
    /// </summary>
    /// <typeparam name="T">实体泛型</typeparam>
    /// <param name="json">JSON 字符串</param>
    /// <param name="formatter"></param>
    /// <param name="useStrict">严格模式</param>
    public static T DeJson<T>(this string json, string formatter = DateTimeJsonConverterTo.DefaultFormatter, bool useStrict = false)
        => JsonSerializer.Deserialize<T>(json, JSOptions(formatter, useStrict));

    /// <summary>
    /// 获取值（无效类型返回默认值）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ele"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static T GetValue<T>(this JsonElement ele, string name)
    {
        var val = GetValue(ele, name);
        if (!string.IsNullOrWhiteSpace(val))
        {
            try
            {
                return val.ToConvert<T>();
            }
            catch (Exception) { }
        }
        return default;
    }

    /// <summary>
    /// 获取值（无效返回 null）
    /// </summary>
    /// <param name="ele"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string GetValue(this JsonElement ele, string name)
    {
        if (ele.TryGetProperty(name, out JsonElement val))
        {
            return val.ToString();
        }
        return null;
    }

    /// <summary>
    /// 获取值
    /// </summary>
    /// <param name="ele"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string GetValue(this JsonElement? ele, string name)
    {
        if (ele != null && ele.Value.TryGetProperty(name, out JsonElement val))
        {
            return val.ToString();
        }
        return null;
    }

    /// <summary>
    /// 值类型转换
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <param name="value">值</param>
    /// <returns></returns>
    public static T ToConvert<T>(this string value) => (T)ToConvert(value, typeof(T));

    /// <summary>
    /// 值类型转换
    /// </summary>
    /// <param name="type">类型</param>
    /// <param name="value">值</param>
    /// <returns></returns>
    public static object ToConvert(this string value, Type type)
    {
        if (type == typeof(object))
        {
            return value;
        }

        if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }
            return ToConvert(value, Nullable.GetUnderlyingType(type));
        }

        var converter = TypeDescriptor.GetConverter(type);
        if (converter.CanConvertFrom(typeof(string)))
        {
            return converter.ConvertFromInvariantString(value);
        }

        return null;
    }

    /// <summary>
    /// 编码
    /// </summary>
    /// <param name="uri">内容</param>
    /// <param name="charset">编码格式</param>
    /// <returns></returns>
    public static string ToEncode(this string uri, string charset = "utf-8")
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
    /// 将Datetime转换成时间戳，10位：秒 或 13位：毫秒
    /// </summary>
    /// <param name="datetime"></param>
    /// <param name="isms">毫秒，默认false为秒，设为true，返回13位，毫秒</param>
    /// <returns></returns>
    public static long ToTimestamp(this DateTime datetime, bool isms = false)
    {
        var t = datetime.ToUniversalTime().Ticks - 621355968000000000;
        var tc = t / (isms ? 10000 : 10000000);
        return tc;
    }

    /// <summary>
    /// 转为参数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="model"></param>
    /// <param name="nameLowercase"></param>
    /// <param name="exclude">排除</param>
    /// <returns></returns>
    public static string ToParameters<T>(this T model, bool nameLowercase = true, string exclude = "API_") where T : class
    {
        var list = new List<string>();
        var hash = string.Empty;
        var pis = model.GetType().GetProperties();
        foreach (var pi in pis)
        {
            if (!pi.Name.StartsWith(exclude))
            {
                var val = pi.GetValue(model, null);
                if (val != null)
                {
                    var name = nameLowercase ? pi.Name.ToLower() : pi.Name;
                    list.Add($"{name}={val.ToString().ToEncode()}");
                }
            }
            //微信公众平台，链接带 hash
            else if (pi.Name == "API_Hash")
            {
                hash = pi.GetValue(model, null).ToString();
            }
        }
        var result = string.Join("&", list) + hash;
        return result;
    }
}

/// <summary>
/// HTTP请求
/// </summary>
internal partial class HttpTo
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
#pragma warning disable SYSLIB0014
        var request = (HttpWebRequest)WebRequest.Create(url);
#pragma warning restore SYSLIB0014

        request.Method = type;
        request.KeepAlive = true;
        request.AllowAutoRedirect = true;
        request.MaximumAutomaticRedirections = 4;
        request.Timeout = short.MaxValue * 3;//MS
        request.ContentType = "application/x-www-form-urlencoded";
        request.UserAgent = "Netnr.Login";

        if (type != "GET" && type != "DELETE" && data != null)
        {
            //发送内容
            byte[] bytes = Encoding.GetEncoding(charset).GetBytes(data);
            request.ContentLength = bytes.Length;
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
        try
        {
            var response = (HttpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            if (string.Compare(response.ContentEncoding, "gzip", true) >= 0)
                responseStream = new System.IO.Compression.GZipStream(responseStream, System.IO.Compression.CompressionMode.Decompress);

            using var sr = new StreamReader(responseStream, Encoding.GetEncoding(charset));
            var result = sr.ReadToEnd();
            return result;
        }
        catch (WebException ex)
        {
            if (ex.Response != null)
            {
                using Stream stream = ex.Response.GetResponseStream();
                using var reader = new StreamReader(stream);
                var result = reader.ReadToEnd();

                if (ex.Response is HttpWebResponse httpResponse)
                {
                    var statusCode = (int)httpResponse.StatusCode;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"StatusCode: {statusCode}{Environment.NewLine}{result}");
                    Console.ResetColor();
                }
                Console.WriteLine(result);
            }
            throw;
        }
    }
}
