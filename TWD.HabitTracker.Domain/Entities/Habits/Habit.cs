using TWD.HabitTracker.Domain.Entities.Habits.Stamps;
using TWD.HabitTracker.Domain.Exceptions;
using TWD.HabitTracker.Domain.ValueObjects;

namespace TWD.HabitTracker.Domain.Entities.Habits;

public class Habit
{
    public Habit() { }
    
    public Habit(Guid id, Guid userId, string name, ICollection<Stamp> stamps, ICollection<Stamp> lastTenStamps)
    {
        Id = id;
        UserId = userId;
        Name = name;
        _stamps = stamps;
        _lastTenStamps = lastTenStamps;
    }

    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = null!;
    
    public Guid UserId { get; set; }

    public QuantifiableObjective? QuantifiableObjective { get; set; }
    
    public bool IsQuantifiable => QuantifiableObjective is not null;

    private ICollection<Stamp> _stamps = new List<Stamp>();
    public IEnumerable<Stamp> Stamps => _stamps;

    private ICollection<Stamp> _lastTenStamps = new List<Stamp>(10);
    public IEnumerable<Stamp> LastTenStamps => _lastTenStamps;

    public void AddStamp(Stamp stamp)
    {
        if (IsQuantifiable && !stamp.Value.HasValue)
            throw new StampMustHaveValueException();
        
        _stamps.Add(stamp);

        if (_lastTenStamps.Count < 10)
            _lastTenStamps.Add(stamp);
        
        else if (_lastTenStamps.Any(s => s.IsOlderThan(s)))
            _lastTenStamps = _stamps.OrderByDescending(s => s.Date).Take(10).ToList();
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