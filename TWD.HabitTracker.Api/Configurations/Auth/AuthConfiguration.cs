using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using TWD.HabitTracker.Application.Authentication;
using WD.HabitTracker.Authentication;

namespace TWD.HabitTracker.Api.Configurations.Auth;

public static class AuthConfiguration
{
    public static IServiceCollection AddAuthServices(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtConfig = new JwtConfig();
        configuration.GetSection("JwtConfig").Bind(jwtConfig);
        
        services
            .AddSingleton<JwtConfig>(_ => jwtConfig)
            //.Configure<JwtConfig>(configuration.GetSection("JwtConfig"))
            .AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options => {
                var key = Encoding.ASCII.GetBytes(configuration["JwtConfig:SecretKey"]);

                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters{
                    ValidateIssuerSigningKey= true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false, 
                    ValidateAudience = false,
                    RequireExpirationTime = true,
                    ValidateLifetime = true
                }; 
            });

        services.AddScoped<IJwtManager, JwtManager>();
        
        return services;
    }
}