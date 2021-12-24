using TWD.HabitTracker.Domain.Entities.User.Auth;

namespace TWD.HabitTracker.Application.UseCases.Habits.Stamps.AddOne;

public class AddStampToHabitRequest
{
    public AddStampToHabitRequest(LoggedUser loggedUser, Guid habitId, DateTime stampDate, float? stampValue)
    {
        LoggedUser = loggedUser;
        HabitId = habitId;
        StampDate = stampDate;
        StampValue = stampValue;
    }
    public LoggedUser LoggedUser { get; }
    public Guid HabitId { get; }
    public DateTime StampDate { get; }
    public float? StampValue { get; }
}