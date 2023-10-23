using Infrastructure.Utils;

namespace Infrastructure.HttpInfrastructure
{
    public static class RequestClient<T> where T : class
    {
        private static readonly Dictionary<string, HttpClient> _clients = new Dictionary<string, HttpClient>();
        public static HttpClient Client => GetClient();

        private static HttpClient GetClient()
        {
            if (_clients.TryGetValue(typeof(T).Name, out var existingContext))
            {
                return existingContext;
            }
            else
            {
                var client = new HttpClient();

                client.BaseAddress = new Uri(ConfigurationReader.ReadSection<string>(typeof(T).Name));
                _clients.Add(nameof(T), client);

                return client;
            }
        }
    }
}
