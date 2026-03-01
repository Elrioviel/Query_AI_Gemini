using Application.Schema;
using Application.Services;
using Application.Services.Interfaces;
using Domain.Interfaces;
using Domain.Validators;
using Domain.Validators.Rules;
using Infrastructure.Gemini;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// CORS - allow any origin for testing (adjust in production!)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SQL AI API",
        Version = "v1"
    });
});

// Dependency Injection
builder.Services.AddScoped<ISqlGenerator, SqlGenerationService>();
builder.Services.AddScoped<ISqlExecutor, SqlExecutor>();

builder.Services.AddScoped<IDbExecutor, SqlExecutionService>();
builder.Services.AddScoped<ISqlQueryRepository, SqlQueryRepository>();
builder.Services.AddScoped<IDatabaseSchemaProvider, OrdersSchemaProvider>();

builder.Services.AddScoped<ISqlCleaner, SqlCleaner>();

builder.Services.AddScoped<ISqlRule, OnlySelectRule>();
builder.Services.AddScoped<ISqlRule, ForbiddenKeywordRule>();

builder.Services.AddScoped<SqlValidator>();

builder.Services.Configure<GeminiOptions>(
    builder.Configuration.GetSection("Gemini"));

builder.Services.AddHttpClient<IGeminiClient, GeminiClient>();
var app = builder.Build();

// Enable Swagger in all environments
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SQL AI API V1");
    c.RoutePrefix = string.Empty;
});

// Enable CORS
app.UseCors();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();