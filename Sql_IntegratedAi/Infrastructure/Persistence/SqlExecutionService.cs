using Application.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence;

/// <summary>
/// Реализация выполнения SQL-запросов через Dapper.
/// Работает только с SELECT-запросами.
/// </summary>
public class SqlExecutionService : IDbExecutor
{
    private readonly string _connectionString;

    /// <summary>
    /// Создаёт сервис выполнения SQL-запросов.
    /// </summary>
    /// <param name="configuration">
    /// Конфигурация приложения, содержащая строку подключения.
    /// </param>
    /// <exception cref="InvalidOperationException">
    /// Выбрасывается, если строка подключения отсутствует.
    /// </exception>
    public SqlExecutionService(IConfiguration configuration)
    {
        _connectionString =
            configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string not found.");
    }

    /// <summary>
    /// Выполняет SELECT-запрос к базе данных.
    /// </summary>
    /// <param name="sql">SQL-запрос для выполнения.</param>
    /// <returns>Коллекция динамических объектов с результатами запроса.</returns>
    public async Task<IEnumerable<dynamic>> ExecuteSelectAsync(string sql)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        if (!sql.ToLower().Contains("top"))
            sql = $"SELECT TOP 1000 * FROM ({sql}) AS sub";

        return await connection.QueryAsync(sql);
    }
}
