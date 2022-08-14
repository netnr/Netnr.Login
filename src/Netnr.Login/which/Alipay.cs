namespace Netnr.Login;

/// <summary>
/// Alipay 支付宝
/// </summary>
public class Alipay
{
    /// <summary>
    /// App Key
    /// </summary>
    public static string AppId { get; set; }

    /// <summary>
    /// App Secret
    /// </summary>
    public static string AppPrivateKey { get; set; }

    /// <summary>
    /// 回调
    /// </summary>
    public static string Redirect_Uri { get; set; }

    /// <summary>
    /// GET
    /// </summary>
    public static string API_Authorize { get; set; } = "https://openauth.alipay.com/oauth2/publicAppAuthorize.htm";

    /// <summary>
    /// GET
    /// </summary>
    public static string API_Gateway { get; set; } = "https://openapi.alipay.com/gateway.do";

    #region 签名

    /// <summary>
    /// 签名
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="mo"></param>
    /// <param name="charset">编码，默认UTF8</param>
    /// <param name="signType">加密类型，默认RSA2</param>
    internal static void Signature<T>(T mo, string charset = null, string signType = "RSA2") where T : new()
    {
        var parameters = new Dictionary<string, string>();

        var pis = mo.GetType().GetProperties();
        foreach (var pi in pis)
        {
            string value = pi.GetValue(mo, null)?.ToString();
            parameters.Add(pi.Name.ToLower(), value);
        }

        // 第一步：把字典按Key的字母顺序排序
        IDictionary<string, string> sortedParams = new SortedDictionary<string, string>(parameters, StringComparer.Ordinal);
        IEnumerator<KeyValuePair<string, string>> dem = sortedParams.GetEnumerator();

        // 第二步：把所有参数名和参数值串在一起
        StringBuilder query = new("");
        while (dem.MoveNext())
        {
            string key = dem.Current.Key;
            string value = dem.Current.Value;
            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
            {
                query.Append(key).Append("=").Append(value).Append("&");
            }
        }

        //待签名
        string data = query.ToString().TrimEnd('&');

        //处理密钥
        RSACryptoServiceProvider rsaCsp = DecodeRSAPrivateKey(AppPrivateKey, signType);

        byte[] dataBytes;
        if (string.IsNullOrEmpty(charset))
        {
            dataBytes = Encoding.UTF8.GetBytes(data);
        }
        else
        {
            dataBytes = Encoding.GetEncoding(charset).GetBytes(data);
        }

        byte[] signatureBytes;
        if ("RSA2".Equals(signType))
        {
            signatureBytes = rsaCsp.SignData(dataBytes, "SHA256");
        }
        else
        {
            signatureBytes = rsaCsp.SignData(dataBytes, "SHA1");
        }

        //赋值签名
        foreach (var pi in pis)
        {
            if (pi.Name.ToLower() == "sign")
            {
                pi.SetValue(mo, Convert.ToBase64String(signatureBytes), null);
                break;
            }
        }
    }

    private static RSACryptoServiceProvider DecodeRSAPrivateKey(string strKey, string signType)
    {
        byte[] privkey = Convert.FromBase64String(strKey);

        byte[] MODULUS, E, D, P, Q, DP, DQ, IQ;

        // --------- Set up stream to decode the asn.1 encoded RSA private key ------
        MemoryStream mem = new(privkey);
        BinaryReader binr = new(mem);  //wrap Memory Stream with BinaryReader for easy reading
        try
        {
            ushort twobytes = binr.ReadUInt16();
            if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                binr.ReadByte();    //advance 1 byte
            else if (twobytes == 0x8230)
                binr.ReadInt16();    //advance 2 bytes
            else
                return null;

            twobytes = binr.ReadUInt16();
            if (twobytes != 0x0102) //version number
                return null;
            byte bt = binr.ReadByte();
            if (bt != 0x00)
                return null;


            //------ all private key components are Integer sequences ----
            int elems = GetIntegerSize(binr);
            MODULUS = binr.ReadBytes(elems);

            elems = GetIntegerSize(binr);
            E = binr.ReadBytes(elems);

            elems = GetIntegerSize(binr);
            D = binr.ReadBytes(elems);

            elems = GetIntegerSize(binr);
            P = binr.ReadBytes(elems);

            elems = GetIntegerSize(binr);
            Q = binr.ReadBytes(elems);

            elems = GetIntegerSize(binr);
            DP = binr.ReadBytes(elems);

            elems = GetIntegerSize(binr);
            DQ = binr.ReadBytes(elems);

            elems = GetIntegerSize(binr);
            IQ = binr.ReadBytes(elems);


            // ------- create RSACryptoServiceProvider instance and initialize with public key -----
            CspParameters CspParameters = new()
            {
                Flags = CspProviderFlags.UseMachineKeyStore
            };

            int bitLen = 1024;
            if ("RSA2".Equals(signType))
            {
                bitLen = 2048;
            }

            RSACryptoServiceProvider RSA = new(bitLen, CspParameters);
            RSAParameters RSAparams = new();
            RSAparams.Modulus = MODULUS;
            RSAparams.Exponent = E;
            RSAparams.D = D;
            RSAparams.P = P;
            RSAparams.Q = Q;
            RSAparams.DP = DP;
            RSAparams.DQ = DQ;
            RSAparams.InverseQ = IQ;
            RSA.ImportParameters(RSAparams);
            return RSA;
        }
        catch (Exception)
        {
            return null;
        }
        finally
        {
            binr.Close();
        }
    }

    private static int GetIntegerSize(BinaryReader binr)
    {
        byte bt = binr.ReadByte();
        if (bt != 0x02)     //expect integer
            return 0;
        bt = binr.ReadByte();
        int count;
        if (bt == 0x81)
            count = binr.ReadByte();    // data size in next byte
        else
            if (bt == 0x82)
        {
            byte highbyte = binr.ReadByte();
            byte lowbyte = binr.ReadByte();
            byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };
            count = BitConverter.ToInt32(modint, 0);
        }
        else
        {
            count = bt;     // we already have the data size
        }

        while (binr.ReadByte() == 0x00)
        {   //remove high order zeros in data
            count -= 1;
        }
        binr.BaseStream.Seek(-1, SeekOrigin.Current);       //last ReadByte wasn't a removed zero, so back up a byte
        return count;
    }

    #endregion
}

/// <summary>
/// authorize 请求参数
/// </summary>
public class AlipayAuthorizeModel : PublicAuthorizeModel
{
    /// <summary>
    /// 构造
    /// </summary>
    public AlipayAuthorizeModel()
    {
        Redirect_Uri = Alipay.Redirect_Uri;
    }
    /// <summary>
    /// 配置 AppId
    /// </summary>
    public string App_Id { get; set; } = Alipay.AppId;
    /// <summary>
    /// 参数传递 auth_user
    /// </summary>
    public string Scope { get; set; } = "auth_user";
}

/// <summary>
/// 公共参数
/// </summary>
public class AlipayPublicModel
{
    /// <summary>
    /// 配置 AppId
    /// </summary>
    public string App_Id { get; set; } = Alipay.AppId;

    /// <summary>
    /// 接口名称
    /// </summary>
    public string Method { get; set; } = "alipay.system.oauth.token";

    /// <summary>
    /// 仅支持 JSON
    /// </summary>
    public string Format { get; set; } = "JSON";

    /// <summary>
    /// 请求使用的编码格式，如utf-8,gbk,gb2312等
    /// </summary>
    public string Charset { get; set; } = "utf-8";

    /// <summary>
    /// 商户生成签名字符串所使用的签名算法类型，目前支持RSA2和RSA，推荐使用RSA2
    /// </summary>
    public string Sign_Type { get; set; } = "RSA2";

    /// <summary>
    /// 商户请求参数的签名串
    /// </summary>
    public string Sign { get; set; }

    /// <summary>
    /// 发送请求的时间，格式"yyyy-MM-dd HH:mm:ss"
    /// </summary>
    public string Timestamp { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

    /// <summary>
    /// 调用的接口版本，固定为：1.0
    /// </summary>
    public string Version { get; set; } = "1.0";
}

/// <summary>
/// access token 请求参数 https://opendocs.alipay.com/open/02ahjv
/// </summary>
public class AlipayAccessTokenModel : AlipayPublicModel
{
    /// <summary>
    /// 值为 authorization_code 时，代表用code换取；值为refresh_token时，代表用refresh_token换取
    /// </summary>
    public string Grant_Type { get; set; } = "authorization_code";

    /// <summary>
    /// 授权码，用户对应用授权后得到。本参数在 grant_type 为 authorization_code 时必填；为 refresh_token 时不填。
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// 生成签名
    /// </summary>
    public void GenerateSignature()
    {
        Alipay.Signature(this, Charset, Sign_Type);
    }
}

/// <summary>
/// refresh token 刷新请求参数
/// </summary>
public class AlipayRefreshTokenModel : AlipayPublicModel
{
    /// <summary>
    /// 值为 authorization_code 时，代表用code换取；值为refresh_token时，代表用refresh_token换取
    /// </summary>
    public string Grant_Type { get; set; } = "refresh_token";

    /// <summary>
    /// 授权码，用户对应用授权后得到。本参数在 grant_type 为 authorization_code 时必填；为 refresh_token 时不填。
    /// </summary>
    public string Refresh_Token { get; set; }

    /// <summary>
    /// 生成签名
    /// </summary>
    public void GenerateSignature()
    {
        Alipay.Signature(this, Charset, Sign_Type);
    }
}

/// <summary>
/// user 用户信息请求参数
/// </summary>
public class AlipayUserModel : AlipayPublicModel
{
    public AlipayUserModel()
    {
        Method = "alipay.user.info.share";
    }

    /// <summary>
    /// 针对用户授权接口，获取用户相关数据时，用于标识用户授权关系
    /// </summary>
    public string Auth_Token { get; set; }

    /// <summary>
    /// 生成签名
    /// </summary>
    public void GenerateSignature()
    {
        Alipay.Signature(this, Charset, Sign_Type);
    }
}