using Infrastructure.HttpInfrastructure;
using Infrastructure.Services.Impls;
using Infrastructure.Services.Interfaces;

namespace Infrastructure.Data
{
    public class UnitOfWork
    {
        public ICoinCapApiService CoinCapApiService { get; private set; }
        private static UnitOfWork? _instance;
        private static object _lock = new object();

        public static UnitOfWork Instance => GetInstance();

        private UnitOfWork() 
        {
            CoinCapApiService = new CoinCapApiService(RequestClient<ICoinCapApiService>.Client);
        }
        private static UnitOfWork GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    _instance = new UnitOfWork();
                }
            }

            return _instance;
        }
    }
}
