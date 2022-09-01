using System.Data.SqlClient;
using CDI.RJR.Data.Domain;

namespace CDI.RJR.Data
{
    class BuydownProgramDataAccess
    {
        readonly Database _database;

        public BuydownProgramDataAccess(Database database) =>
            _database = database;

        public int Insert(BuydownProgram program)
        {
            const string sql = @"
INSERT INTO dbo.BuydownProgram
(
    BuydownProgramId,
    Vendor,
    Name,
    Description,
    ProgramOption,
    MentholFlag,
    NationalFlag,
)
OUTPUT Inserted.BuydownDiscountId 
VALUES
(
    @buydownProgramId
    @vendor
    @name
    @description
    @programOption
    @mentholFlag
    @nationalFlag
)";

            using var conn = _database.OpenConnection();
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@buydownProgramId", program.Id);
            cmd.Parameters.AddWithValue("@vendor", program.Vendor);
            cmd.Parameters.AddWithValue("@name", program.Name);
            cmd.Parameters.AddWithValue("@description", program.Description);
            cmd.Parameters.AddWithValue("@programOption", program.ProgramOption);
            cmd.Parameters.AddWithValue("@mentholFlag", program.IsMenthol);
            cmd.Parameters.AddWithValue("@nationalFlag", program.IsNational);

            return (int)cmd.ExecuteScalar();
        }
    }
}