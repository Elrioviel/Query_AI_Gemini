namespace Domain.Interfaces;
/// <summary>
/// Предоставляет описание схемы базы данных,
/// используемое при генерации SQL-запросов.
/// </summary>
public interface IDatabaseSchemaProvider
{
    /// <summary>
    /// Возвращает текстовое представление схемы базы данных.
    /// </summary>
    string GetSchema();
}
