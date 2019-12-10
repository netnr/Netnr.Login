namespace Netnr.Login
{
    /// <summary>
    /// 
    /// </summary>
    public class Google
    {
        /// <summary>
        /// 请求授权地址
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string AuthorizeHref(Google_Authorize_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            return string.Concat(new string[] {
                GoogleConfig.API_Authorize,
                "?client_id=",
                entity.client_id,
                "&response_type=",
                entity.response_type,
                "&scope=",
                entity.scope.ToEncode(),
                "&state=",
                entity.state,
                "&redirect_uri=",
                entity.redirect_uri.ToEncode()});
        }

        /// <summary>
        /// 获取 access token
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static Google_AccessToken_ResultEntity AccessToken(Google_AccessToken_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            string pars = LoginBase.EntityToPars(entity);

            var result = Core.HttpTo.Post(GoogleConfig.API_AccessToken, pars);

            var outmo = LoginBase.ResultOutput<Google_AccessToken_ResultEntity>(result);

            return outmo;
        }

        /// <summary>
        /// 获取 用户信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static Google_User_ResultEntity User(Google_User_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            string pars = LoginBase.EntityToPars(entity);

            var result = Core.HttpTo.Get(GoogleConfig.API_User + "?" + pars);

            var outmo = LoginBase.ResultOutput<Google_User_ResultEntity>(result);

            return outmo;
        }
    }
}