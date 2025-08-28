﻿namespace ABCRetail.Models
{
    public class Customer : ITableEntity 
    {
        public string PartitionKey { get; set; } = "Customer";
        public string RowKey {  get; set; } = Guid.NewGuid().ToString();
        public DateTimeOffset? Timestamp { get; set; }

        public ETag ETag { get; set; }

        [Display(Name = "Customer ID")]
        public string CustomerId => RowKey;

        [Required]
        [Display(Name = "First Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Last Name")]
        public string Surname { get; set; } = string.Empty;

        [Required]
        [Display(Name = "UserName")]
        public string Username {  get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Shipping Address")]
        public string ShippingAddress { get; set; } = string.Empty;
    }
}
