using System.Collections.Generic;
using System.Data.SqlClient;
using CDI.RJR.Data.Domain;

namespace CDI.RJR.Data
{
    class BuydownDiscountDataAccess
    {
        readonly Database _database;

        public BuydownDiscountDataAccess(Database database) =>
            _database = database;

        public int Insert(BuydownDiscount discount)
        {
            const string sql = @"
INSERT INTO dbo.BuydownDiscount
(
    BuydownPeriodId,
    BuydownProgramId,
    DealTypeId,
    Name,
    Description,
    AllowanceType,
    Basis,
    TotalBuydownAmt,
    EligibleUOM,
    ProgramFunds,
    QualifyingPrice,
    NonPromotedEligiblePrice,
    MSRP,
    MinQty,
    MaxQty,
    QtyIncrements,
    MaxDailyTransactionsPerLoyalty,
    MaxAllowancePerTransaction,
    ManufacturerFundedAmt
)
OUTPUT Inserted.BuydownDiscountId 
VALUES
(
    @buydownPeriodId,
    @buydownProgramId,
    @dealTypeId,
    @name,
    @description,
    @allowanceType,
    @basis,
    @totalBuydownAmt,
    @eligibleUOM,
    @programFunds,
    @qualifyingPrice,
    @nonPromotedEligiblePrice,
    @mSRP,
    @minQty,
    @maxQty,
    @qtyIncrements,
    @maxDailyTransactionsPerLoyalty,
    @maxAllowancePerTransaction,
    @manufacturerFundedAmt
)";

            var connection = _database.OpenConnection();
            var cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@buydownPeriodId", discount.BuydownPeriodId);
            cmd.Parameters.AddWithValue("@buydownProgramId", discount.BuydownProgramId);
            cmd.Parameters.AddWithValue("@dealTypeId", discount.DealTypeId);
            cmd.Parameters.AddWithValue("@name", discount.Name);
            cmd.Parameters.AddWithValue("@description", discount.Description);
            cmd.Parameters.AddWithValue("@allowanceType", discount.AllowanceType);
            cmd.Parameters.AddWithValue("@basis", discount.Basis);
            cmd.Parameters.AddWithValue("@totalBuydownAmt", discount.TotalBuydownAmount);
            cmd.Parameters.AddWithValue("@eligibleUOM", discount.EligibleUnitsOfMeasure);
            cmd.Parameters.AddWithValue("@programFunds", discount.ProgramFunds);
            cmd.Parameters.AddWithValue("@qualifyingPrice", discount.QualifyingPrice);
            cmd.Parameters.AddWithValue("@nonPromotedEligiblePrice", discount.NonPromotedEligiblePrice);
            cmd.Parameters.AddWithValue("@mSRP", discount.MSRP);
            cmd.Parameters.AddWithValue("@minQty", discount.MinQuantity);
            cmd.Parameters.AddWithValue("@maxQty", discount.MaxQuantity);
            cmd.Parameters.AddWithValue("@qtyIncrements", discount.QuantityIncrements);
            cmd.Parameters.AddWithValue("@maxDailyTransactionsPerLoyalty", discount.MaxDailyTransactionPerLoyalty);
            cmd.Parameters.AddWithValue("@maxAllowancePerTransaction", discount.MaxAllowancePerTransaction);
            cmd.Parameters.AddWithValue("@manufacturerFundedAmt", discount.ManufacturerFundedAmount);

            return (int)cmd.ExecuteScalar();
        }

        void UpdateDiscountLocations(int discountId, IEnumerable<int> locationIds)
        {
            const string sql = @"
INSERT INTO dbo.BuydownDiscountLocation
(
    BuydownDiscountId,
    BuydownLocationId
)
OUTPUT Inserted.BuydownDiscountId 
VALUES
(
    @discountId,
    @locationId
)";
            using var connection = _database.OpenConnection();

            foreach (var loc in locationIds)
            {
                using var cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@discountId", discountId);
                cmd.Parameters.AddWithValue("@locationId", loc);
                return (int)cmd.ExecuteScalar();
            }
        }

        void UpdateDiscountProducts(int discountId, IEnumerable<int> productIds)
        {
            const string sql = @"
INSERT INTO dbo.BuydownDiscountProduct
(
    BuydownDiscountId,
    BuydownProductId
)
OUTPUT Inserted.BuydownDiscountId 
VALUES
(
    @discountId,
    @productId
)";
            using var connection = _database.OpenConnection();

            foreach (var product in productIds)
            {
                using var cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@discountId", discountId);
                cmd.Parameters.AddWithValue("@productId", product);
                return (int)cmd.ExecuteScalar();
            }
        }
    }
}