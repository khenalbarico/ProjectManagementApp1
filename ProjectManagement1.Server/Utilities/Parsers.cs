namespace ProjectManagement1.Core.Utilities;

public static class Parsers
{
    public static TEnum ParseEnum<TEnum>(this string value) where TEnum : struct, Enum
    {
        var normalised = value.Trim().Replace(" ", "");
        if (Enum.TryParse<TEnum>(normalised, ignoreCase: true, out var result))
            return result;

        return default;
    }
}
