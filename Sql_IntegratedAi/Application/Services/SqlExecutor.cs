using Application.Services.Interfaces;
using System.Text;

namespace Application.Services;

/// <summary>
/// Сервис выполнения SQL-запросов и форматирования результата.
/// </summary>
public class SqlExecutor : ISqlExecutor
{
    private readonly IDbExecutor _dbExecutor;

    public SqlExecutor(IDbExecutor dbExecutor)
    {
        _dbExecutor = dbExecutor;
    }

    /// <summary>
    /// Выполняет SELECT-запрос и возвращает форматированный результат.
    /// </summary>
    /// <param name="sql">SQL-запрос.</param>
    /// <returns>Отформатированная строка с результатами.</returns>
    public async Task<string> ExecuteAndFormatAsync(string sql)
    {
        var result = await _dbExecutor.ExecuteSelectAsync(sql);

        if (!result.Any())
            return "No data found.";

        var sb = new StringBuilder();

        foreach (var row in result.Take(10))
        {
            var dictionary = (IDictionary<string, object>)row;

            foreach (var column in dictionary)
            {
                sb.Append($"{column.Key}: {column.Value} | ");
            }

            sb.AppendLine();
        }

        return sb.ToString();
    }
}