namespace DataAccessLayer.Models
{
    using System;

    public class ProductItemModel
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string MeasurementUnit { get; set; }
    }
}
