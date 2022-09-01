namespace RJR.Client
{
    public class Configuration
    {
        public static Configuration DefaultConfiguration { get; set; }

        /// <summary>
        /// Endpoint used to retrieve data about RJR buydown programs.
        /// </summary>
        public string BuydownEndpoint { get; set; }

        /// <summary>
        /// Endpoint used to obtain an authentication token, which can be used
        /// with the <see cref="BuydownEndpoint"/>.
        /// </summary>
        public string AuthenticationEndpoint { get; set; }
        
        public string CycleCode { get; set; }
        
        public string Id { get; set; }
        public string Password { get; set; }
        public string AccountNumber { get; set; }
        public string OperatingCompanyCode { get; set; }
        public string SubscriptionKey { get; set; }
        public string Scope { get; set; }
    }
}