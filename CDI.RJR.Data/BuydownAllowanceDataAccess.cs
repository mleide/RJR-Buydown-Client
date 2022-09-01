using System.Data.SqlClient;
using CDI.RJR.Data.Domain;

namespace CDI.RJR.Data
{
    class BuydownAllowanceDataAccess
    {
        readonly Database _database;

        public BuydownAllowanceDataAccess(Database database) =>
            _database = database;
        
        public int Insert(BuydownAllowance allowance)
        {
            const string sql = @"
INSERT INTO dbo.BuydownAllowance
(
    Amount,
    CurrencyCode,
    StartDate,
    EndDate,
    ChangeFromPriorPeriod,
    MaxSuggestedRetailSellingPrice
)
OUTPUT Inserted.BuydownDiscountId 
VALUES
(
    @amount,
    @currencyCode,
    @startDate,
    @endDate,
    @changeFromPriorPeriod,
    @maxSuggestedRetailSellingPrice
)";

            using var connection = _database.OpenConnection();
            using var cmd = new SqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@amount", allowance.Amount);
            cmd.Parameters.AddWithValue("@currencyCode", allowance.CurrencyCode);
            cmd.Parameters.AddWithValue("@startDate", allowance.StartDate);
            cmd.Parameters.AddWithValue("@endDate", allowance.EndDate);
            cmd.Parameters.AddWithValue("@changeFromPriorPeriod", allowance.ChangeFromPriorPeriod);
            cmd.Parameters.AddWithValue("@maxSuggestedRetailSellingPrice", allowance.MaxSuggestRetailSellingPrice);

            return (int)cmd.ExecuteScalar();
        }
    }
}