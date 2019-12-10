namespace Netnr.Login
{
    /// <summary>
    /// 淘宝（天猫）登录 
    /// </summary>
    public class TaoBao
    {
        /// <summary>
        /// Step1：请求用户授权Token
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string AuthorizeHref(TaoBao_Authorize_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            return string.Concat(new string[] {
                TaoBaoConfig.API_Authorize,
                "?response_type=",
                entity.response_type,
                "&client_id=",
                entity.client_id,
                "&redirect_uri=",
                entity.redirect_uri.ToEncode(),
                "&state=",
                entity.state,
                "&view=",
                entity.view});
        }

        /// <summary>
        /// Step2：获取授权过的Access Token
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static TaoBao_AccessToken_ResultEntity AccessToken(TaoBao_AccessToken_RequestEntity entity)
        {
            if (!LoginBase.IsValid(entity))
            {
                return null;
            }

            string pars = LoginBase.EntityToPars(entity);
            string result = Core.HttpTo.Post(TaoBaoConfig.API_AccessToken, pars);
            var outmo = LoginBase.ResultOutput<TaoBao_AccessToken_ResultEntity>(result);

            return outmo;
        }
    }
}