namespace ABCRetail.Models
{
    public class Order : ITableEntity
    {
        public string PartitionKey { get; set; } = "Order";

        public string RowKey { get; set; } = Guid.NewGuid().ToString();
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        [Display(Name = "Order ID")]
        public string OrderId => RowKey;

        [Required (ErrorMessage = "customer Id is requred")]
        [Display(Name = "Customer")]
        public string CustomerId { get; set; } = string.Empty;

        [Display(Name = "Username")]
        public string Username {  get; set; } = string.Empty;

        [Required (ErrorMessage = "Product Id is required")]
        [Display(Name = "Product")]
        public string ProductId {  get; set; } = string.Empty;

        [Display(Name = "Prodcut Name")]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.UtcNow.Date;

        [Required]
        [Display(Name = "Quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        [Display(Name = "Unti price")]
        [DataType(DataType.Currency)]
        public double UnitPrice { get; set; }

        [Display(Name = "Total Price")]
        [DataType (DataType.Currency)]
        public double TotalPrice { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string Status { get; set; } = "Submited";
    }

    public enum OrderStatus
    {
        Submitted,
        Processing,
        Completed,
        Cancelled 
    }
}
