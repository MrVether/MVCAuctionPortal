using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AuctionPortal.Models;

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

        public string ShippingAddress { get; set; }

        public DateTime? ShippingDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public string PaymentMethod { get; set; }

        public string OrderStatus { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}