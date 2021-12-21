using TWD.HabitTracker.Domain.Entities.Habits.Stamps;

namespace TWD.HabitTracker.Api.ViewModels.Habits.Stamps;

public class StampViewModel
{
    public StampViewModel(DateTime date, decimal? value)
    {
        Date = date;
        Value = value;
    }

    public DateTime Date { get; }
    
    public decimal? Value { get; }
    
    public static StampViewModel FromDomainEntity(Stamp stamp)
        => new (stamp.Date, stamp.Value);
}