namespace RJR.Core
{
    public class Outlet
    {
        public int OwnershipId { get; set; }
        public int OutletId { get; set; }
        public string OutletName { get; set; }
        public string ContractType { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string ZipCode { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
