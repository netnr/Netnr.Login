namespace Netnr.Login
{
    /// <summary>
    /// 钉钉
    /// </summary>
    public class StackOverflow
    {
        /// <summary>
        /// 获取access_token
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static StackOverflow_AccessToken_ResultEntity AccessToken(StackOverflow_AccessToken_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            string pars = LoginBase.EntityToPars(entity);
            var result = Core.HttpTo.Post(StackOverflowConfig.API_AccessToken, pars);

            result = "{\"" + result.Replace("=", "\":\"").Replace("&", "\",\"") + "\"}";

            var outmo = LoginBase.ResultOutput<StackOverflow_AccessToken_ResultEntity>(result);

            return outmo;
        }

        /// <summary>
        /// 获取 用户信息
        /// </summary>
        /// <param name="entity">签名参数</param>
        /// <returns></returns>
        public static StackOverflow_User_ResultEntity User(StackOverflow_User_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            string pars = LoginBase.EntityToPars(entity);
            string result = Core.HttpTo.Get(StackOverflowConfig.API_User + "?" + pars);

            StackOverflow_User_ResultEntity outmo = null;

            var jo = result.ToJObject();
            if (jo.ContainsKey("items"))
            {
                outmo = LoginBase.ResultOutput<StackOverflow_User_ResultEntity>(jo["items"][0].ToJson());
            }

            return outmo;
        }

        /// <summary>
        /// 请求授权地址
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string AuthorizeHref(StackOverflow_Authorize_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            return string.Concat(new string[] {
                StackOverflowConfig.API_Authorize,
                "?client_id=",
                entity.client_id,
                "&scope=",
                entity.scope,
                "&state=",
                entity.state,
                "&redirect_uri=",
                entity.redirect_uri.ToEncode()});
        }
    }
}