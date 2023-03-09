namespace modulercrm.Entities.Moduler
{
    public class Customer
    {
        public string CUSTNAME { get; set; }
        public string CUSTDES { get; set; }
        public string WTAXNUM { get; set; }
        public string PHONE { get; set; }
        public string STATEA { get; set; }

        /// <summary>
        /// רחוב
        /// </summary>
        public string ADDRESS { get; set; }

        /// <summary>
        /// מס' בית
        /// </summary>
        public string ADDRESS2 { get; set; }

        /// <summary>
        /// טלפון נוסף 1
        /// </summary>
        public string SPEC2 { get; set; }
        


    }
}
