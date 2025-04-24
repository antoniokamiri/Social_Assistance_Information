namespace SAIS.Extensions;
public static class ValueExtensions
{
    public static int? ToNullableInterger(this string value)
    {
        bool isSuccess = int.TryParse(value, out int result);
        if (isSuccess) { return result; }
        return null;
    }
}
