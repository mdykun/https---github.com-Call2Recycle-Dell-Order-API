using System.Collections.Generic;

namespace RecycleAPI.Messaging
{
    public class InsertOrderResult : BaseResult 
    {
    
        public List<OrderInsertResult> Results { get; internal set; }
    }
}