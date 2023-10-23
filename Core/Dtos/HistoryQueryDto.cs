using Core.Dto;

namespace Core.Dtos
{
    public class HistoryQueryDto : IQueryObject
    {
        public string? Id { get; set; }
        public string? Interval { get; set; }
    }
}
