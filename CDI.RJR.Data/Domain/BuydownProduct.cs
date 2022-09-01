namespace CDI.RJR.Data.Domain
{
    public class BuydownProduct
    {
        public int Id { get; set; }
        public int BuydownPeriodId { get; set; }
        public int ProductId { get; set; }
        public string SKUGUID { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string SKUName { get; set; }
        public string VendorBrand { get; set; }
        public string VendorUPC { get; set; }
        public string VendorUOM { get; set; }
        public float ConversionFactor { get; set; }
        public bool IsPromotionalUPC { get; set; }
    }
}