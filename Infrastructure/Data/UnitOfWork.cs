using Infrastructure.HttpInfrastructure;
using Infrastructure.Services.Impls;
using Infrastructure.Services.Interfaces;

namespace Infrastructure.Data
{
    public class UnitOfWork
    {
        public ICoinCapApiService CoinCapApiService { get; private set; }
    
        public UnitOfWork() 
        {
            CoinCapApiService = new CoinCapApiService(RequestClient<ICoinCapApiService>.Client);
        }
    }
}
