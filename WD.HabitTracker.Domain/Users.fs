module WD.HabitTracker.Domain.Users

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
    AuthenticationMean: AuthenticationMean
//    Habits: Habit list
}

type Toto = Toto of Toto

let someUser = {AuthenticationMean = Device {DeviceToken = "toto"}}