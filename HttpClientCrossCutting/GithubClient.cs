namespace HttpClientCrossCutting;

public class GithubClient
{
    private readonly HttpClient _client;
    private ILogger<GithubClient> _logger;

    public GithubClient(HttpClient client, ILogger<GithubClient> logger)
    {
        _client = client;
        _logger = logger;
    }

    public async Task<string> GetHomePageAsync()
    {
        var response = await _client.GetAsync("https://github.com");
        return await response.Content.ReadAsStringAsync();
    }
}