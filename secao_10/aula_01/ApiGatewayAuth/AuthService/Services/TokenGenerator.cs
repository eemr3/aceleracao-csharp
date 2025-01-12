using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthService.Models;
using Microsoft.IdentityModel.Tokens;


namespace AuthService.Services;

public class TokenGenerator
{
  private IConfiguration _configuration;
  public TokenGenerator(IConfiguration config)
  {
    _configuration = config;
  }

  public string Generator(User user)
  {
    var jwtSecret = _configuration["Jwt:Key"];
    if (string.IsNullOrEmpty(jwtSecret))
    {
      throw new ArgumentNullException(nameof(jwtSecret), "JWT Secret Key cannot be null or empty.");
    }

    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

    var tokenHandler = new JwtSecurityTokenHandler();
    var tokenDescriptor = new SecurityTokenDescriptor()
    {
      Subject = AddClaims(user),
      Issuer = _configuration["Jwt:Issuer"],
      Audience = _configuration["Jwt:Audience"],
      Expires = DateTime.UtcNow.AddMinutes(7),
      SigningCredentials = creds
    };

    var token = tokenHandler.CreateToken(tokenDescriptor);
    return tokenHandler.WriteToken(token);
  }

  private static ClaimsIdentity AddClaims(User user)
  {
    var claims = new ClaimsIdentity();
    claims.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
    claims.AddClaim(new Claim(JwtRegisteredClaimNames.Email, user.Email!));
    claims.AddClaim(new Claim(ClaimTypes.Role, user.Role!));

    return claims;
  }
}