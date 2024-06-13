var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddApiServices();

var app = builder.Build();

app.UseStaticFiles();

/* app.UseAuthentication(); */
app.UseAuthorization();

app.MapControllers();

app.Run();
