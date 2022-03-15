namespace WD.HabitTracker.Persistence.MongoDb.Documents

open System
open MongoDB.Bson.Serialization.Attributes

[<BsonIgnoreExtraElements>]
[<CLIMutable>]
type CredentialsAuthDocument = {
    Email: string
    Password: string
}

[<BsonIgnoreExtraElements>]
[<CLIMutable>]
type  DeviceAuthDocument = {
    DeviceToken: string
}

[<BsonIgnoreExtraElements>]
[<CLIMutable>]
type AuthInfoDocument = {
    [<BsonElement>] [<BsonIgnoreIfNull>] DeviceAuth: DeviceAuthDocument
    [<BsonElement>] [<BsonIgnoreIfNull>] CredentialsAuth: CredentialsAuthDocument
}

[<BsonIgnoreExtraElements>]
[<CLIMutable>]
type UserDocument = {
    SchemaVersion: int
    [<BsonId>] [<BsonIgnoreIfDefault>] Id: Guid
    [<BsonElement>] [<BsonIgnoreIfNull>] AuthInfo: AuthInfoDocument
}

