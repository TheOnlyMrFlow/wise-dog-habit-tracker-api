namespace WD.HabitTracker.Application.Services.Persistence

open System
open WD.HabitTracker.Domain.Habits

type IHabitReadRepository =
    abstract member ListHabitsOfUserAsync: Guid -> Async<Habit list option>