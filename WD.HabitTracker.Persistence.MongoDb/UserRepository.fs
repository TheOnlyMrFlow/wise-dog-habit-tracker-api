namespace WD.HabitTracker.Persistence.MongoDb

open WD.HabitTracker.Application.Services.Persistence
open WD.HabitTracker.Application.Services.Persistence.PersistenceServices.CommonErrors
open WD.HabitTracker.Domain.Users

type UserRepository(client: HabitTrackerMongoDatabase) =
    let habitCollection = client.GetHabitCollection ()
    
    interface IUserReadRepository with
        member this.FindUserByDeviceTokenAsync(deviceToken) = async {
            try 
                do! Async.Sleep(100)
//                let! habit = habitCollection.FindAsync()  
                return {AuthenticationMean = Device {DeviceToken = deviceToken} } |> Some |> Ok
            with
            | _ -> return "Something terrible happened" |> PersistenceError |> Error
        }