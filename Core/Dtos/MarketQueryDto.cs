using Core.Dto;

namespace Core.Dtos
{
    public class MarketQueryDto : IQueryObject
    {
        public string? ExchangeId { get; set; }
        public string? BaseSymbol { get; set; }
        public string? QuoteSymbol { get; set; }
        public string? BaseId { get; set; }
        public string? QuoteId { get; set; }
        public string? AssetSymbol { get; set; }
        public string? AssetId { get; set; }
        public int? Limit { get; set; }
        public int? Offset { get; set; }
    }
}
