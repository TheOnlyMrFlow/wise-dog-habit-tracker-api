module WD.HabitTracker.Application.LoginWithDeviceUseCase

open WD.HabitTracker.Application.Services.Authentication
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
    
let loginWithDeviceAsync (userReadRepository: IUserReadRepository) (jwtManager: IJwtManager) input : Async<LoginWithDeviceResult> =
    async {
        let! findUserResult = userReadRepository.FindUserByDeviceTokenAsync input.DeviceToken
        return match findUserResult with
                | Some user -> Success {JwtToken = jwtManager.GenerateForDeviceAuth user}
                | _ -> WrongDeviceToken
    }
 