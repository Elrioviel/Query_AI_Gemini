using Domain.Entities;

namespace Domain.Interfaces;

/// <summary>
/// Определяет контракт для хранения истории
/// сгенерированных SQL-запросов.
/// </summary>
public interface ISqlQueryRepository
{
    /// <summary>
    /// Находит сохранённый SQL по пользовательскому запросу.
    /// </summary>
    /// <param name="prompt">Текст запроса пользователя.</param>
    /// <returns>История запроса или null, если не найдено.</returns>
    Task<SqlQueryHistory?> FindByPromptAsync(string prompt);

    /// <summary>
    /// Сохраняет историю сгенерированного SQL-запроса.
    /// </summary>
    /// <param name="history">Объект истории запроса.</param>
    Task SaveAsync(SqlQueryHistory history);
}
