using Domain.Interfaces;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace Infrastructure.Gemini;

/// <summary>
/// Клиент для взаимодействия с AI-сервисом генерации SQL.
/// </summary>
public class GeminiClient : IGeminiClient
{
    private readonly HttpClient _http;
    private readonly GeminiOptions _options;
    public GeminiClient(HttpClient http, IOptions<GeminiOptions> options)
    {
        _http = http;
        _options = options.Value;

        _http.BaseAddress = new Uri(_options.BaseUrl);

        _http.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", _options.ApiKey);

        _http.DefaultRequestHeaders.Add("HTTP-Referer", "http://localhost");
        _http.DefaultRequestHeaders.Add("X-Title", "SQL AI App");
    }

    /// <summary>
    /// Отправляет запрос в AI-модель и получает сгенерированный SQL.
    /// </summary>
    /// <param name="prompt">Пользовательский запрос.</param>
    /// <param name="schema">Описание схемы базы данных.</param>
    /// <returns>Сгенерированный SQL-запрос.</returns>
    public async Task<string> GenerateSqlAsync(string prompt, string schema)
    {
        var fullPrompt = BuildPrompt(prompt, schema);

        var requestBody = new
        {
            model = _options.Model,
            messages = new[]
            {
                new { role = "user", content = fullPrompt }
            }
        };

        var response = await _http.PostAsJsonAsync("v1/chat/completions", requestBody);

        var raw = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
            throw new Exception($"OpenRouter Error: {raw}");

        var json = JsonDocument.Parse(raw);

        return json.RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString()!;
    }

    /// <summary>
    /// Формирует полный prompt для AI-модели,
    /// включая ограничения и схему базы данных.
    /// </summary>
    private static string BuildPrompt(string prompt, string schema)
    {
        return $"""
        You are SQL generator.
        Only SELECT queries allowed.
        Never use INSERT, UPDATE, DELETE, DROP.

        Database schema:
        {schema}

        User request:
        {prompt}

        Return ONLY SQL.
        """;
    }
}
