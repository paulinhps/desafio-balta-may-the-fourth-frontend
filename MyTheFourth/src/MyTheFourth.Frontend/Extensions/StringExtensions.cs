namespace MyTheFourth.Frontend.Extensions;

public static class StringExtensions
{
    public static DateTime DateToPtBR(this string dateString) => DateTime.ParseExact(dateString, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
}