using System.Diagnostics;

namespace HttpClientCrossCutting;

public class LoggingHandler : DelegatingHandler
{
    private readonly ILogger<LoggingHandler> _logger;
    private readonly Stopwatch _stopwatch = new();

    public LoggingHandler(ILogger<LoggingHandler> logger)
    {
        _logger = logger;
    }


    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Sending request to Github");
        _stopwatch.Start();
        var response = await base.SendAsync(request, cancellationToken);
        _stopwatch.Stop();
        _logger.LogInformation("Request completed in {StopwatchElapsedMilliseconds} ms", _stopwatch.ElapsedMilliseconds);
        _stopwatch.Reset();

        return response;
    }
}