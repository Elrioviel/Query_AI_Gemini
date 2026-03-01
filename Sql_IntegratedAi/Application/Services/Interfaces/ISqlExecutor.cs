namespace Application.Services.Interfaces;

/// <summary>
/// Определяет контракт для выполнения SQL-запроса
/// и форматирования результата в удобный для пользователя вид.
/// </summary>
public interface ISqlExecutor
{
    /// <summary>
    /// Выполняет SQL-запрос и возвращает отформатированный результат.
    /// </summary>
    /// <param name="sql">SQL-запрос для выполнения.</param>
    /// <returns>Строковое представление результата запроса.</returns>
    Task<string> ExecuteAndFormatAsync(string sql);
}
