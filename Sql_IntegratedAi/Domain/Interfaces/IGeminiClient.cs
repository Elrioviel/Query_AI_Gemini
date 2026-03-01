namespace Domain.Interfaces;

/// <summary>
/// Определяет контракт клиента для взаимодействия
/// с AI-сервисом генерации SQL-запросов.
/// </summary>
public interface IGeminiClient
{
    /// <summary>
    /// Отправляет пользовательский запрос и схему БД
    /// в AI-сервис и получает сгенерированный SQL.
    /// </summary>
    /// <param name="prompt">Пользовательский текст запроса.</param>
    /// <param name="schema">Описание схемы базы данных.</param>
    /// <returns>Сгенерированный SQL-запрос.</returns>
    Task<string> GenerateSqlAsync(string prompt, string schema);
}
