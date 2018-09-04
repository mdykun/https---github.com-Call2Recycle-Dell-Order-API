namespace RecycleAPI.Messaging
{
    public class BaseResult
    {
        public bool Success { get; internal set; }
        public string Message { get; internal set; }
    }
}