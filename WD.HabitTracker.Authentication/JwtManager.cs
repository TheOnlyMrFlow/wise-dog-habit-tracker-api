using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TWD.HabitTracker.Application.Authentication;
using TWD.HabitTracker.Domain.Entities.User;

namespace WD.HabitTracker.Authentication;

public class JwtManager : IJwtManager
{
    private readonly JwtConfig _config;

    public JwtManager(JwtConfig config)
    {
        _config = config;
    }

    public string BuildForDeviceAuth(User user) 
        => Build(user, new Claim[] { new("authMean", "device") }).ToString();
    
    public string BuildForCredentialsAuth(User user) 
        => Build(user, new Claim[] { new("authMean", "credentials") }).ToString();

    private string Build(User user, IEnumerable<Claim> claims)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.SecretKey));

        var token = new JwtSecurityToken(
            _config.Issuer,
            _config.Audience,
            claims.Concat(new [] {new Claim("userId", user.Id.ToString())}),
            expires: DateTime.UtcNow.AddMinutes(_config.ExpiryInMinutes),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

public class JwtConfig
{
    public int ExpiryInMinutes { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string SecretKey { get; set; }
}