using Carter;
using Scalar.AspNetCore;
using Store.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddCarter();

builder.Services
.AddCommonFeaturesServices()
.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.MapCarter();

app.MapOpenApi();
app.MapScalarApiReference();

app.UseHttpsRedirection();

app.Run();

