using Domain.Validators.Rules;

namespace Domain.Validators;

/// <summary>
/// Выполняет проверку SQL-запроса на основе набора правил.
/// </summary>
public class SqlValidator
{
    private readonly IEnumerable<ISqlRule> _rules;

    public SqlValidator(IEnumerable<ISqlRule> rules)
    {
        _rules = rules;
    }

    /// <summary>
    /// Проверяет SQL-запрос на соответствие установленным правилам.
    /// </summary>
    /// <param name="sql">SQL-запрос для проверки.</param>
    public void Validate(string sql)
    {
        if (string.IsNullOrWhiteSpace(sql))
            throw new Exception("SQL is empty");

        foreach (var rule in _rules)
            rule.Check(sql);
    }
}
