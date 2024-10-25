using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//add service to the container

// -----------------
//Infrastructure - ef core
//Application - Mediatr
//API - Carter, Healthcheck, .. 

//builder.Service
// .AddApplicationServices()
// .AddInfrastructureService(builder.Configuration)
// .AddWebServices()
// -----------------
builder.Services
 .AddApplicationServices()
 .AddInfrastructureServices(builder.Configuration)
 .AddApiServices();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//configure http request pipeline


app.Run();
