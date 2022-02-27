namespace WD.HabitTracker.Auth

open System
open System.Collections
open System.IdentityModel.Tokens.Jwt
open System.Security.Claims
open System.Text
open Microsoft.IdentityModel.Tokens
open WD.HabitTracker.Application.Services.Authentication
open WD.HabitTracker.Domain.Users

type JwtConfig() = 
    member val ExpiryInMinutes: int = 0 with get,set
    member val Issuer: string = "" with get,set
    member val Audience: string = "" with get,set
    member val SecretKey: string = "" with get,set

type JwtManager(config: JwtConfig) =
    member this.Build (user: User) (claims: Claim list) =
        let key = SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.SecretKey))
        
        let token = JwtSecurityToken(
            config.Issuer,
            config.Audience,
            claims |> List.append [Claim("userId", user.Id.ToString())],
            System.Nullable(),
            DateTime.UtcNow.AddMinutes(config.ExpiryInMinutes),
            SigningCredentials(key, SecurityAlgorithms.HmacSha256))
        
        JwtSecurityTokenHandler().WriteToken(token);
          
    interface IJwtManager with
        member this.GenerateForDeviceAuth(user) = this.Build user [Claim("authMean", "device")]