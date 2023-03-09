namespace ModulerCrm.Helpers
{
    /// <summary>
    /// Set of sync settings
    /// </summary>
    public interface IPaymentsSettings
    {
        /// <summary>
        /// Shopify Currency Symbol
        /// </summary>
        public string ModulerCode { get; set; }

        /// <summary>
        /// Shopify Currency Symbol
        /// </summary>
        public string PriorityCode { get; set; }

        /// <summary>
        /// Igonre from payment
        /// </summary>
        public bool Ignore { get; set; }


    }

    /// <summary>
    /// Set of sync settings
    /// </summary>
    public class PaymentsSettings : IPaymentsSettings
    {
        /// <summary>
        /// Shopify Currency Symbol
        /// </summary>
        public string ModulerCode { get; set; }

        /// <summary>
        /// Shopify Currency Symbol
        /// </summary>
        public string PriorityCode { get; set; }


        /// <summary>
        /// Igonre from payment
        /// </summary>
        public bool Ignore { get; set; }


    }
}
