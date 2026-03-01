namespace Domain.Validators.Rules;

/// <summary>
/// Определяет правило валидации SQL-запроса.
/// </summary>
public interface ISqlRule
{
    /// <summary>
    /// Проверяет SQL-запрос на соответствие правилу.
    /// </summary>
    /// <param name="sql">SQL-запрос для проверки.</param>
    void Check(string sql);
}
