using System.ComponentModel;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models;

public enum HistoryEventType
{
    [Description("Запуск аутентификатора")]
    AuthenticatorStartResult = 1001,
    [Description("Результат запуска цепочки")]
    AuthChainStartResult = 1002,
    [Description("Результат цепочки")]
    AuthChainResult = 1003,
    [Description("Неудачная попытка завершить цепочку")]
    AuthChainEndFailed = 1004,

    [Description("Входящий SI запрос")]
    SiIncomingRequest = 2001,
    [Description("Запрос к дискавери")]
    SiDiscoveryRequest = 2002,
    [Description("Ответ от дискавери")]
    SiDiscoveryResponse = 2003,
    [Description("Запрос к IDGW")]
    SiIdgwRequest = 2004,
    [Description("Ответ от IDGW")]
    SiIdgwResponse = 2005,
    [Description("Notification от IDGW")]
    SiIdgwNotification = 2006,
    [Description("Notification к СП")]
    SiSpNotificationRequest = 2007,
    [Description("Ответ СП на notification")]
    SiSpNotificationResponse = 2008,
    [Description("Polling запрос от СП")]
    SiSpPollingRequest = 2009,
    [Description("Ответ на polling запрос")]
    SiSpPollingResponse = 2010,
    [Description("Запрос Pdp")]
    SiPdpConsentSent = 2011,
    [Description("Ответ на запрос Pdp")]
    SiConfirmPdpConsent = 2012,
    [Description("Начало fallback-сценария")]
    SiFallbackStarted = 2013,
    [Description("MSISDN известен")]
    SiMsisdnRegistered = 2014,

    [Description("Входящий DI запрос")]
    DiIncomingRequest = 2041,
    [Description("MSISDN введен абонентом")]
    DiMsisdnSpecified = 2042,
    [Description("MSISDN известен")]
    DiMsisdnRegistered = 2043,
    [Description("Callback от IDGW")]
    DiIdgwCallback = 2044,
    [Description("Запрос токенов от СП")]
    McTokenRequest = 2045,
    [Description("Запрос токенов к IDGW")]
    McTokenInternalRequest = 2046,
    [Description("Ответ с токенами от IDGW")]
    McTokenInternalResponse = 2047,
    [Description("Ответ с токенами к СП")]
    McTokenResponse = 2048,
    
    [Description("Запрос ПД от СП")]
    PremiumInfoRequest = 2100,
    [Description("Запрос ПД к RS")]
    PremiumInfoInternalRequest = 2101,
    [Description("Ответ ПД от RS")]
    PremiumInfoInternalResponse = 2102,
    [Description("Ответ ПД к СП")]
    PremiumInfoResponse = 2103,
    
    [Description("Запрошен профиль пользователя")]
    GetUserProfile = 4001,

    [Description("Получен RADIUS-запрос")]
	UdpRequest = 8001,

	[Description("Запрос в CloudConfig")]
	CloudConfigurationRequest = 8002,
	[Description("Ответ от CloudConfig")]
	CloudConfigurationResponse = 8003,

	[Description("Запрос пользователя из DomainUsers")]
	DomainUsersRequest = 8004,
	[Description("Ответ DomainUsers")]
	DomainUsersResponse = 8005,

	[Description("SI запрос к агргеатору")]
	AggregatorSiAuthorizeRequest = 8006,
	[Description("Ответ на SI запрос")]
	AggregatorSiAuthorizeResponse = 8007,

	[Description("Запрос статуса авторизацции в агргеаторе")]
	AggregatorPollingRequest = 8008,
	[Description("Ответ на запрос статуса авторизацции в агргеаторе")]
	AggregatorPollingResponse = 8009,

	[Description("Получен ответ от аграгатора")]
	AggregatorAuthorizationResultChanged = 8010,

	[Description("Пользователь имеет открытую сессию на RADIUS-сервере")]
	RadiusSessionBusy = 8097,
	[Description("Запрос перенаправлен на дополнительный RADIUS-сервер")]
	CascadeRequestStarted = 8098,
	[Description("Сформирован ответ RADIUS-клиенту")]
	UdpResponse = 8099
}
