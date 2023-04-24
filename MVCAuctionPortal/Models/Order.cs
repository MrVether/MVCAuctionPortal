using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuctionPortal.Models
{
    public class Order
    {
        [Key]
        [Required]
        public int OrderID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }

        public string FirstName { get; set; }
        public string Surname { get; set; }
        public decimal DiscountPercentage { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string LocalNumber { get; set; }
        public string ZipCode { get; set; }

        public DateTime? ShippingDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public string? PaymentMethod { get; set; }

        public string OrderStatus { get; set; } = "Pending";

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}