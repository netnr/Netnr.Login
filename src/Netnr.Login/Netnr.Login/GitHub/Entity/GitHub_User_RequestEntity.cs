namespace Netnr.Login
{
    /// <summary>
    /// user
    /// </summary>
    public class GitHub_User_RequestEntity
    {
        /// <summary>
        /// access_token
        /// </summary>
        [Required]
        public string access_token { get; set; }

        /// <summary>
        /// github 申请的应用名称
        /// </summary>
        [Required]
        public string ApplicationName { get; set; } = GitHubConfig.ApplicationName;
    }
}