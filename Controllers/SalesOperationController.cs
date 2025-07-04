using Microsoft.AspNetCore.Mvc;
using Actividad2_BD_API.Model;
using Actividad2_BD_API.Interface;

namespace Actividad2_BD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SalesBulkController : Controller
    {
        private readonly ISalesOperation _salesOperation;

        public SalesBulkController(ISalesOperation salesOperation)
        {
            _salesOperation = salesOperation;
        }

        [HttpPut]
        public async Task<IActionResult> PutSales([FromBody] List<Sales> sales)
        {
            if (sales == null || sales.Count == 0)
            {
                return BadRequest("Customer list is empty.");
            }
                await _salesOperation.PutSales(sales);
                return NoContent();
        }
    }
}
