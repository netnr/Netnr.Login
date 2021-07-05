﻿namespace Netnr.Login
{
    /// <summary>
    /// 
    /// </summary>
    public class Gitee
    {
        /// <summary>
        /// 请求授权地址
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string AuthorizeHref(Gitee_Authorize_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            return string.Concat(new string[] {
                GiteeConfig.API_Authorize,
                "?client_id=",
                entity.client_id,
                "&response_type=",
                entity.response_type,
                "&state=",
                entity.state,
                "&redirect_uri=",
                NetnrCore.ToEncode(entity.redirect_uri)});
        }

        /// <summary>
        /// 获取 access token
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static Gitee_AccessToken_ResultEntity AccessToken(Gitee_AccessToken_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            string pars = LoginBase.EntityToPars(entity);

            var result = NetnrCore.HttpTo.Post(GiteeConfig.API_AccessToken, pars);

            var outmo = LoginBase.ResultOutput<Gitee_AccessToken_ResultEntity>(result);

            return outmo;
        }

        /// <summary>
        /// 获取 用户信息
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public static Gitee_User_ResultEntity User(string access_token)
        {
            if (string.IsNullOrWhiteSpace(access_token))
            {
                return null;
            }

            var result = NetnrCore.HttpTo.Get($"{GiteeConfig.API_User}?access_token={NetnrCore.ToEncode(access_token)}");

            var outmo = LoginBase.ResultOutput<Gitee_User_ResultEntity>(result);

            return outmo;
        }
    }
}