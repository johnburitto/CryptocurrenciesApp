using Core.Dto;
using Core.Dtos;
using Core.Entities;
using Core.Extensions;
using Core.Response;
using Infrastructure.Extensions;
using Infrastructure.Services.Interfaces;

namespace Infrastructure.Services.Impls
{
    public class CoinCapApiService : ICoinCapApiService
    {
        private readonly HttpClient _client;

        public CoinCapApiService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<CryptoResponse<Asset>?> GetAssetByIdAsync(string id)
        {
            var response = await _client.GetAsync($"assets/{id}");
            var asset = await response.DeserializeObject<CryptoResponse<Asset>>();

            return asset;
        }

        public async Task<CryptoResponse<List<History>>?> GetAssetHistoriesAsync(string id, HistoryQueryDto? dto)
        {
            var response = await _client.GetAsync($"assets/{id}/history?{dto?.ToUrlQueryString()}");
            var assetHistories = await response.DeserializeObject<CryptoResponse<List<History>>>();

            return assetHistories;
        }

        public async Task<CryptoResponse<List<AssetMarket>>?> GetAssetMarketsAsync(string id, AssetMarketQueryDto? dto)
        {
            var response = await _client.GetAsync($"assets/{id}/markets?{dto?.ToUrlQueryString()}");
            var assetMarkets = await response.DeserializeObject<CryptoResponse<List<AssetMarket>>>();

            return assetMarkets;
        }

        public async Task<CryptoResponse<List<Asset>>?> GetAssetsAsync(AssetQueryDto? dto)
        {
            var response = await _client.GetAsync($"assets?{dto?.ToUrlQueryString()}");
            var assets = await response.DeserializeObject<CryptoResponse<List<Asset>>>();

            return assets;
        }

        public async Task<CryptoResponse<List<Candle>>?> GetCandlesAsync(CandleQueryDto? dto)
        {
            var response = await _client.GetAsync($"candles?{dto?.ToUrlQueryString()}");
            var candles = await response.DeserializeObject<CryptoResponse<List<Candle>>>();

            return candles;
        }

        public async Task<CryptoResponse<Exchange>?> GetExchangeByIdAsync(string id)
        {
            var response = await _client.GetAsync($"exchanges/{id}");
            var exchange = await response.DeserializeObject<CryptoResponse<Exchange>>();

            return exchange;
        }

        public async Task<CryptoResponse<List<Exchange>>?> GetExchangesAsync()
        {
            var response = await _client.GetAsync($"exchanges");
            var exchanges = await response.DeserializeObject<CryptoResponse<List<Exchange>>>();

            return exchanges;
        }

        public async Task<CryptoResponse<List<Market>>?> GetMarketsAsync(MarketQueryDto? dto)
        {
            var response = await _client.GetAsync($"markets?{dto?.ToUrlQueryString()}");
            var markets = await response.DeserializeObject<CryptoResponse<List<Market>>>();

            return markets;
        }

        public async Task<CryptoResponse<Rate>?> GetRateByIdAsync(string id)
        {
            var response = await _client.GetAsync($"rates/{id}");
            var rate = await response.DeserializeObject<CryptoResponse<Rate>>();

            return rate;
        }

        public async Task<CryptoResponse<List<Rate>>?> GetRatesAsync()
        {
            var response = await _client.GetAsync($"rates");
            var rates = await response.DeserializeObject<CryptoResponse<List<Rate>>>();

            return rates;
        }
    }
}
