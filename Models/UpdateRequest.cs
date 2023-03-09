namespace ModulerCrm.Models
{
    /// <summary>
    /// Update request from Priority
    /// </summary>
    public class UpdateRequest
    {
        /// <summary>
        /// Zoho order id
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// new order status
        /// </summary>
        public string Status { get; set; }
    }
}
