using System.Data.SqlClient;
using CDI.RJR.Data.Domain;

namespace CDI.RJR.Data
{
    class BuydownProductDataAccess
    {
        readonly Database _database;

        public BuydownProductDataAccess(Database database) =>
            _database = database;

        public int Insert(BuydownProduct product)
        {
            const string sql = @"
INSERT INTO dbo.BuyDownProduct
(
    BuyDownProductId,
    BuyDownPeriodId,
    ProductId,
    SKUGUID,
    CompanyCode,
    CompanyName,
    SKUName,
    VendorBrand,
    VendorUPC,
    VendorUOM,
    ConversionFactor,
    IsPromotionalUPC
)
OUTPUT Inserted.BuydownDiscountId 
VALUES
(
    @buyDownProductId,
    @buyDownPeriodId,
    @productId,
    @SKUGUID,
    @companyCode,
    @companyName,
    @sKUName,
    @vendorBrand,
    @vendorUPC,
    @vendorUOM,
    @conversionFactor,
    @isPromotionalUPC
)";

            using var conn = _database.OpenConnection();
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@buyDownProductId", product.Id);
            cmd.Parameters.AddWithValue("@buyDownPeriodId", product.BuydownPeriodId);
            cmd.Parameters.AddWithValue("@productId", product.ProductId);
            cmd.Parameters.AddWithValue("@sKUGUID", product.SKUGUID);
            cmd.Parameters.AddWithValue("@companyCode", product.CompanyCode);
            cmd.Parameters.AddWithValue("@companyName", product.CompanyName);
            cmd.Parameters.AddWithValue("@sKUName", product.SKUName);
            cmd.Parameters.AddWithValue("@vendorBrand", product.VendorBrand);
            cmd.Parameters.AddWithValue("@vendorUPC", product.VendorUPC);
            cmd.Parameters.AddWithValue("@vendorUOM", product.VendorUOM);
            cmd.Parameters.AddWithValue("@conversionFactor", product.ConversionFactor);
            cmd.Parameters.AddWithValue("@isPromotionalUPC", product.IsPromotionalUPC);

            return (int)cmd.ExecuteScalar();
        }
    }
}