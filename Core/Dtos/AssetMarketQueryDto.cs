using Core.Dto;

namespace Core.Dtos
{
    public class AssetMarketQueryDto : IQueryObject
    {
        public string? Id { get; set; }
        public int? Limit { get; set; }
        public int? Offset { get; set; }
    }
}
