namespace WD.HabitTracker.Application.Services.Persistence

open WD.HabitTracker.Domain.Users

type IUserReadRepository =
    abstract member FindUserByDeviceTokenAsync: DeviceToken -> Async<User option>