using System.ComponentModel;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models;

public enum AuthenticatorStartResultType
{
    [Description("Нет данных")]
    NoValue = 0,
    
    [Description("Запущен")]
    Started = 1,

    [Description("SIM-карта не поддерживает")]
    SimCardNotSupport = 2,

    [Description("Сервис-провайдер не найден")]
    ServiceProviderNotFound = 3,
    
    [Description("Некорректный msisdn")]
    MsisdnInvalid = 4,

    [Description("Не найден профиль пользователя")]
    UserInfoNotFound = 5,

    [Description("Сообщение не отправлено")]
    NotSent = 6,

    [Description("Пользователь заблокирован")]
    UserBlocked = 7,

    [Description("У СП не задан url для otp-уведомлений")]
    OtpNotifyUrlNotFound = 8,

    [Description("LoA 3 (PIN) не поддерживается")]
    LoA3NotSupported = 9,

    [Description("LoA 4 не поддерживается")]
    LoA4NotSupported = 10,

    [Description("Ip-адрес пользователся не относится к сети Билайн")]
    InvalidIpAddress = 11,

    [Description("Внутренняя ошибка")]
    InnerError = 12
}