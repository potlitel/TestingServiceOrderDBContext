var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureApi(builder.Configuration);
var app = builder.Build();

app.ConfigureServiceOrdersWebApp();

app.Run();
