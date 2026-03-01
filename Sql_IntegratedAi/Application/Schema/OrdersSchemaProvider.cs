using Domain.Interfaces;

namespace Application.Schema;

/// <summary>
/// Предоставляет описание структуры базы данных для генерации SQL.
/// Используется для передачи схемы в AI-модель.
/// </summary>
public class OrdersSchemaProvider : IDatabaseSchemaProvider
{
    /// <summary>
    /// Возвращает строковое представление схемы базы данных.
    /// </summary>
    public string GetSchema()
    {
        return @"
        Database Schema:

        Table: orders

        Columns:
        idorder int PRIMARY KEY
        name varchar(128)
        dtdoc datetime
        sm numeric(15,4)
        idcustomer int
        idseller int
        iddocstate int
        deleted datetime

        Constraints:
        - deleted IS NULL means active order
        ";
    }
}
