using Domain.Interfaces;using System.Text.RegularExpressions;

namespace Domain.Validators;

public class SqlCleaner : ISqlCleaner
{
    /// <summary>
    /// Очищает SQL-запрос от markdown, комментариев и лишних символов.
    /// </summary>
    public string Clean(string sql)
    {
        sql = sql.Replace("```sql", "")
                 .Replace("```", "")
                 .Trim();

        sql = Regex.Replace(sql, @"--.*?$", "", RegexOptions.Multiline);
        sql = Regex.Replace(sql, @"/\*.*?\*/", "", RegexOptions.Singleline);

        return sql.Trim().TrimEnd(';');
    }
}
