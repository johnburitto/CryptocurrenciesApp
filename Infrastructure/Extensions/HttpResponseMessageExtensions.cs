using Newtonsoft.Json;

namespace Infrastructure.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<T?> DeserializeObject<T>(this HttpResponseMessage response)
        {
            return response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync()) 
                : throw new Exception("Internal error has occurred");
        }
    }
}
