namespace WD.HabitTracker.Application.Services.Persistence

open WD.HabitTracker.Application.Services.Persistence.PersistenceServices.CommonErrors
open WD.HabitTracker.Domain.Users

type IUserReadRepository =
    abstract member FindUserByDeviceTokenAsync: DeviceToken -> Async<Result<User option, PersistenceError>>