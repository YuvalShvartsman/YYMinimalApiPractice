using YYMinimalApiPractice.Endpoints;
using YYMinimalApiPractice.Extentions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwagger();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapUserEndpoints();

app.Run();

