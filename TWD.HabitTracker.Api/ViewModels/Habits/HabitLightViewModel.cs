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
    }
    
    public Guid Id { get; }
    
    public string Name { get; }
    
    public IEnumerable<StampViewModel> LastTenStamps { get; }
}