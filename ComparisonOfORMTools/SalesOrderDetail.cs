namespace ComparisonOfORMTools
{
    public class SalesOrderDetail
    {
        public int SalesOrderID { get; set; }
        public int SalesOrderDetailID { get; set; }
        public string CarrierTrackingNumber { get; set; } = string.Empty;
        public int OrderQty { get; set; }
        public int ProductID { get; set; }
        public int SpecialOfferID { get; set; }
        public float UnitPrice { get; set; }
        public float UnitPriceDiscount { get; set; }
        public int LineTotal { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
       

    }
}
