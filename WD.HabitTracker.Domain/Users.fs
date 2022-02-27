module WD.HabitTracker.Domain.Users

open System

type DeviceToken = string

type DeviceAuthenticationMean = {
    DeviceToken: DeviceToken
}

type UserName = string

type Password = string

type CredentialsAuthenticationMean = {
    UserName: UserName
    Password: Password
}

type AuthenticationMean =
    | Device of DeviceAuthenticationMean
    | Credentials of CredentialsAuthenticationMean

type User = {
    Id: Guid
    AuthenticationMean: AuthenticationMean
//    Habits: Habit list
}