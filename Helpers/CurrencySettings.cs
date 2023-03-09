namespace ModulerCrm.Helpers
{
    /// <summary>
    /// Set of sync settings
    /// </summary>
    public interface ICurrencySettings
    {
        /// <summary>
        /// Shopify Currency Symbol
        /// </summary>
        public string ModulerSymbol { get; set; }

        /// <summary>
        /// Shopify Currency Symbol
        /// </summary>
        public string PrioritySymbol { get; set; }

        /// <summary>
        /// vat free currency
        /// </summary>
        public bool VatFree { get; set; }

    }

    /// <summary>
    /// Set of sync settings
    /// </summary>
    public class CurrencySettings : ICurrencySettings
    {
        /// <summary>
        /// Shopify Currency Symbol
        /// </summary>
        public string ModulerSymbol { get; set; }

        /// <summary>
        /// Shopify Currency Symbol
        /// </summary>
        public string PrioritySymbol { get; set; }


        /// <summary>
        /// vat free currency
        /// </summary>
        public bool VatFree { get; set; }

    }
}
