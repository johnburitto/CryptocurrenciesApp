using Core.Dto;

namespace Core.Dtos
{
    public class CandleQueryDto : IQueryObject
    {
        public string? Exchange { get; set; }
        public string? Interval { get; set; }
        public string? BaseId { get; set; }
        public string? QuoteId { get; set; }
        public long? Start { get; set; }
        public long? End { get; set; }
    }
}
