using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthService.Models;
using JwtTokenAuthentication;
using Microsoft.IdentityModel.Tokens;

namespace AuthService.Services.JWT;

public class TokenGenerator
{
  public string Generator(User user)
  {
    var secretyKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtExtensions.SecurityKey));
    var signingCredentials = new SigningCredentials(secretyKey, SecurityAlgorithms.HmacSha256Signature);
    var expirationTimeStamp = DateTime.UtcNow.AddMinutes(5);

    var tokenHandler = new JwtSecurityTokenHandler();
    var tokenDescriptor = new SecurityTokenDescriptor()
    {
      Subject = AddCalims(user),
      SigningCredentials = signingCredentials,
      Expires = expirationTimeStamp
    };

    var token = tokenHandler.CreateToken(tokenDescriptor);
    return tokenHandler.WriteToken(token);
  }

  private static ClaimsIdentity AddCalims(User user)
  {
    var claims = new ClaimsIdentity();

    claims.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()));
    claims.AddClaim(new Claim(ClaimTypes.Email, user.Email));
    claims.AddClaim(new Claim(ClaimTypes.GivenName, user.Name));
    claims.AddClaim(new Claim(ClaimTypes.Role, user.Role!));

    return claims;
  }
}