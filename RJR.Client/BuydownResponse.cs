using System.Collections.Generic;
using RJR.Core;

namespace RJR.Client
{
    public class BuydownResponse
    {
        public List<Outlet> Outlets { get; set; } = new List<Outlet>();
        public List<Product> Products { get; set; } = new List<Product>();
        public List<DiscountRate> DiscountRates { get; set; } = new List<DiscountRate>();
    }
}