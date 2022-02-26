using TWD.HabitTracker.Api.Configurations.Auth;
using TWD.HabitTracker.Api.Configurations.Persistence;
using TWD.HabitTracker.Api.Configurations.UseCases;
using TWD.HabitTracker.Api.Middlewares.ErrorHandling;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSwaggerGen()
    .AddEndpointsApiExplorer()
    .AddPersistenceServices(builder.Configuration)
    .AddAuthServices(builder.Configuration)
    .AddLogging(logging => logging.AddConsole())
    .AddUseCases()
    .AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    app.UseMiddleware<DevelopmentGlobalErrorHandlingMiddleware>();
}
else
{
    app.UseMiddleware<ProductionGlobalErrorHandlingMiddleware>();
}

app.UseCors(policyBuilder => policyBuilder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();


app.Run();