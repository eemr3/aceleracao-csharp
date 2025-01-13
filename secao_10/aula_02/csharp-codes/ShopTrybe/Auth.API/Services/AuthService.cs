namespace Auth.API.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Auth.API.DTO;
using Microsoft.IdentityModel.Tokens;

public static class AuthService
{

  public static string GenerateToken(UserResponseDTO user)
  {
    var secretKey = Environment.GetEnvironmentVariable("JWT_SECRET_KEY");
    if (string.IsNullOrEmpty(secretKey))
    {
      throw new InvalidOperationException("JWT_SECRET_KEY environment variable is not set.");
    }
    var claims = new ClaimsIdentity();
    claims.AddClaim(new Claim(ClaimTypes.Email, user.Email!));

    var tokenHandler = new JwtSecurityTokenHandler();
    var tokenDescriptor = new SecurityTokenDescriptor()
    {
      Subject = claims,
      SigningCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
            SecurityAlgorithms.HmacSha256Signature
        ),
      Expires = DateTime.Now.AddHours(6)
    };
    var token = tokenHandler.CreateToken(tokenDescriptor);
    return tokenHandler.WriteToken(token);
  }
}