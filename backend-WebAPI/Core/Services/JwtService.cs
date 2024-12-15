using System.Text;
using Data.Entities;
using Core.Interfaces;
using Core.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Core.Services;

public class JwtService(JwtOptions jwtOptions) : IJwtService
{
    public IEnumerable<Claim> GetClaims(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id),
            new(ClaimTypes.Email, user.Email!)
        };
        
        if (user.BirthDate.HasValue)
            claims.Add(new Claim(ClaimTypes.DateOfBirth, user.BirthDate.ToString()!));

        return claims;
    }

    public string CreateToken(IEnumerable<Claim> claims)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: jwtOptions.Issuer,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(jwtOptions.LifetimeInMinutes),
            signingCredentials: credentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
