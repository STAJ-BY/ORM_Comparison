using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var filteredSales = await _context.SalesOrderDetail
                           .Where(s => s.ProductId == 870)
                           .ToListAsync();

            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;

            // Create a response object that includes the data and the elapsed time
            var response = new
            {
                ElapsedTimeMilliseconds = elapsedTime.TotalMilliseconds,
                Data = filteredSales
                
            };

            return Ok(response);
        }
    }
}
