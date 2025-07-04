using Actividad2_BD_API.Model;

namespace Actividad2_BD_API.Interface
{
    public interface ISalesRepository
    {
        Task<IEnumerable<Sales>> GetSalesAsync();

        Task<Sales> AddSalesAsync(Sales sales);

        Task<bool> DeleteSalesAsync(int customerId);

        Task<bool> UpdateSalesAsync(Sales sales);
    }
}
