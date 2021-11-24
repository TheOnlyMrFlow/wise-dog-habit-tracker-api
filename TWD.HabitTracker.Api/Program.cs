using Microsoft.AspNetCore.Authentication.JwtBearer;
using TWD.HabitTracker.Api.Configurations.Persistence;
using TWD.HabitTracker.Api.Configurations.UseCases;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSwaggerGen()
    .AddEndpointsApiExplorer()
    .AddPersistenceServices(builder.Configuration)
    .AddUseCases()
    .AddControllers();

// builder.Services
//     .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    // .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => builder.Configuration.Bind("JwtSettings", options));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();