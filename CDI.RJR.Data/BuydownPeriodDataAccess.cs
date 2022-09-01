using System.Data.SqlClient;
using CDI.RJR.Data.Domain;

namespace CDI.RJR.Data
{
    class BuydownPeriodDataAccess
    {
        readonly Database _database;

        public BuydownPeriodDataAccess(Database database) =>
            _database = database;

        public int Insert(BuydownPeriod period)
        {
            const string sql = @"
INSERT INTO dbo.BuydownPeriod
(
    Name,
    Description,
    StartDate,
    EndDate,
    CycleCode
)
OUTPUT Inserted.BuydownDiscountId 
VALUES
(
    @name,
    @description,
    @startDate,
    @endDate,
    @cycleCode    
)";
            using var conn = _database.OpenConnection();
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@name", period.Name);
            cmd.Parameters.AddWithValue("@description", period.Description);
            cmd.Parameters.AddWithValue("@startDate", period.StartDate);
            cmd.Parameters.AddWithValue("@endDate", period.EndDate);
            cmd.Parameters.AddWithValue("@cycleCode", period.CycleCode);

            return (int)cmd.ExecuteScalar();
        }
    }
}