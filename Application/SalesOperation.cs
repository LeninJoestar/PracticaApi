using Actividad2_BD_API.Interface;
using Actividad2_BD_API.Model;
using System.Data;

namespace Actividad2_BD_API.Application
{
    public class SalesOperation : ISalesOperation
    {
        private readonly ISalesSPRepository _SalesSPRepository;

        public SalesOperation(ISalesSPRepository salesSPRepository)
        {
            _SalesSPRepository = salesSPRepository;
        }

        public async Task PutSales(List<Sales> sales)
        {
            var dtSales = await TransformDTSales(sales);
            await _SalesSPRepository.PutSalesBySpAsync(dtSales);
        }

        private Task <DataTable> TransformDTSales(List<Sales> sales)
        {
            var table = new DataTable();

            table.Columns.Add("CustomerID", typeof(int));
            table.Columns.Add("PersonID", typeof(int));
            table.Columns.Add("StoreID", typeof(int));
            table.Columns.Add("TerritoryID", typeof(int));
            table.Columns.Add("AccountNumber", typeof(string));
            table.Columns.Add("rowguid", typeof(Guid));
            table.Columns.Add("ModifiedDate", typeof(DateTime));

            foreach (var sale in sales)
            {
                table.Rows.Add(
                    sale.CustomerID,
                    sale.PersonID,
                    sale.StoreID,
                    sale.TerritoryID,
                    sale.AccountNumber,
                    sale.rowguide,
                    sale.ModifiedDate == default ? (object)DBNull.Value : sale.ModifiedDate
                );
            }

            return Task.FromResult(table);
        }
    }
}
