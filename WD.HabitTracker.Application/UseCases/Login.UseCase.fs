module WD.HabitTracker.Application.LoginWithDeviceUseCase

open WD.HabitTracker.Application.Services.Persistence


type LoginWithDeviceInput = {
    DeviceToken: string
}

type LoginWithDeviceSuccessResult = {
    JwtToken: string
}

type LoginWithDeviceResult =
    | Success of LoginWithDeviceSuccessResult
    | WrongDeviceToken
    | UndisclosedError
    
let loginWithDeviceAsync (userReadRepository: IUserReadRepository ) input : Async<LoginWithDeviceResult> =
    async {
        let! findUserResult = userReadRepository.FindUserByDeviceTokenAsync input.DeviceToken
        return match findUserResult with
                | Ok maybeUser ->
                    match maybeUser with
                      | Some user -> Success {JwtToken = "toto"}
                      | _ -> WrongDeviceToken
                | Error persistenceError -> UndisclosedError
    }
