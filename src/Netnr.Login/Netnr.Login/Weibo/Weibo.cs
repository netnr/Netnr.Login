using System.Collections.Generic;

namespace Netnr.Login
{
    /// <summary>
    /// 
    /// </summary>
    public class Weibo
    {
        /// <summary>
        /// Step1：请求用户授权Token
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string AuthorizeHref(Weibo_Authorize_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            return string.Concat(new string[] {
                WeiboConfig.API_Authorize,
                "?client_id=",
                entity.client_id,
                "&response_type=",
                entity.response_type,
                "&state=",
                entity.state,
                "&redirect_uri=",
                entity.redirect_uri.ToEncode()});
        }

        /// <summary>
        /// Step2：获取授权过的Access Token
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static Weibo_AccessToken_ResultEntity AccessToken(Weibo_AccessToken_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            string pars = LoginBase.EntityToPars(entity);
            string result = Core.HttpTo.Post(WeiboConfig.API_AccessToken, pars);

            var outmo = LoginBase.ResultOutput<Weibo_AccessToken_ResultEntity>(result);

            return outmo;
        }

        /// <summary>
        /// Step3：查询用户access_token的授权相关信息，包括授权时间，过期时间和scope权限。
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static Weibo_GetTokenInfo_ResultEntity GetTokenInfo(Weibo_GetTokenInfo_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            string pars = LoginBase.EntityToPars(entity);
            string result = Core.HttpTo.Post(WeiboConfig.API_GetTokenInfo, pars);

            var outmo = LoginBase.ResultOutput<Weibo_GetTokenInfo_ResultEntity>(result);

            return outmo;
        }

        /// <summary>
        /// Step4：根据用户ID获取用户信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static Weibo_UserShow_ResultEntity UserShow(Weibo_UserShow_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            string pars = LoginBase.EntityToPars(entity);
            string result = Core.HttpTo.Get(WeiboConfig.API_UserShow + "?" + pars);

            var outmo = LoginBase.ResultOutput<Weibo_UserShow_ResultEntity>(result, new List<string> { "status" });

            return outmo;
        }
    }
}