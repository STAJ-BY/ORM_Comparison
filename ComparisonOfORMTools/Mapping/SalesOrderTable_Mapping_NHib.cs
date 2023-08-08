using ComparisonOfORMTools.Models;
using FluentNHibernate.Mapping;

namespace ComparisonOfORMTools.Mapping
{
    public class SalesOrderTable_Mapping_NHib: ClassMap<SalesOrder_NHib>
    {
        public SalesOrderTable_Mapping_NHib()
        {
            Table("Sales.SalesOrderDetail");
            Id(x =>  x.SalesOrderDetailID);
            Map(x => x.SalesOrderID);
            Map(x => x.CarrierTrackingNumber);
            Map(x => x.OrderQty);
            Map(x => x.ProductID);
            Map(x => x.SpecialOfferID)  ;
            Map(x => x.UnitPrice);
            Map(x => x.UnitPriceDiscount);
            Map(x => x.LineTotal);
            Map(x => x.rowguid);
            Map(x => x.ModifiedDate);
          

        }
    }
}
