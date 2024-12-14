using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TrybeStore.Models;

namespace TrybeStore.Services;

public class TokenGenerator
{
  private readonly IConfiguration _configuration;
  public TokenGenerator(IConfiguration configuration)
  {
    _configuration = configuration;
  }

  public string Generate(User user)
  {
    string alternativeKey = "chaveSecretaAlternativaSeNãoHouverUmaNaVariáveldeAmbiente";
    var secret = _configuration["Jwt:SecretKey"] ?? alternativeKey;
    var expiresHours = 4;

    var tokenHandler = new JwtSecurityTokenHandler();
    var tokenDescriptor = new SecurityTokenDescriptor()
    {
      Subject = AddClaims(user),
      SigningCredentials = new SigningCredentials(
          new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret)),
          SecurityAlgorithms.HmacSha256Signature),
      Expires = DateTime.Now.AddHours(expiresHours)
    };

    var token = tokenHandler.CreateToken(tokenDescriptor);

    return tokenHandler.WriteToken(token);
  }

  private ClaimsIdentity AddClaims(User user)
  {
    var claims = new ClaimsIdentity();
    claims.AddClaim(new Claim(ClaimTypes.Email, user.Email!));
    claims.AddClaim(new Claim(ClaimTypes.Name, user.Name!));
    claims.AddClaim(new Claim(ClaimTypes.Role, user.Access!));

    return claims;
  }
}