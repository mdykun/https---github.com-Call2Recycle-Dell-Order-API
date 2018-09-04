using RecycleAPI.Models;

namespace RecycleAPI.Messaging
{
    public class OrderRequest
    {
        public string VendorKey { get; set; }
        public Order Order { get; set; }
    }
}