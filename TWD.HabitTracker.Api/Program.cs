using Microsoft.AspNetCore.Authentication.JwtBearer;
using TWD.HabitTracker.Api.Configurations.Auth;
using TWD.HabitTracker.Api.Configurations.Persistence;
using TWD.HabitTracker.Api.Configurations.UseCases;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSwaggerGen()
    .AddEndpointsApiExplorer()
    .AddPersistenceServices(builder.Configuration)
    .AddAuthServices(builder.Configuration)
    .AddUseCases()
    .AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policyBuilder => policyBuilder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();