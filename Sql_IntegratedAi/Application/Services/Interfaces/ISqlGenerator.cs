namespace Application.Services.Interfaces;
/// <summary>
/// Определяет контракт для генерации SQL-запросов
/// на основе пользовательского текстового запроса.
/// </summary>
public interface ISqlGenerator
{
    /// <summary>
    /// Генерирует SQL-запрос на основе пользовательского текста.
    /// </summary>
    /// <param name="userPrompt">Текст запроса пользователя.</param>
    /// <returns>Сгенерированный SQL-запрос.</returns>
    Task<string> GenerateAsync(string userPrompt);
}