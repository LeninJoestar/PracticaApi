using System.Data;

namespace Actividad2_BD_API.Interface
{
    public interface ISalesSPRepository
    {
        Task PutSalesBySpAsync(DataTable sales);
    }
}
