namespace Core.Response
{
    public class CryptoResponse<T> where T : class
    {
        public T? Data { get; set; }
        public long TimeStamp { get; set; }
    }
}
