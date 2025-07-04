using Actividad2_BD_API.Model;

    namespace Actividad2_BD_API.Interface
{
    public interface ISalesOperation
    {
        Task PutSales(List<Sales> sales);
    }
}
