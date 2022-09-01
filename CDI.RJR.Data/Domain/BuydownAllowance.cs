using System;

namespace CDI.RJR.Data.Domain
{
    public class BuydownAllowance
    {
        public int Id { get; set; }
        public int BuydownDiscountId { get; set; }
        public float Amount { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float ChangeFromPriorPeriod { get; set; }
        public float MaxSuggestRetailSellingPrice { get; set; }
    }
}