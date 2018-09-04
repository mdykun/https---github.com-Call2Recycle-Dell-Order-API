using Microsoft.AspNetCore.Mvc;

namespace RecycleAPI.Models
{
    public class ActionResultWithPayload<T> : ActionResult
    {
        public T Payload { get; set; }
    }
}
