using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace ComparisonOfORMTools.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderController_Dapper : ControllerBase
    {
        private readonly IConfiguration _config;
        public SalesOrderController_Dapper(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]   
        public async Task<ActionResult<List<SalesOrderDetail>>> GetAllOrders()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var orders = await connection.QueryAsync<SalesOrderDetail>("select *  from Sales.SalesOrderDetail WHERE ProductID=870;");
            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;

            var response = new
            {
                ElapsedTimeMilliseconds = elapsedTime.TotalMilliseconds,

                Data = orders
            };

            return Ok(response);
           
        } 
    }
}
