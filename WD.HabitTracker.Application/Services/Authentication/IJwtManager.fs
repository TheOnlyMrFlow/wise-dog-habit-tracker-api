namespace WD.HabitTracker.Application.Services.Authentication

open WD.HabitTracker.Domain.Users

type IJwtManager =
    abstract member GenerateForDeviceAuth: User -> string