using System.Text.RegularExpressions;

namespace Domain.Validators.Rules;

/// <summary>
/// Правило, разрешающее выполнение только SELECT-запросов.
/// </summary>
public class OnlySelectRule : ISqlRule
{
    public void Check(string sql)
    {
        if (!Regex.IsMatch(sql, @"^\s*select\b", RegexOptions.IgnoreCase))
        {
            throw new Exception("Разрешены только SELECT запросы");
        }
    }
}
