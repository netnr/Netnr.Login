using System.Collections.Generic;

namespace Netnr.Login
{
    /// <summary>
    /// 
    /// </summary>
    public class GitHub
    {
        /// <summary>
        /// 请求授权地址
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string AuthorizeHref(GitHub_Authorize_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            return string.Concat(new string[] {
                GitHubConfig.API_Authorize,
                "?client_id=",
                entity.client_id,
                "&scope=",
                NetnrCore.ToEncode(entity.scope),
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
        public static GitHub_AccessToken_ResultEntity AccessToken(GitHub_AccessToken_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            string pars = LoginBase.EntityToPars(entity);

            var hwr = NetnrCore.HttpTo.HWRequest(GitHubConfig.API_AccessToken, "POST", pars);
            hwr.Accept = "application/json";//application/xml
            string result = NetnrCore.HttpTo.Url(hwr);

            var outmo = LoginBase.ResultOutput<GitHub_AccessToken_ResultEntity>(result);

            return outmo;
        }

        /// <summary>
        /// 获取 用户信息
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public static GitHub_User_ResultEntity User(string access_token)
        {
            if (string.IsNullOrWhiteSpace(access_token))
            {
                return null;
            }

            var hwr = NetnrCore.HttpTo.HWRequest(GitHubConfig.API_User);
            hwr.Headers.Add("Authorization", $"token {access_token}");
            hwr.UserAgent = "Netnr.Login";
            string result = NetnrCore.HttpTo.Url(hwr);

            var outmo = LoginBase.ResultOutput<GitHub_User_ResultEntity>(result, new List<string> { "plan" });

            return outmo;
        }
    }
}