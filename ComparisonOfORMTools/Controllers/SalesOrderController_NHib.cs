using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using System.Diagnostics;

namespace ComparisonOfORMTools.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderController_NHib : ControllerBase
    {
        private static volatile ISessionFactory iSessionFactory;
        private static object syncRoot = new object();
        private readonly IConfiguration _configuration;

        public SalesOrderController_NHib(IConfiguration configuration)
        {
            _configuration = configuration;
            InitializeSessionFactory();
        }

        private void InitializeSessionFactory()
        {
            if (iSessionFactory == null)
            {
                lock (syncRoot)
                {
                    if (iSessionFactory == null)
                    {
                        iSessionFactory = BuildSessionFactory();
                    }
                }
            }
        }

        private ISessionFactory BuildSessionFactory()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
          

            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<SalesOrder_NHib>())
                .BuildSessionFactory();
        }

        [HttpGet]
        public async Task<ActionResult<object>> GetAllOrders()
        {
            using (var session = iSessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

              
                var orders = await session.QueryOver<SalesOrder_NHib>()
                    .Where(x => x.ProductID == 870)
                    .ListAsync();

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
}
