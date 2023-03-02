using System.ComponentModel;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models;

public enum IdgwType
{
    [Description("")]
    Unknown = 0,
    
    [Description("Билайн A1 Systems")]
    BeelineA1 = 1,
    
    [Description("Билайн")]
    Beeline = 2,
    
    [Description("Мегафон")]
    Megafon = 3,
    
    [Description("МТС")]
    Mts = 4,
    
    [Description("Теле2")]
    Tele2
}