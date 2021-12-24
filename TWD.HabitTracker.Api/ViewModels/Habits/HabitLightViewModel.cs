using TWD.HabitTracker.Api.ViewModels.Habits.Stamps;
using TWD.HabitTracker.Domain.Entities.Habits;

namespace TWD.HabitTracker.Api.ViewModels.Habits;

public class HabitLightViewModel
{
    public HabitLightViewModel(Habit domainHabit)
    {
        Id = domainHabit.Id;
        Name = domainHabit.Name;
        LastTenStamps = domainHabit.LastTenStamps.Select(StampViewModel.FromDomainEntity);
        WeekDays = domainHabit.WeekDays;
        Objective = domainHabit.Objective is null ? null : new ObjectiveViewModel(domainHabit.Objective);
    }
    
    public Guid Id { get; }
    
    public string Name { get; }
    
    public IEnumerable<StampViewModel> LastTenStamps { get; }
    
    public IEnumerable<DayOfWeek> WeekDays { get; }
    
    public ObjectiveViewModel? Objective { get; set; }
}