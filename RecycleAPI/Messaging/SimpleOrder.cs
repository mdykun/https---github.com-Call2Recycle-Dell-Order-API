using System;

namespace RecycleAPI.Messaging
{
    public class SimpleOrder
    {
        public int OrderId { get; set; }
        public string ItemId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string AccountName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Reference1 { get; set; }
        public string Reference2 { get; set; }
        public string ProgramInfoId { get; set; }
        public int NumberOfBatteries { get; set; }
        public int KitQuantity { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderStatusDate { get; set; }
        public string OrderTrackingNumber { get; set; }
        public string ReciptTrackingNumber { get; set; }
        public string VendorId { get; set; }
    }
}