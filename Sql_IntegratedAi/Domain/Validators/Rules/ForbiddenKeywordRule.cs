using System.Text.RegularExpressions;

namespace Domain.Validators.Rules;

/// <summary>
/// Правило, запрещающее использование опасных SQL-операторов.
/// </summary>
public class ForbiddenKeywordRule : ISqlRule
{
    public void Check(string sql)
    {
        var forbidden = new[]
        {
    "insert",
    "update",
    "delete",
    "drop",
    "alter",
    "truncate"
};

        foreach (var word in forbidden)
        {
            if (Regex.IsMatch(sql, $@"\b{word}\b", RegexOptions.IgnoreCase))
            {
                throw new Exception($"Использование запрещенного ключевого слова: {word}");
            }
        }
    }
}
