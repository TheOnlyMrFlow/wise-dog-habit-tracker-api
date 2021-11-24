using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TWD.HabitTracker.Application.Authentication;

namespace WD.HabitTracker.Authentication;

public class JwtManager : IJwtManager
    {
        private readonly JwtConfig _config;

        public JwtManager(JwtConfig config)
        {
            _config = config;
        }

        public JwtSecurityToken BuildToken(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.SecretKey));

            return new JwtSecurityToken(
                _config.Issuer,
                _config.Audience,
                claims,
                expires: DateTime.UtcNow.AddMinutes(_config.ExpiryInMinutes),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
        }
    }

public class JwtConfig
{
    public int ExpiryInMinutes { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string SecretKey { get; set; }
}