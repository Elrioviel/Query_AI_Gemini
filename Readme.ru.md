# Query_AI_Gemini — AI-генерация запросов и безопасное выполнение SQL #

Проект на .NET с использованием Clean Architecture, который преобразует текстовый запрос пользователя в SQL с помощью AI, валидирует его и безопасно выполняет в базе данных.

Проект демонстрирует:

- Генерацию SQL через AI с учётом схемы БД
- Строгую проверку (только SELECT)
- Очистку SQL от лишнего форматирования
- Безопасное выполнение через Dapper
- Хранение истории запросов
- Чистую архитектуру и инверсию зависимостей

---

## 🚀 Возможности
- Генерация SQL по текстовому запросу
- Передача схемы БД в AI
- Автоматическая очистка SQL
- Валидация правил безопасности
- Ограничение выборки (TOP 1000)
- Хранение истории запросов
- Разделение слоёв по Clean Architecture
---

## 🏗 Архитектура
## 📁 Проект разделён на слои:
```bash
├── Domain/                // бизнес-логика и правила
│   ├── Entities
│   ├── Interfaces
|   ├── Validators
│   └── ValueObjects
├── Application/           // сценарии использования
│   ├── DTOs
|   ├── Schema
│   └── Services
├── Infrastructure/        // внешние зависимости (AI, БД)
│   ├── Caching
│   ├── Gemini
|   ├── Persistence
│   └── Repositories
```
---

## 🧠 Как оно работает

1. Пользователь вводит текстовый запрос.
2. К нему добавляется схема базы данных.
3. AI генерирует SQL.
4. SQL очищается.
5. SQL проходит валидацию.
6. Запрос сохраняется в историю.
7. Выполняется безопасно через Dapper.
8. Результат возвращается пользователю.

---

## 📦 Используемые технологии

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

## 📦 Запуск проекта

### 1. Клонировать репозиторий

### 2. Настроить appsettings.json
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

### 3. Запустить проект

---

## 🔐 Безопасность

- Разрешены только SELECT-запросы.
- Опасные операции блокируются на уровне валидации.
- По умолчанию выборка ограничена 1000 строками.
- SQL очищается перед валидацией.

---

## 🙋‍♀️ Автор
Ghalia Dahech
