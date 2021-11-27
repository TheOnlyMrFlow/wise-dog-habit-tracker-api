using System.Security.Claims;

namespace TWD.HabitTracker.Domain.Entities.User.Auth;

public class LoggedUser
{
    public Guid UserId { get; set; }
    
    public string AuthMean { get; set; }
    
    public LoggedUser(IEnumerable<Claim> claims)
    {
        claims = claims.ToArray();
        
        var userIdClaim = claims.FirstOrDefault(c => c.Type == "userId");
        if (userIdClaim is null) throw new ArgumentNullException(nameof(userIdClaim));
        UserId = new Guid(userIdClaim.Value);
        
        var authMeanClaim = claims.FirstOrDefault(c => c.Type == "authMean");
        if (authMeanClaim is null) throw new ArgumentNullException(nameof(authMeanClaim));
        AuthMean = authMeanClaim.Value;
    }
}