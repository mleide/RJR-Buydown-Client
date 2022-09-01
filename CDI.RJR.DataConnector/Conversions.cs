using System.Collections.Generic;
using System.Linq;
using CDI.RJR.Data.Domain;
using RJR.Core;

namespace CDI.RJR.DataConnector
{
    public static class Conversions
    {
        public static List<BuydownProduct> ConvertProduct(Product product)
        {
            var results = new List<BuydownProduct>();

            foreach (var packing in product.Packings)
            {
                var bd = new BuydownProduct();
                bd.BuydownPeriodId = -1; // todo: map this property
                bd.ProductId = product.ItemNumber;
                bd.SKUGUID = string.Empty; // todo: map this property

                bd.CompanyCode = string.Empty; // todo: map this property
                bd.CompanyName = string.Empty; // todo: map this property
                bd.SKUName = product.ProductName;
                bd.VendorBrand = product.BrandGroup;

                bd.VendorUPC = packing.UPC; 
                bd.VendorUOM = packing.UOM;
                bd.ConversionFactor = 0; // todo: map this property
                bd.IsPromotionalUPC = false; // todo: map this property
                results.Add(bd);
            }

            return results;
        }

        public static BuydownLocation ConvertLocation(Outlet outlet)
        {
            var location = new BuydownLocation();

            location.BuydownPeriodId = -1; // todo: map this property
            location.LocationNodeName = outlet.OutletName;
            location.LocationNodeLevel = -1; // todo: map this property

            location.State = outlet.StateCode;
            location.RCN = outlet.OwnershipId.ToString(); // todo: validate this mapping
            location.TDLinxNumber = string.Empty; // todo: map this property

            return location;
        }

        public static BuydownDiscount ConvertDiscount(DiscountRate rate)
        {
            var discount = new BuydownDiscount();

            discount.BuydownLocationIds = rate.Outlets.Select(p => p.Id).ToList();
            discount.BuydownProductIds = rate.Products.Select(p => p.ItemNumber).ToList();

            discount.BuydownPeriodId = -1; // todo: map this property;
            discount.BuydownProgramId = -1; // todo: map this property;

            discount.DealTypeId = null;
            discount.Name = string.Empty; // todo: (^) map this property
            discount.Description = string.Empty; // todo: (^) map this property
            discount.Basis = string.Empty; // todo: map this property

            discount.TotalBuydownAmount = -1; // todo: map this property
            discount.EligibleUnitsOfMeasure = $"Mutli:${rate.TotalPerUnitMulti};Single:{rate.TotalPerUnitSingle}"; // todo: validate this property
            discount.ProgramFunds = -1; // todo: map this property

            discount.QualifyingPrice = -1; // todo: map this property
            discount.NonPromotedEligiblePrice = -1; // todo: map this property
            discount.MSRP = -1; // map this property

            discount.MinQuantity = -1; // todo: map this property
            discount.MaxQuantity = -1; // todo: map this property
            discount.QuantityIncrements = null; // todo: map this property

            discount.MaxDailyTransactionPerLoyalty = null; // todo: map this property
            discount.MaxAllowancePerTransaction = -1; // todo: map this property
            discount.ManufacturerFundedAmount = null; // todo: map this property

            return discount;
        }
    }
}