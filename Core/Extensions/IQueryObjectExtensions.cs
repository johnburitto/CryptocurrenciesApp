using Core.Dto;
using System.Web;

namespace Core.Extensions
{
    public static class IQueryObjectExtensions
    {
        public static string ToUrlQueryString(this IQueryObject obj)
        {
            var properties = obj.GetType().GetProperties()
                .Where(_ => _.GetValue(obj, null) != null)
                .Select(_ => $"{_.Name.ToUrlParameter()}={HttpUtility.UrlEncode(_.GetValue(obj, null)?.ToString())}");

            return string.Join("&", properties.ToArray()); 
        }
    }
}
