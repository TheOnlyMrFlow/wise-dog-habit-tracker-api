namespace WD.HabitTracker.Api.Controllers.ListHabits

open System
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open WD.HabitTracker.Application.ListHabistUseCase
open WD.HabitTracker.Application.Services.Authentication
open WD.HabitTracker.Application.Services.Persistence

type ListHabitsHabitElementViewModel = {
    Id: Guid
    Name: string
}

type ListHabitsSuccessHttpResponse = {
    Habits: ListHabitsHabitElementViewModel list
}

[<ApiController>]
[<Route("users/{userId:guid}/habits")>]
type LoginController (logger : ILogger<LoginController>) =
    inherit ControllerBase()
    
    [<HttpPost>]
    member this.ListHabitsAsync([<FromServices>] habitsReadRepository: IHabitReadRepository, [<FromRoute>] userId: Guid) = async {
        let useCaseInput: ListHabitsInput = {UserId = userId}
        let! useCaseResult = listHabitsAsync habitsReadRepository useCaseInput 
        return match useCaseResult with
                | Success successResult -> this.Ok { Habits = list.Empty } :> IActionResult
                | UserNotFound -> this.StatusCode(403) :> IActionResult
                | UndisclosedError -> this.StatusCode 500
    }
