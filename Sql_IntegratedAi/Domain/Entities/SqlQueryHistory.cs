namespace Domain.Entities;

/// <summary>
/// Сущность, представляющая историю сгенерированных SQL-запросов.
/// </summary>
public class SqlQueryHistory
{
    public Guid Id { get; private set; }
    public string UserPrompt { get; private set; }
    public string GeneratedSql { get; private set; }
    public bool IsApproved { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private SqlQueryHistory() { }

    public SqlQueryHistory(string userPrompt, string generatedSql)
    {
        if (string.IsNullOrWhiteSpace(userPrompt))
            throw new ArgumentException("Промпт не может быть пустым");

        if (string.IsNullOrWhiteSpace(generatedSql))
            throw new ArgumentException("Сгенерированный SQL не может быть пустым");

        Id = Guid.NewGuid();
        UserPrompt = userPrompt;
        GeneratedSql = generatedSql;
        CreatedAt = DateTime.UtcNow;
        IsApproved = false;
    }

    /// <summary>
    /// Подтверждает корректность SQL-запроса.
    /// </summary>
    public void Approve()
    {
        IsApproved = true;
    }

    /// <summary>
    /// Обновляет SQL-запрос и сбрасывает статус подтверждения.
    /// </summary>
    /// <param name="correctedSql">Исправленный SQL-запрос.</param>
    public void UpdateSql(string correctedSql)
    {
        if (string.IsNullOrWhiteSpace(correctedSql))
            throw new ArgumentException("SQL не может быть пустым");

        GeneratedSql = correctedSql;
        IsApproved = false;
    }
}
