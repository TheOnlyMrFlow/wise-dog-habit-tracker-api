using TWD.HabitTracker.Domain.Entities.User.Auth;

namespace TWD.HabitTracker.Application.UseCases.Habits.Stamps.RemoveOne;

public class RemoveStampFromHabitRequest
{
    public RemoveStampFromHabitRequest(LoggedUser loggedUser, Guid habitId, DateTime stampDate)
    {
        LoggedUser = loggedUser;
        HabitId = habitId;
        StampDate = stampDate;
    }
    
    public LoggedUser LoggedUser { get; }
    public Guid HabitId { get; }
    public DateTime StampDate { get; }
}