using System.ComponentModel;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models;

public enum AuthChainStartResultType
{
    [Description("Нет данных")]
    NoValue = 0,
    
    [Description("Цепочка запущена")] 
    Started = 1,
    
    [Description("У СП цепочка пустая")] 
    ChainIsEmpty = 2,

    [Description("Не удалось запустить ни один аутентификатор")]
    NoOneAuthenticatorStarted = 3,

    [Description("Предыдущая транзакция не закончена")]
    PreviousNotFinished = 4,

    [Description("Внутренняя ошибка сервера")]
    InternalError = 999
}