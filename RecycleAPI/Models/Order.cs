using System;
using System.ComponentModel.DataAnnotations;
using RecycleAPI.Repository;
using RecycleAPI.Services;

namespace RecycleAPI.Models
{
    public class Order : TableBase
    {
        public int OrderId { get; set; }

        [MaxLength(36)]
        public string ItemId { get; set; }

        [Required()]
        public string OrderNumber { get; set; }

        [Required()]
        public DateTime OrderDate { get; set; }

        [MaxLength(128)]
        public string AccountName { get; set; }

        [MaxLength(64)]
        [Required()]
        public string ContactLastName { get; set; }

        [MaxLength(64)]
        public string ContactFirstName { get; set; }

        [MaxLength(128)]
        public string ContactEmail { get; set; }

        [MaxLength(32)]
        public string ContactPhone { get; set; }

        [MaxLength(64)]
        [Required()]
        public string Address1 { get; set; }

        [MaxLength(64)]
        public string Address2 { get; set; }

        [MaxLength(64)]
        [Required()]
        public string City { get; set; }

        [MaxLength(64)]
        [Required()]
        [ValidState("Invalid State was provided")]
        public string State { get; set; }

        [MaxLength(24)]
        [Required()]
        public string PostalCode { get; set; }

        [MaxLength(64)]
        [Required()]
        public string Country { get; set; }

        [MaxLength(128)]
        public string Reference1 { get; set; }

        [MaxLength(128)]
        public string Reference2 { get; set; }

        [MaxLength(12)]
        [Required()]
        public string ProgramInfoId { get; set; }

        public Vendor Vendor { get; set; }

        public int NumberOfBatteries { get; set; }
        public int KitQuantity { get; set; }

        [Required()]
        public string OrderStatus { get; set; }
        public DateTime OrderStatusDate { get; set; }

        [MaxLength(64)]
        public string OrderTrackingNumber { get; set; }

        [MaxLength(64)]
        public string ReciptTrackingNumber { get; set; }

        public Order()
        {
            ItemId = Guid.NewGuid().ToString();
            Country = "USA";
            OrderStatus = OrderStatusValues.Pending;
        }
    }


}
