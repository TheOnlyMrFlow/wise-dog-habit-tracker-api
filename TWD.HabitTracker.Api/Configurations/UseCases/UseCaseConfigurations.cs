using TWD.HabitTracker.Application.UseCases.Habits.GetAll;

namespace TWD.HabitTracker.Api.Configurations.UseCases;

public static class UseCaseConfigurations
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<GetAllHabitsInteractor>();

        return services;
    }
}