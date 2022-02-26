﻿using TWD.HabitTracker.Domain.Common;
using TWD.HabitTracker.Domain.Entities.Habits.Errors;
using TWD.HabitTracker.Domain.Exceptions;
using TWD.HabitTracker.Domain.ValueObjects;
using TWD.HabitTracker.Domain.ValueObjects.Stamp;

namespace TWD.HabitTracker.Domain.Entities.Habits;

public class Habit
{
    public Habit(Guid id, Guid userId, string name, DateTime startDate, IEnumerable<DayOfWeek> weekDays, HabitObjective? objective, ICollection<Stamp> stamps, ICollection<Stamp> lastTenStamps)
    {
        Id = id;
        UserId = userId;
        Name = name;
        StartDate = startDate;
        WeekDays = new HashSet<DayOfWeek>(weekDays);
        _stamps = stamps;
        _lastTenStamps = lastTenStamps;
        Objective = objective;
    }
    
    public Habit(Guid userId, string name, DateTime startDate, IEnumerable<DayOfWeek> weekDays, HabitObjective? quantifiableObjective) 
        : this(Guid.NewGuid(), userId, name, startDate, weekDays, quantifiableObjective, new List<Stamp>(), new List<Stamp>())
    {
    }

    public Guid Id { get; }

    public string Name { get; set; }
    
    public Guid UserId { get; set; }

    public HabitObjective? Objective { get; set; }
    
    public bool IsQuantifiable => Objective is not null;

    public DateTime StartDate { get; set; }
    
    public HashSet<DayOfWeek> WeekDays { get; set; }

    private readonly ICollection<Stamp> _stamps;
    public IEnumerable<Stamp> Stamps => _stamps;

    private ICollection<Stamp> _lastTenStamps;
    public IEnumerable<Stamp> LastTenStamps => _lastTenStamps;

    public Either<AddStampError, Habit> AddStamp(Stamp stamp)
    {
        if (_stamps.Any(s => s.Date == stamp.Date))
            return new Either<AddStampError, Habit>(AddStampError.StampAlreadyExists());

        if (IsQuantifiable && !stamp.Value.HasValue)
            return new Either<AddStampError, Habit>(AddStampError.StampMushHaveValue());
        
        _stamps.Add(stamp);

        if (_lastTenStamps.Count < 10)
            _lastTenStamps.Add(stamp);
        
        else if (_lastTenStamps.Any(s => s.IsOlderThan(s)))
            _lastTenStamps = _stamps.OrderByDescending(s => s.Date).Take(10).ToList();

        return new Either<AddStampError, Habit>(this);
    }

    public void RemoveStamp(DateTime stampDate)
    {
        var stamp = _stamps.FirstOrDefault(s => s.Date == stampDate);
        if (stamp is null)
            throw new StampNotFoundException();

        _stamps.Remove(stamp);
        
        if (_lastTenStamps.Any(s => s.Date == stampDate))
            _lastTenStamps = _stamps.OrderByDescending(s => s.Date).Take(10).ToList();
    }
}