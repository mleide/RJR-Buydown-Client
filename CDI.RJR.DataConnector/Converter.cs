using System;
using System.Collections.Generic;
using CDI.RJR.Data.Domain;
using RJR.Core;

namespace CDI.RJR.DataConnector
{
    public class Converter
    {
        public Func<Product, IEnumerable<BuydownProduct>> ConvertProduct { get; set; }
        public Func<Outlet, BuydownLocation> ConvertLocation { get; set; }
        public Func<DiscountRate, BuydownDiscount> ConvertDiscount { get; set; }
    }
}