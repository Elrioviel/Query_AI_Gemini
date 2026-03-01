using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Validators;

namespace Application.Services;

/// <summary>
/// Сервис генерации SQL-запросов на основе пользовательского промпта.
/// Выполняет проверку, очистку и сохранение истории запросов.
/// </summary>
public class SqlGenerationService : ISqlGenerator
{
    private readonly IGeminiClient _gemini;
    private readonly ISqlQueryRepository _repository;
    private readonly SqlValidator _validator;
    private readonly IDatabaseSchemaProvider _schemaProvider;
    private readonly ISqlCleaner _cleaner;

    public SqlGenerationService(
        IGeminiClient gemini,
        ISqlQueryRepository repository,
        SqlValidator validator,
        IDatabaseSchemaProvider schemaProvider,
        ISqlCleaner cleaner)
    {
        _gemini = gemini;
        _repository = repository;
        _validator = validator;
        _schemaProvider = schemaProvider;
        _cleaner = cleaner;
    }

    /// <summary>
    /// Генерирует SQL-запрос на основе пользовательского текста.
    /// </summary>
    /// <param name="userPrompt">Текст запроса пользователя.</param>
    /// <returns>Сгенерированный и провалидированный SQL-запрос.</returns>
    public async Task<string> GenerateAsync(string userPrompt)
    {
        if (string.IsNullOrWhiteSpace(userPrompt))
            throw new ArgumentException("Prompt cannot be empty");

        // Проверяем, есть ли уже сохранённый запрос
        var existing = await _repository.FindByPromptAsync(userPrompt);
        if (existing != null)
            return existing.GeneratedSql;

        // Получаем схему БД
        var schema = _schemaProvider.GetSchema();

        // Генерируем SQL через AI
        var sql = await _gemini.GenerateSqlAsync(userPrompt, schema);

        // Очищаем SQL
        sql = _cleaner.Clean(sql);

        // Валидируем
        _validator.Validate(sql);

        // Сохраняем историю
        var history = new SqlQueryHistory(userPrompt, sql);
        await _repository.SaveAsync(history);

        return sql;
    }
}