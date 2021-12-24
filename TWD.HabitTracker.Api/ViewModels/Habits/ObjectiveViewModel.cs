using TWD.HabitTracker.Domain.ValueObjects;

namespace TWD.HabitTracker.Api.ViewModels.Habits;

public class ObjectiveViewModel
{
    public ObjectiveViewModel(HabitObjective domainObjective)
    {
        Value = domainObjective.Value;
        Unit = domainObjective.Unit;
    }

    public string? Unit { get; set; }

    public float? Value { get; set; }
}