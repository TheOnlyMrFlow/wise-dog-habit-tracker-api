namespace WD.HabitTracker.Api.Controllers.Login

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open WD.HabitTracker.Application.LoginWithDeviceUseCase
open WD.HabitTracker.Application.Services.Authentication
open WD.HabitTracker.Application.Services.Persistence

type LoginSuccessHttpResponse = {
    Jwt: string
}

type LoginRequestBody = {
    DeviceToken: string
}

[<ApiController>]
[<Route("auth/login")>]
type LoginController (logger : ILogger<LoginController>) =
    inherit ControllerBase()
    
    [<HttpPost>]
    member this.LoginAsync([<FromServices>] userReadRepository: IUserReadRepository, [<FromServices>] jwtManager: IJwtManager, [<FromBody>] requestBody: LoginRequestBody) = async {
        let useCaseInput: LoginWithDeviceInput = {DeviceToken = requestBody.DeviceToken}
        let! useCaseResult = loginWithDeviceAsync userReadRepository jwtManager useCaseInput 
        return match useCaseResult with
                | Success successResult -> this.Ok { Jwt = successResult.JwtToken } :> IActionResult
                | WrongDeviceToken -> this.StatusCode(403) :> IActionResult
                | UndisclosedError -> this.StatusCode 500
    }
