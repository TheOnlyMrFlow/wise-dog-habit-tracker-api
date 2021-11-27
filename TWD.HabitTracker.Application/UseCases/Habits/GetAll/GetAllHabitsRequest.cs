using TWD.HabitTracker.Domain.Entities.User.Auth;

namespace TWD.HabitTracker.Application.UseCases.Habits.GetAll;

public class GetAllHabitsRequest
{
    public GetAllHabitsRequest(LoggedUser loggedUser)
    {
        LoggedUser = loggedUser;
    }
    public LoggedUser LoggedUser { get; set; }
}