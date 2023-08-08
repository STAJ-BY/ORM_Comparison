namespace ComparisonOfORMTools.Models
{
    public class SalesOrder_NHib
    {
       
        public virtual int SalesOrderID { get; set; }
        public virtual int SalesOrderDetailID { get; set; }
       public virtual string CarrierTrackingNumber { get; protected internal set; }
        public virtual int OrderQty { get; set; }
        public virtual int ProductID { get; set; }
        public virtual int SpecialOfferID { get; set; }
        public virtual float UnitPrice { get; set; }
        public virtual float UnitPriceDiscount { get; set; }
        public virtual int LineTotal { get; protected internal set; }
        public virtual Guid rowguid { get; set; }
        public virtual DateTime ModifiedDate { get; set; }


    }
}
