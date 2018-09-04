namespace RecycleAPI.Messaging
{
    public class OrderInsertResult : BaseResult
    {
        public string OrderNumber { get; set; }
        public string ItemId { get; set; }
        public string OrderStatus { get; set; }
    }
}