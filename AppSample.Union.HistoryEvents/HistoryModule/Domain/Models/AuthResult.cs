using System.ComponentModel;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models;

/// <summary>
/// Результат аутентификации
/// </summary>
public enum AuthResult
{
    /// <summary>
    /// Ничего не означает. Эквивалентно null
    /// </summary>
    [Description("Нет данных")] NoValue = 0,

    /// <summary>
    /// Пользователь ответил согласием
    /// </summary>
    [Description("Нажал OK")] UserAgree = 1,

    /// <summary>
    /// Пользователь ответил отказом
    /// </summary>
    [Description("Нажал Cancel")] UserDenied = 2,

    /// <summary>
    /// Аутентификация завершилась по таймауту
    /// </summary>
    [Description("Истекло время ожидания ответа")]
    Timeout = 3,

    /// <summary>
    /// Предыдущая аутентификация ещё не закончена
    /// </summary>
    [Description("Предыдущая транзакция не закончена")]
    PreviousNotFinished = 4,

    /// <summary>
    /// Закончились попытки аутентификации
    /// </summary>
    [Description("Исчерпано количество попыток ввода")]
    RunOutOfAttempts = 5,

    /// <summary>
    /// Пользоватль заблокирован
    /// </summary>
    [Description("Пользователь заблокирован")]
    UserBlocked = 6
}