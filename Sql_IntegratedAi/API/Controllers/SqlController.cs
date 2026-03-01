using Application.DTOs;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Контроллер для генерации SQL-запросов на основе пользовательского запроса.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class SqlController : ControllerBase
{
    private readonly ISqlGenerator _sqlService;

    /// <summary>
    /// Создает экземпляр контроллера SQL.
    /// </summary>
    /// <param name="sqlService">Сервис генерации SQL-запросов.</param>
    public SqlController(ISqlGenerator sqlService)
    {
        _sqlService = sqlService;
    }

    /// <summary>
    /// Генерирует SQL-запрос на основе текстового запроса пользователя.
    /// </summary>
    /// <param name="request">Объект с пользовательским промптом.</param>
    /// <returns>Сгенерированный SQL-запрос.</returns>
    [HttpPost("generate")]
    public async Task<IActionResult> Generate([FromBody] GenerateSqlRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Prompt))
            return BadRequest("Prompt cannot be empty");

        var sql = await _sqlService.GenerateAsync(request.Prompt);
        return Ok(new { sql });
    }
}
