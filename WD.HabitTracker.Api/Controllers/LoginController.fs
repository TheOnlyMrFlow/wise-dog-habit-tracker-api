﻿namespace WD.HabitTracker.Api.Controllers

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open WD.HabitTracker.Application.LoginWithDeviceUseCase
open WD.HabitTracker.Application.Services.Persistence

type SuccessHttpResponse = {
    Jwt: string
}

//
//type wrongDeviceTokenHttpResponse = {
//    JwtToken: string
//}
//
//type LoginControllerHttpResponse =

type RequestBody = {
    DeviceToken: string
}

[<ApiController>]
[<Route("auth/login")>]
type LoginController (logger : ILogger<LoginController>) =
    inherit ControllerBase()
    
    [<HttpPost>]
    member this.PostLoginAsync([<FromServices>] userReadRepository: IUserReadRepository, [<FromBody>] requestBody: RequestBody) = async {
        let useCaseInput: LoginWithDeviceInput = {DeviceToken = requestBody.DeviceToken}
        let! useCaseResult = loginWithDeviceAsync userReadRepository useCaseInput 
        return match useCaseResult with
        | Success successResult -> this.Ok { Jwt = successResult.JwtToken } :> IActionResult
        | WrongDeviceToken -> this.Forbid () :> IActionResult
        | UndisclosedError -> this.StatusCode 500
    }
