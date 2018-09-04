using System.ComponentModel.DataAnnotations;

namespace RecycleAPI.Models
{
    public class OrderStatusItem
    {
        [MaxLength(36)]
        public string ItemId { get; set; }

        [MaxLength(64)]
        public string OrderStatus { get; set; }

        [MaxLength(64)]
        public string OrderTransactionNumber { get; set; }

        [MaxLength(64)]
        public string ReturnTransactionNumber { get; set; }
        public string ExceptionReason { get; set; }
    }
}