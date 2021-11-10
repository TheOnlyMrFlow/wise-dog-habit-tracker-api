using TWD.HabitTracker.Domain.Entities.Habits;

namespace TWD.HabitTracker.Api.ViewModels.Habits;

public class HabitViewModel
{
    public Guid Guid { get; set; }
    
    public string Name { get; set; }

    public static HabitViewModel FromDomainEntity(Habit domainHabit) 
        => new()
        {
            Guid = domainHabit.Id,
            Name = domainHabit.Name
        };
}