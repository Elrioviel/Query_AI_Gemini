namespace Infrastructure.Gemini;

/// <summary>
/// Настройки подключения к AI-сервису генерации SQL.
/// Используется для конфигурации через appsettings.json.
/// </summary>
public class GeminiOptions
{
    /// <summary>
    /// API-ключ для авторизации в сервисе.
    /// </summary>
    public string ApiKey { get; set; } = string.Empty;

    /// <summary>
    /// Базовый URL AI-сервиса.
    /// </summary>
    public string BaseUrl { get; set; } = string.Empty;

    /// <summary>
    /// Название используемой модели.
    /// </summary>
    public string Model { get; set; } = string.Empty;
}
