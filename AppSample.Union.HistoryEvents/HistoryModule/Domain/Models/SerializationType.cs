namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models;

/// <summary>
/// Тип сериализации EventValue
/// </summary>
public enum SerializationType
{
    /// <summary>
    /// Без сериализации
    /// </summary>
    None = 0,
    
    /// <summary>
    /// Как есть, для строковых значений
    /// </summary>
    AsIs = 1,
    
    /// <summary>
    /// ToString
    /// </summary>
    ToString = 2,
    
    /// <summary>
    /// JSON
    /// </summary>
    Json = 3
}