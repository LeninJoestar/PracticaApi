using Actividad2_BD_API.Interface;
using Actividad2_BD_API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Actividad2_BD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesRepository _salesRepository;

        public SalesController(ISalesRepository salesRepository)
        {
            _salesRepository = salesRepository;
        }

        //Este es para el GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sales>>> GetSales()
        {
            var sales = await _salesRepository.GetSalesAsync();
            return Ok(sales);
        }

        //Este es para el POST
        [HttpPost]
        public async Task<ActionResult<Sales>> AddSale(Sales sales)
        {
            var createdCustomer = await _salesRepository.AddSalesAsync(sales);
            return CreatedAtAction(nameof(GetSales), new { customer = sales.CustomerID }, sales);
        }

        //Este es para el DELETE
        [HttpDelete("{customerId}")]
        public async Task<ActionResult> DeleteSale(int customerId)
        {
            var result = await _salesRepository.DeleteSalesAsync(customerId);

            if (!result)
            {
                return NotFound();
            }

            return NoContent(); 
        }

        //Este es para el PUT
        [HttpPut("{customerId}")]
        public async Task<IActionResult> UpdateSales(int CustomerId, Sales sales)
        {
            if (CustomerId != sales.CustomerID)
            {
                return BadRequest("El ID del cliente no coincide con el objeto enviado.");
            }

            var result = await _salesRepository.UpdateSalesAsync(sales);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
