namespace Api.Extensions
{
    public static class HourExtensions
    {
        public static string ToDisplayHour(this int hour)
        {
            if (hour > 12) return $"{hour - 12}pm";
            return $"{hour}am";
        }
    }
}