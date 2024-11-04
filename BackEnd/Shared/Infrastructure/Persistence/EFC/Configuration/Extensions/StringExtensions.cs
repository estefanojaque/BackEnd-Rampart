using Humanizer;

namespace catch_up_platform.Shared.Infrastructure.Persistence;

public static class StringExtensions
{
    public static string ToSnakeCase(this string str)
    {
        return new string(Convert(str.GetEnumerator()).ToArray());

        static IEnumerable<char> Convert(CharEnumerator e)
        {
            if (!e.MoveNext()) yield break;
            yield return char.ToLower(e.Current);

            while (e.MoveNext())
                if (char.IsUpper(e.Current))
                {
                    yield return '-';
                    yield return char.ToLower(e.Current);
                }
                else
                {
                    yield return e.Current;
                }
        }
     
    }

    public static string ToPlural(this string text)
    {
        return text.Pluralize(false);
    }
    
}
