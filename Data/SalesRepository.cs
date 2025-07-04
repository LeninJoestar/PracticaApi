using Actividad2_BD_API.Interface;
using Actividad2_BD_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Actividad2_BD_API.Data
{
    public class SalesRepository : ISalesRepository
    {
        private readonly AppDbContext _context;

        public SalesRepository(AppDbContext context)
        {
            _context = context;
        }

        //public async Task<Sales> GetSalesByIdAsync(int id) => await _context.Sales.FindAsyc(id);

        public async Task<IEnumerable<Sales>> GetSalesAsync() => await _context.Sales.Take(100).ToListAsync();

        public async Task<Sales> AddSalesAsync(Sales sales)
        {
            _context.Sales.Add(sales);
            await _context.SaveChangesAsync();
            return sales;
        }

        public async Task<bool> DeleteSalesAsync(int id)
        {
            var customer = await _context.Sales.FindAsync(id);
            if (customer == null)
            {
                return false;
            }

            _context.Sales.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateSalesAsync(Sales sales)
        {
            _context.Entry(sales).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesExist(sales.CustomerID))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool SalesExist(int id)
        {
            return _context.Sales.Any(e => e.CustomerID == id);
        }
    }
}