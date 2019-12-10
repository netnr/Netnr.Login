namespace Netnr.Login
{
    /// <summary>
    /// 钉钉
    /// </summary>
    public class DingTalk
    {
        /// <summary>
        /// 获取access_token
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DingTalk_AccessToken_ResultEntity AccessToken(DingTalk_AccessToken_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            string pars = LoginBase.EntityToPars(entity);
            var result = Core.HttpTo.Get(DingTalkConfig.API_AccessToken + "?" + pars);

            var outmo = LoginBase.ResultOutput<DingTalk_AccessToken_ResultEntity>(result);

            return outmo;
        }

        /// <summary>
        /// 获取 用户信息
        /// </summary>
        /// <param name="entity">签名参数</param>
        /// <param name="code">临时授权码</param>
        /// <returns></returns>
        public static DingTalk_User_ResultEntity User(DingTalk_User_RequestEntity entity, string code)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            string pars = LoginBase.EntityToPars(entity);

            var hwr = Core.HttpTo.HWRequest(DingTalkConfig.API_User + "?" + pars, "POST", new { tmp_auth_code = code }.ToJson());
            hwr.ContentType = "application/json";
            var result = Core.HttpTo.Url(hwr);

            var ro = result.ToJObject();
            if (ro["errcode"].ToString() == "0")
            {
                result = result.ToJObject()["user_info"].ToJson();
            }
            else
            {
                return null;
            }

            var outmo = LoginBase.ResultOutput<DingTalk_User_ResultEntity>(result);

            return outmo;
        }

        /// <summary>
        /// 请求授权地址,扫码登录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string AuthorizeHref_ScanCode(DingTalk_Authorize_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            return string.Concat(new string[] {
                DingTalkConfig.API_Authorize_ScanCode,
                "?appid=",
                entity.appid,
                "&response_type=",
                entity.response_type,
                "&scope=",
                entity.scope,
                "&state=",
                entity.state,
                "&redirect_uri=",
                entity.redirect_uri.ToEncode()});
        }

        /// <summary>
        /// 请求授权地址,密码登录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string AuthorizeHref_Password(DingTalk_Authorize_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            return string.Concat(new string[] {
                DingTalkConfig.API_Authorize_Password,
                "?appid=",
                entity.appid,
                "&response_type=",
                entity.response_type,
                "&scope=",
                entity.scope,
                "&state=",
                entity.state,
                "&redirect_uri=",
                entity.redirect_uri.ToEncode()});
        }
    }
}