using Microsoft.EntityFrameworkCore;
using YYMinimalApiPractice.Data;
using YYMinimalApiPractice.Endpoints;
using YYMinimalApiPractice.Extentions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("postgressql")));

builder.Services.AddSwagger();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapUserEndpoints();
app.MapTodoEndpoints();

app.Run();

