using Carter;
using Scalar.AspNetCore;
using Store.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCommonServices(builder.Configuration);

var app = builder.Build();

app.MapCarter();

app.MapOpenApi();
app.MapScalarApiReference();

app.UseHttpsRedirection();

app.Run();

