using Api2;
using Api2.Repos;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/Example1", async (ExampleRepos repos, CancellationToken cancellation) =>
{
    var result = await repos.ExampleMethod(cancellation);

    if (!result.Success)
    {
        if (result.ErrorType == "Cancellation")
        {
            // Give Cancel status
        }

        if (result.ErrorType == "Global")
        {
            //  Give specific status
        }
    }
});

app.Run();