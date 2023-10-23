using Core.Dto;
using Core.Dtos;
using Core.Entities;
using Core.Response;

namespace Infrastructure.Services.Interfaces
{
    public interface ICoinCapApiService
    {
        Task<CryptoResponse<List<Asset>>?> GetAssetsAsync(AssetQueryDto? dto);
        Task<CryptoResponse<Asset>?> GetAssetByIdAsync(string id);
        Task<CryptoResponse<List<History>>?> GetAssetHistoriesAsync(string id, HistoryQueryDto? dto);
        Task<CryptoResponse<List<AssetMarket>>?> GetAssetMarketsAsync(string id, AssetMarketQueryDto? dto);
        Task<CryptoResponse<List<Rate>>?> GetRatesAsync();
        Task<CryptoResponse<Rate>?> GetRateByIdAsync(string id);
        Task<CryptoResponse<List<Exchange>>?> GetExchangesAsync();
        Task<CryptoResponse<Exchange>?> GetExchangeByIdAsync(string id);
        Task<CryptoResponse<List<Market>>?> GetMarketsAsync(MarketQueryDto? dto);
        Task<CryptoResponse<List<Candle>>?> GetCandlesAsync(CandleQueryDto? dto);
    }
}
