using System.ComponentModel;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models;

public enum AuthenticatorType
{
    [Description("Нет данных")] NoValue = 0,
    [Description("Seamless")] Seamless = 1,
    [Description("Sms + Url")] SmsWithUrl = 2,
    [Description("Sms + Otp")] SmsOtp = 3,
    [Description("Ussd")] Ussd = 4,
    [Description("Push Mc")] PushMc = 5,
    [Description("Push Dstk")] PushDstk = 6,
}