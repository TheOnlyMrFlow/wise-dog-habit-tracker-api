namespace WD.HabitTracker.Api
#nowarn "20"
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open WD.HabitTracker.Application.Services.Persistence
open WD.HabitTracker.Persistence.MongoDb

module Program =
    let exitCode = 0

    [<EntryPoint>]
    let main args =

        let builder = WebApplication.CreateBuilder(args)

        builder.Services.AddSwaggerGen()
        builder.Services.AddControllers()
        builder.Services.AddTransient<IUserReadRepository, UserRepository>();  

        let app = builder.Build()
        
        match app.Environment.IsDevelopment() with
            | true ->
                app.UseSwagger()
                app.UseSwaggerUI()
                //todo : app.UseMiddleware<...>()
            | _ -> failwith "todo middleware"

        app.UseHttpsRedirection()

        app.UseAuthorization()
        app.MapControllers()

        app.Run()

        exitCode