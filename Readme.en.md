# Query_AI_Gemini — AI-Powered SQL Generator & Safe Execution Engine #

A Clean Architecture-based .NET project that transforms natural language into safe SQL queries using AI, validates them, and executes them securely directly on a database.

This project demonstrates:

- AI-driven SQL generation (schema-aware)
- Strict SELECT-only validation
- SQL cleaning and safety rules
- Safe execution via Dapper
- Query history storage
- Clean Architecture principles
- Dependency inversion and layered design

---

## 🚀 Features
- Generate SQL from natural language prompts
- Schema-aware AI prompt building
- Automatic SQL cleaning (removes markdown, comments, formatting)
- Validation rules (no INSERT / UPDATE / DELETE / DROP)
- Safe execution with result limiting (TOP 1000)
- In-memory query history storage
- Clean Architecture separation (Domain / Application / Infrastructure)

---

## 🏗 Architecture
The project follows Clean Architecture principles:
## 📁 Core project structure
```bash
├── Domain/                // business rules, validation logic, core contracts
│   ├── Entities
│   ├── Interfaces
|   ├── Validators
│   └── ValueObjects
├── Application/           // orchestration, use-case logic
│   ├── DTOs
|   ├── Schema
│   └── Services
├── Infrastructure/        // external systems (AI API, database, Dapper, configuration)
│   ├── Caching
│   ├── Gemini
|   ├── Persistence
│   └── Repositories
```
The Application layer depends only on abstractions, never on Infrastructure.

---

## 🧠 How It Works

1. User sends a natural language prompt.
2. Schema is attached to the prompt.
3. AI generates a SQL query.
4. SQL is cleaned.
5. SQL is validated (SELECT-only rule).
6. Query is stored in history.
7. SQL is executed safely via Dapper.
8. Results are returned.

---

## 📦 Technologies

| Component         | Tech stack                              |
|------------------ |-----------------------------------------|
| Language          | C#                                      |
| Framework         | .NET 8                                  |
| AI Integration    | HTTP Client (OpenRouter/Gemini)         |
| Database Access   | Dapper                                  |
| Database Driver   | Microsoft.Data.SqlClient                |
| Architecture      | Clean Architecture                      |
| DI & Config       | Microsoft.Extensions.*                  |

---

## 📦 Getting Started

### 1. Clone the repo

### 2. Configure appsettings.json
```bash
{
  "ConnectionStrings": {
    "DefaultConnection": "your-sql-connection-string"
  },
  "GeminiOptions": {
    "ApiKey": "your-api-key",
    "BaseUrl": "https://your-ai-endpoint",
    "Model": "your-model-name"
  }
}
```

### 3. Run the project

---

## 🔐 Safety

- Only SELECT queries are allowed.
- Dangerous operations are blocked at validation level.
- Execution is limited to 1000 rows by default.
- SQL is cleaned before validation.

---

## 🙋‍♀️ Author
Ghalia Dahech
