using System.Collections.Generic;

namespace CDI.RJR.Data.Domain
{
    public class BuydownDiscount
    {
        public int Id { get; set; }
        public List<int> BuydownLocationIds { get; set; } = new List<int>();
        public List<int> BuydownProductIds { get; set; } = new List<int>();

        public int BuydownPeriodId { get; set; }
        public int BuydownProgramId { get; set; }
        public int? DealTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AllowanceType { get; set; }
        public string Basis { get; set; }
        public float TotalBuydownAmount { get; set; }
        public string EligibleUnitsOfMeasure { get; set; }
        public float ProgramFunds { get; set; }
        public float QualifyingPrice { get; set; }
        public float NonPromotedEligiblePrice { get; set; }
        public float MSRP { get; set; }
        public int? MinQuantity { get; set; }
        public int? MaxQuantity { get; set; }
        public int? QuantityIncrements { get; set; }
        public int? MaxDailyTransactionPerLoyalty { get; set; }
        public float MaxAllowancePerTransaction { get; set; }
        public float? ManufacturerFundedAmount { get; set; }
    }
}