using TWD.HabitTracker.Api.ViewModels.Habits.Stamps;
using TWD.HabitTracker.Domain.Entities.Habits;

namespace TWD.HabitTracker.Api.ViewModels.Habits;

public class HabitFullViewModel : HabitLightViewModel
{
    public HabitFullViewModel(Habit domainHabit) : base(domainHabit)
    {
        Stamps = domainHabit.Stamps.OrderByDescending(d => d.Date).Select(StampViewModel.FromDomainEntity);
    }

    public IEnumerable<StampViewModel> Stamps { get; set; }
}