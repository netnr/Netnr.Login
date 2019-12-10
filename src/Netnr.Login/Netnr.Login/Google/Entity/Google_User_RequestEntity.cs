namespace Netnr.Login
{
    /// <summary>
    /// user
    /// </summary>
    public class Google_User_RequestEntity
    {
        /// <summary>
        /// access_token
        /// </summary>
        [Required]
        public string access_token { get; set; }
    }
}