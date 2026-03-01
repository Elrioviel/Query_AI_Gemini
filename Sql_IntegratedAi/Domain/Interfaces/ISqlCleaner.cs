namespace Domain.Interfaces;

/// <summary>
/// Определяет контракт для очистки SQL-запросов
/// от лишнего форматирования и комментариев.
/// </summary>
public interface ISqlCleaner
{
    /// <summary>
    /// Очищает SQL-запрос от markdown, комментариев и лишних символов.
    /// </summary>
    /// <param name="sql">Исходный SQL-запрос.</param>
    /// <returns>Очищенный SQL-запрос.</returns>
    string Clean(string sql);
}
