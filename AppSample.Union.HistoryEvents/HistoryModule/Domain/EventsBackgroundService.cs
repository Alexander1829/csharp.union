using System.Collections.Concurrent;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using AppSample.Union.HistoryEvents.HistoryModule.Domain.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain;

public class EventsBackgroundService : BackgroundService
{
    readonly IHttpClientFactory _httpClientFactory;
    readonly HistoryServiceSettings _settings;
    readonly ILogger<EventsBackgroundService> _logger;
    readonly AuthenticationHeaderValue _authHeader;

    static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web);
    static readonly ConcurrentQueue<HistoryEvent> EventsBuffer = new();
    static HistoryEvent[] _eventsBatch = null!;

    public EventsBackgroundService(
        IHttpClientFactory httpClientFactory,
        IOptions<HistoryServiceSettings> settings,
        ILogger<EventsBackgroundService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
        _settings = settings.Value;

        if (string.IsNullOrEmpty(_settings.Host))
            throw new ArgumentException(
                "Strongly recommend add HttpRepositoriesSettings:History:Host to the Configuration");

        if (string.IsNullOrEmpty(_settings.UserName))
            throw new ArgumentException(
                "Strongly recommend add HttpRepositoriesSettings:History:UserName to the Configuration");

        if (string.IsNullOrEmpty(_settings.UserPass))
            throw new ArgumentException(
                "Strongly recommend add HttpRepositoriesSettings:History:UserPass to the Configuration");

        _authHeader = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(
            Encoding.ASCII.GetBytes($"{_settings.UserName}:{_settings.UserPass}")));

        _eventsBatch = new HistoryEvent[_settings.EventsBatchSize > 0 ? _settings.EventsBatchSize : 10];
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _ = Run(stoppingToken);

        return Task.CompletedTask;
    }

    async Task Run(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await SendEvents(stoppingToken);
            await Task.Delay(100, stoppingToken);
        }
    }

    async Task SendEvents(CancellationToken stoppingToken)
    {
        while (EventsBuffer.Count >= _eventsBatch.Length)
        {
            await SendEventsButch(stoppingToken);
        }
    }

    async Task SendEventsButch(CancellationToken stoppingToken)
    {
        var index = 0;

        while (EventsBuffer.TryDequeue(out var val))
        {
            _eventsBatch[index++] = val;

            if (index < _eventsBatch.Length) continue;

            while (!stoppingToken.IsCancellationRequested)
            {
                if (await TrySend(_eventsBatch))
                    break;

                await Task.Delay(1_000, stoppingToken);
            }

            break;
        }
    }

    async Task<bool> TrySend(IReadOnlyCollection<HistoryEvent> historyEvents)
    {
        var json = JsonSerializer.Serialize(historyEvents, SerializerOptions);
        var request = new HttpRequestMessage(HttpMethod.Post, $"{_settings.Host}/history/add")
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json"),
            Headers = { Authorization = _authHeader }
        };

        try
        {
            var response = await _httpClientFactory.CreateClient().SendAsync(request);
            return response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Sending event to the history service ended with exception.");
        }

        return false;
    }

    public static void AddIdgwEvent<T>(T data)
        where T : struct, IHistoryEventData => AddEvent(ComponentType.Idgw, data);

    public static void AddEvent<T>(ComponentType componentType, T data)
        where T : struct, IHistoryEventData
    {
        AddEventInternal(componentType, data, clientId: null);
    }

    public static void AddEvent<T>(ComponentType componentType, T data, string clientId)
        where T : struct, IHistoryEventData
    {
        AddEventInternal(componentType, data, clientId);
    }

    static void AddEventInternal<T>(ComponentType componentType, T data, string? clientId)
        where T : struct, IHistoryEventData
    {
        if (EventsBuffer.Count > _eventsBatch.Length * 15)
            return;

        var newEvent = new HistoryEvent(
            componentType,
            data.EventType,
            TransactionInfo.TransactionId,
            DateTimeOffset.Now,
            clientId,
            JsonSerializer.Serialize(data, SerializerOptions));

        EventsBuffer.Enqueue(newEvent);
    }
}