namespace ModulerCrm.Helpers
{
    /// <summary>
    /// Zoho settings
    /// </summary>
    public interface ImodulerSettings
    {
        /// <summary>
        /// Base Url
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// moduler token
        /// </summary>
        string Token { get; set; }
    }


    /// <summary>
    /// Set of sync settings
    /// </summary>
    public class modulerSettings : ImodulerSettings
    {

        #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

        public string BaseUrl { get; set; }
        public string Token { get; set; }

        #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    }
}
