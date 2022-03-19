namespace WD.HabitTracker.Persistence.MongoDb

open Microsoft.FSharp.Control
open MongoDB.Driver
open WD.HabitTracker.Application.Services.Persistence
open WD.HabitTracker.Domain.Users
open WD.HabitTracker.Persistence.MongoDb.Documents

type UserRepository(client: HabitTrackerMongoDatabase) =
    let userCollection = client.GetUserCollection ()
    
    let mapUserDocumentToUSer userDocument =
        {
            Id = userDocument.Id
            AuthenticationMean = Device {
                DeviceToken = userDocument.AuthInfo.DeviceAuth.DeviceToken
            }
        }
    
    interface IUserReadRepository with
        member this.FindUserByDeviceTokenAsync(deviceToken) = async {

            let filter = Builders<UserDocument>.Filter.Eq((fun u -> u.AuthInfo.DeviceAuth.DeviceToken), deviceToken)
            
            let! matchingUsers = userCollection.FindAsync<UserDocument>(filter) |> Async.AwaitTask
            
            return match (matchingUsers.ToList() |> Seq.tryHead) with
                    | None -> None
                    | Some userDocument -> userDocument |> mapUserDocumentToUSer |> Some
        }