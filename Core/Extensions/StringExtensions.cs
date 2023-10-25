namespace Core.Extensions
{
    public static class StringExtensions
    {
        public static string ToUrlParameter(this string value)
        {
            return char.ToLower(value[0]) + value.Substring(1);
        }
    }
}
