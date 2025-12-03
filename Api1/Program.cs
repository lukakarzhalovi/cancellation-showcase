var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient
("Api2",
    client => client.BaseAddress = new Uri("https://localhost:44353/Example1"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/Post", async (IHttpClientFactory httpClient) =>
{
    var client = httpClient.CreateClient("Api2");
    client.Timeout = TimeSpan.FromSeconds(2);
    var response = await client.GetFromJsonAsync<string>(client.BaseAddress, cancellationToken: CancellationToken.None);
    return response;
});


app.Run();