using TWD.HabitTracker.Application.UseCases.Auth.Signup;
using TWD.HabitTracker.Application.UseCases.Habits.AddOne;
using TWD.HabitTracker.Application.UseCases.Habits.GetAll;

namespace TWD.HabitTracker.Api.Configurations.UseCases;

public static class UseCaseConfigurations
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        //auth
        services.AddScoped<SignupInteractor>();
        
        // habits
        services.AddScoped<GetAllHabitsInteractor>();
        services.AddScoped<AddOneHabitInteractor>();

        return services;
    }
}