using ComparisonOfORMTools.Models;
using FluentNHibernate.Mapping;

namespace ComparisonOfORMTools.Mapping
{
    public class SalesOrderTable_Mapping_NHib: ClassMap<Models.SalesOrder_NHib>
    {
        public SalesOrderTable_Mapping_NHib()
        {
            Id(x =>  x.SalesOrderDetailID);
            Map(x => x.SalesOrderID).Not.Nullable();
            Map(x => x.CarrierTrackingNumber).Not.Nullable();
            Map(x => x.OrderQty).Not.Nullable();
            Map(x => x.SalesOrderID).Not.Nullable();
            Map(x => x.ProductID).Not.Nullable();
            Map(x => x.SpecialOfferID).Not.Nullable();
            Map(x => x.UnitPrice).Not.Nullable();
            Map(x => x.UnitPriceDiscount).Not.Nullable();
            Map(x => x.LineTotal).Not.Nullable();
            Map(x => x.rowguid).Not.Nullable();
            Map(x => x.ModifiedDate).Not.Nullable();
            Table("SalesOrderDetail");

        }
    }
}
