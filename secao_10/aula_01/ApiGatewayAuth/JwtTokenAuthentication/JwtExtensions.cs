using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace JwtTokenAuthentication;
public static class JwtExtensions
{
  public const string SecurityKey = "3JlllGP55q0YZyGRKiTMYOW5cFZmawV+sVbD2XHikgaRUHRduupSA/WFWZavjvr4yRf+2Cdj0Y3YBfKBO9uLhw==";

  public static void AddJwtAuthentication(this IServiceCollection services)
  {
    services.AddAuthentication(options =>
    {
      options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(opt =>
    {
      opt.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuer = true,
        ValidIssuer = "https://localhost:5002",
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKey))
      };
    });
  }
}
