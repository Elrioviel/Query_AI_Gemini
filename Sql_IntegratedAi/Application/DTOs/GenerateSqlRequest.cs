namespace Application.DTOs;

/// <summary>
/// DTO для передачи пользовательского запроса на генерацию SQL.
/// </summary>
public class GenerateSqlRequest
{
    /// <summary>
    /// Текстовый запрос пользователя.
    /// </summary>
    public string Prompt { get; set; } = string.Empty;
}
