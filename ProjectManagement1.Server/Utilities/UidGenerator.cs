namespace ProjectManagement1.Core.Utilities;

public static class UidGenerator
{
    static readonly Random _random = new();

    public static string Generate(this string prefix)
    {
        int num = _random.Next(10000, 100000); 

        return $"{prefix}-{num}";
    }
}