using BuzluManav.Presentation.WebAPI.Infrastructure.Extensions;
using CorePackages.Infrastructure.Infrastructure.CrossCuttingConcerns.Exception.WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddServiceConfiguration(builder.Configuration);
builder.Services.AddOpenApi();

builder.Services.AddSignalR();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddHangfire(config => config.UseSqlServerStorage(builder.Configuration.GetConnectionString("ErgitDbConnection")));
// builder.Services.AddHangfireServer();

var app = builder.Build();

app.ConfigureSwagger();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

//app.ConfigureCustomExceptionMiddleware();
app.MapControllers();

app.ConfigureCors(builder.Configuration);

// app.UseHangfireDashboard("/hangfire");
// app.MapHub<>("/");

app.UseStaticFiles();

app.Run();
