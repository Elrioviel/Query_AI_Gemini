namespace Domain.ValueObjects;

/// <summary>
/// Value Object, представляющий SQL-запрос.
/// Гарантирует, что запрос не является пустым
/// и хранится в нормализованном виде.
/// </summary>
public class SqlQuery
{
    /// <summary>
    /// Текст SQL-запроса.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Создаёт новый SQL-запрос.
    /// </summary>
    /// <param name="value">Текст SQL-запроса.</param>
    /// <exception cref="ArgumentException">
    /// Выбрасывается, если запрос пустой или содержит только пробелы.
    /// </exception>
    public SqlQuery(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("SQL запрос не может быть пустым");

        Value = value.Trim();
    }

    /// <summary>
    /// Возвращает текст SQL-запроса.
    /// </summary>
    public override string ToString() => Value;
}
