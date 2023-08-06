using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComparisonOfORMTools.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderController_EF : ControllerBase
    {

        private readonly AdventureWorks2022Context _context;

        public SalesOrderController_EF(AdventureWorks2022Context context)
        {
            _context = context;
        }


        [HttpGet]

        public async Task<IActionResult> getOrderSales()
        {
            var filteredSales = await _context.SalesOrderDetail
                           .Where(s => s.ProductId == 870)
                           .ToListAsync();

            return Ok(filteredSales);
        }
    }
}
