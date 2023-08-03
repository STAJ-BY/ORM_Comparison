using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ComparisonOfORMTools.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderController : ControllerBase
    {
        private readonly IConfiguration _config;
        public SalesOrderController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]   
        public async Task<ActionResult<List<SalesOrderDetail>>> GetAllOrders()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var orders = await connection.QueryAsync<SalesOrderDetail>("select *  from Sales.SalesOrderDetail WHERE ProductID=870;");
            return Ok(orders);
        } 
    }
}
