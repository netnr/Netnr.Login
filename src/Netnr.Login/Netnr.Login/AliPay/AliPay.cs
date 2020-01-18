using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Netnr.Login
{
    /// <summary>
    /// 支付宝
    /// </summary>
    public class AliPay
    {
        /// <summary>
        /// Step1：请求用户授权Token
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string AuthorizeHref(AliPay_Authorize_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            return string.Concat(new string[] {
                AliPayConfig.API_Authorize,
                "?app_id=",
                entity.app_id,
                "&state=",
                entity.state,
                "&redirect_uri=",
                entity.redirect_uri.ToEncode(),
                "&scope=",
                entity.scope });
        }

        /// <summary>
        /// Step2：获取授权过的Access Token
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AliPay_AccessToken_ResultEntity AccessToken(AliPay_AccessToken_RequestEntity entity)
        {
            Signature(entity);

            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            string pars = LoginBase.EntityToPars(entity);
            string result = Core.HttpTo.Get(AliPayConfig.API_Gateway + "?" + pars);

            AliPay_AccessToken_ResultEntity outmo = null;
            if (result.Contains("alipay_system_oauth_token_response"))
            {
                outmo = result.ToJObject()["alipay_system_oauth_token_response"].ToJson().ToEntity<AliPay_AccessToken_ResultEntity>();
            }

            if (result.Contains("error_response"))
            {
                outmo = result.ToJObject()["error_response"].ToJson().ToEntity<AliPay_AccessToken_ResultEntity>();
            }

            return outmo;
        }

        /// <summary>
        /// Step3：获取个人信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static AliPay_User_ResultEntity User(AliPay_User_RequestEntity entity)
        {
            Signature(entity);

            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            string pars = LoginBase.EntityToPars(entity);
            string result = Core.HttpTo.Get(AliPayConfig.API_Gateway + "?" + pars);

            AliPay_User_ResultEntity outmo = null;
            if (result.Contains("alipay_user_info_share_response"))
            {
                outmo = result.ToJObject()["alipay_user_info_share_response"].ToJson().ToEntity<AliPay_User_ResultEntity>();
            }

            if (result.Contains("error_response"))
            {
                outmo = result.ToJObject()["error_response"].ToJson().ToEntity<AliPay_User_ResultEntity>();
            }

            return outmo;
        }

        #region 签名

        /// <summary>
        /// 签名
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mo"></param>
        /// <param name="charset">编码，默认UTF8</param>
        /// <param name="signType">加密类型，默认RSA2</param>
        public static void Signature<T>(T mo, string charset = null, string signType = "RSA2") where T : new()
        {
            var parameters = new Dictionary<string, string>();

            var pis = mo.GetType().GetProperties();
            foreach (var pi in pis)
            {
                string value = pi.GetValue(mo, null)?.ToString();
                parameters.Add(pi.Name, value);
            }

            // 第一步：把字典按Key的字母顺序排序
            IDictionary<string, string> sortedParams = new SortedDictionary<string, string>(parameters, StringComparer.Ordinal);
            IEnumerator<KeyValuePair<string, string>> dem = sortedParams.GetEnumerator();

            // 第二步：把所有参数名和参数值串在一起
            StringBuilder query = new StringBuilder("");
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
            RSACryptoServiceProvider rsaCsp = DecodeRSAPrivateKey(AliPayConfig.AppPrivateKey, signType);

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
                if (pi.Name == "sign")
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
            MemoryStream mem = new MemoryStream(privkey);
            BinaryReader binr = new BinaryReader(mem);  //wrap Memory Stream with BinaryReader for easy reading
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
                CspParameters CspParameters = new CspParameters();
                CspParameters.Flags = CspProviderFlags.UseMachineKeyStore;

                int bitLen = 1024;
                if ("RSA2".Equals(signType))
                {
                    bitLen = 2048;
                }

                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(bitLen, CspParameters);
                RSAParameters RSAparams = new RSAParameters();
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
}