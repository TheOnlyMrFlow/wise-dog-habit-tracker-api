module WD.HabitTracker.Application.ListHabistUseCase

open System
open WD.HabitTracker.Application.Services.Authentication
open WD.HabitTracker.Application.Services.Persistence
open WD.HabitTracker.Domain
open WD.HabitTracker.Domain.Habits

type ListHabitsInput = {
    UserId: Guid
}

type ListHabitsSuccessResult = {
    Habits: Habit list
}

type ListHabitsResult =
    | Success of ListHabitsSuccessResult
    | UserNotFound
    | UndisclosedError
    
let listHabitsAsync (habitsReadRepository: IHabitReadRepository) input : Async<ListHabitsResult> =
    async {
        let! listHabitsResult = habitsReadRepository.ListHabitsOfUserAsync input.UserId
        return match listHabitsResult with
                | Some habits -> Success {Habits = habits}
                | None -> UserNotFound 
    }
 