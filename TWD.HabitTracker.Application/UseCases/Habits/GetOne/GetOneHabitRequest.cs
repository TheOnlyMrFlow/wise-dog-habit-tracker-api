using TWD.HabitTracker.Domain.Entities.User.Auth;

namespace TWD.HabitTracker.Application.UseCases.Habits.GetOne;

public class GetOneHabitRequest
{
    public GetOneHabitRequest(LoggedUser loggedUser, Guid habitId)
    {
        LoggedUser = loggedUser;
        HabitId = habitId;
    }
    
    public LoggedUser LoggedUser { get; }
    public Guid HabitId { get; }
}