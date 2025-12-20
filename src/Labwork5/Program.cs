using Itmo.ObjectOrientedProgramming.Application;
using Itmo.ObjectOrientedProgramming.Application.Security;
using Itmo.ObjectOrientedProgramming.Infrastructure.Persistence;
using Presentation.Http;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

string adminPassword = builder.Configuration.GetValue<string>("AppSettings:AdminPassword")
                       ?? throw new ArgumentException("AdminPassword is not configured");

builder.Services.AddSingleton(new AdminPassword(adminPassword));

builder.Services
    .AddApplication()
    .AddInfrastructurePersistence()
    .AddPresentationHttp();

builder.Services.AddSwaggerGen().AddEndpointsApiExplorer();

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();