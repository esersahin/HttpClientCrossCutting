using HttpClientCrossCutting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<LoggingHandler>();
builder.Services.AddScoped<ExceptionHandler>();
builder.Services.AddHttpClient<GithubClient>()
    .AddHttpMessageHandler<ExceptionHandler>()
    .AddHttpMessageHandler<LoggingHandler>();


var app = builder.Build();

app.MapGet("/", async (GithubClient gitClient) =>
{
    var response = await gitClient.GetHomePageAsync();
    Results.Ok(response);
});

app.Run();