namespace SAIS.Extensions;
public static class DateTimeExtensions
{
    public static string BeutifyDate(this DateTime dateTime)
    {
        return dateTime.ToString("dd MMMM yyyy hh:mm tt");
    }
}
