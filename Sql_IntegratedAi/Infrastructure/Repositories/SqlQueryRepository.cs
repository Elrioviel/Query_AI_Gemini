using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories;

/// <summary>
/// In-memory реализация репозитория истории SQL-запросов.
/// Используется для хранения сгенерированных запросов
/// без подключения к реальной базе данных.
/// </summary>
public class SqlQueryRepository : ISqlQueryRepository
{
    private readonly List<SqlQueryHistory> _storage = new();

    /// <summary>
    /// Ищет ранее сохранённый SQL-запрос по пользовательскому промпту.
    /// </summary>
    /// <param name="prompt">Текст запроса пользователя.</param>
    /// <returns>
    /// Объект <see cref="SqlQueryHistory"/> если найден,
    /// иначе null.
    /// </returns>
    public Task<SqlQueryHistory?> FindByPromptAsync(string prompt)
    {
        var result = _storage
            .FirstOrDefault(x => x.UserPrompt == prompt);

        return Task.FromResult(result);
    }

    /// <summary>
    /// Сохраняет историю сгенерированного SQL-запроса.
    /// </summary>
    /// <param name="history">Объект истории запроса.</param>
    public Task SaveAsync(SqlQueryHistory history)
    {
        _storage.Add(history);
        return Task.CompletedTask;
    }
}
