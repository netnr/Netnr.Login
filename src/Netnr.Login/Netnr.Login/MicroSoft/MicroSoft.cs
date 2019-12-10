using System.Collections.Generic;

namespace Netnr.Login
{
    /// <summary>
    /// 
    /// </summary>
    public class MicroSoft
    {
        /// <summary>
        /// 请求授权地址
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string AuthorizeHref(MicroSoft_Authorize_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            return string.Concat(new string[] {
                MicroSoftConfig.API_Authorize,
                "?client_id=",
                entity.client_id,
                "&scope=",
                entity.scope,
                "&response_type=",
                entity.response_type,
                "&redirect_uri=",
                entity.redirect_uri.ToEncode()});
        }

        /// <summary>
        /// 获取 access token
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static MicroSoft_AccessToken_ResultEntity AccessToken(MicroSoft_AccessToken_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            string pars = LoginBase.EntityToPars(entity);

            string result = Core.HttpTo.Post(MicroSoftConfig.API_AccessToken, pars);

            var outmo = LoginBase.ResultOutput<MicroSoft_AccessToken_ResultEntity>(result);

            return outmo;
        }

        /// <summary>
        /// 获取 用户信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static MicroSoft_User_ResultEntity User(MicroSoft_User_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            string pars = LoginBase.EntityToPars(entity);

            var hwr = Core.HttpTo.HWRequest(MicroSoftConfig.API_User + "?" + pars);
            hwr.ContentType = null;
            string result = Core.HttpTo.Url(hwr);
            var outmo = LoginBase.ResultOutput<MicroSoft_User_ResultEntity>(result, new List<string> { "emails" });

            return outmo;
        }
    }
}