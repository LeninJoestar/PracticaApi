using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Actividad2_BD_API.Interface;

namespace Actividad2_BD_API.Data
{
    public class SalesSPRepository : ISalesSPRepository
    {
        private readonly AppDbContext _context;

        public SalesSPRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task PutSalesBySpAsync(DataTable sales)
        {
            var cnx = _context.Database.GetDbConnection();
            await using (cnx)
            {
                if (cnx.State != ConnectionState.Open)
                    await cnx.OpenAsync();

                using var conmmand = cnx.CreateCommand();
                conmmand.CommandText = "dbo.usp_oe_PutCustomerTb";
                conmmand.CommandType = CommandType.StoredProcedure;
                var salesParam = new SqlParameter("@CustomerTable", SqlDbType.Structured)
                {
                    Value = sales,
                    TypeName = "dbo.CustomerTbIntro"
                };
                conmmand.Parameters.Add(salesParam);
                await conmmand.ExecuteNonQueryAsync();
            }
        }
    }
}
