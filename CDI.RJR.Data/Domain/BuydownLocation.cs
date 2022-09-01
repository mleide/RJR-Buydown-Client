namespace CDI.RJR.Data.Domain
{
    public class BuydownLocation
    {
        public int Id { get; set; }
        public int BuydownPeriodId { get; set; }
        public string LocationNodeName { get; set; }
        public int LocationNodeLevel { get; set; }
        public string State { get; set; }
        public string RCN { get; set; }
        public string TDLinxNumber { get; set; }
    }
}
