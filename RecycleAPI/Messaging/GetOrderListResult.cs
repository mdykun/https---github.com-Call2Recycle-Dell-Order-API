using System.Collections.Generic;

namespace RecycleAPI.Messaging
{
    public class GetOrderListResult : BaseResult
    {
        public int ItemsPerPage { get; set; }
        public int Page { get; set; }
        public int TotalItems { get; set; }

        public List<SimpleOrder> Items { get; set; }
        public GetOrderListResult() {  Items = new List<SimpleOrder>(); } 
    }
}
