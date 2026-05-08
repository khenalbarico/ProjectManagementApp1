using ProjectManagement1.Models.Constants;

namespace ProjectManagement1.Core.Utilities;

public static class RandomPasswordGenerator
{
    static readonly Random _random = new();

    public static string GeneratePassword()
    {
        const int length = 10;

        return new string(
            [.. Enumerable.Range(0, length).Select(
             _ => CharsSet.Chars[_random.Next(
                  CharsSet.Chars.Length)])]
        );
    }
}