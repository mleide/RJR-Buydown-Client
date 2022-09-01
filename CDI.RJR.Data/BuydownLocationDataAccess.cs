using System.Data.SqlClient;
using CDI.RJR.Data.Domain;

namespace CDI.RJR.Data
{
    class BuydownLocationDataAccess
    {
        readonly Database _database;

        public BuydownLocationDataAccess(Database database) => 
            _database = database;
        
        public int Insert(BuydownLocation location)
        {
            const string sql = @"
INSERT INTO dbo.BuydownLocation
(
    BuydownPeriodId,
    LocationNodeName,
    LocationNodeLevel,
    State,
    RCN,
    TDLinxNumber
)
OUTPUT Inserted.BuydownDiscountId 
VALUES
(
    @periodId,
    @locationName,
    @locationLevel,
    @state,
    @rcn,
    @tdLinxNumber
)";

            using var connection = _database.OpenConnection();
            using var cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@periodId", location.BuydownPeriodId);
            cmd.Parameters.AddWithValue("@locationName", location.LocationNodeName);
            cmd.Parameters.AddWithValue("@locationLevel", location.LocationNodeLevel);
            cmd.Parameters.AddWithValue("@state", location.State);
            cmd.Parameters.AddWithValue("@rcn", location.RCN);
            cmd.Parameters.AddWithValue("@tdLinxNumber", location.TDLinxNumber);
            return (int)cmd.ExecuteScalar();
        }
    }
}