using System;
using System.Collections.Generic;

namespace RJR.Core
{
    public class DiscountRate
    {
        public List<string> ProductIds { get; set; } = new List<string>();
        public List<string> ProductNames { get; set; } = new List<string>();
        public List<Product> Products { get; set; } = new List<Product>();
        public List<string> OutletIds { get; set; } = new List<string>();
        public List<Outlet> Outlets { get; set; } = new List<Outlet>();

        public string ContractType { get; set; }
        public string DiscountType { get; set; }

        public string RetailDiscountRate { get; set; }
        public string DiscountGroup { get; set; }
        public string DiscountPeriodName { get; set; }
        public string DiscountPeriod { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string CurrencyCode { get; set; }
        public float DiscountAmount { get; set; }

        public float TotalPerUnitSingle { get; set; }
        public float TotalPerUnitMulti { get; set; }

        public bool ChangeFromPreviousMonth { get; set; }
    }
}