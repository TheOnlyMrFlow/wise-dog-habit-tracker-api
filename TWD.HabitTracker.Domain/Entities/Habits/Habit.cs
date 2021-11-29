using TWD.HabitTracker.Domain.Entities.Habits.Stamps;
using TWD.HabitTracker.Domain.ValueObjects;

namespace TWD.HabitTracker.Domain.Entities.Habits;

public class Habit
{
    public Habit() { }
    
    public Habit(string name)
    {
        Name = name;
    }

    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = null!;
    
    public Guid UserId { get; set; }

    public QuantifiableObjective? QuantifiableObjective { get; set; }
    
    public bool IsQuantifiable => QuantifiableObjective is not null;

    private ICollection<Stamp> _stamps = new List<Stamp>();
    public IEnumerable<Stamp> Stamps => _stamps;
    
    public void AddStamp(Stamp stamp)
    {
        if (!IsQuantifiable && stamp!.Value.HasValue)
            throw new Exception(); // TODO: proper exception
        
        _stamps.Add(stamp);
    }
}

public enum EDayOfWeek
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}