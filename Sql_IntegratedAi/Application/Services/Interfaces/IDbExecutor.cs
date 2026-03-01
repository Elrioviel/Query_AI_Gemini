namespace Application.Services.Interfaces;

/// <summary>
/// Определяет контракт для выполнения SQL-запросов к базе данных.
/// Предназначен для выполнения только безопасных SELECT-запросов.
/// </summary>
public interface IDbExecutor
{
    /// <summary>
    /// Выполняет SELECT-запрос и возвращает результат в виде набора строк.
    /// </summary>
    /// <param name="sql">SQL-запрос для выполнения.</param>
    /// <returns>Коллекция динамических объектов с результатами запроса.</returns>
    Task<IEnumerable<dynamic>> ExecuteSelectAsync(string sql);
}
