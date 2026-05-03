using Dagemov.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
builder.Services.ExtensionServices(builder.Configuration);
app.Run();
