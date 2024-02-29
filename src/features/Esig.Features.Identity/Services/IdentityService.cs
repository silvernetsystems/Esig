using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Esig.Core.Abstractions.Identity.Domain;
using FluentResults;
using Microsoft.IdentityModel.Tokens;

namespace Esig.Features.Identity.Services;

/// <summary>
/// A service to manage identities.
/// </summary>
public class IdentityService
{
    /// <summary>
    /// Logs in an authenticable entity.
    /// </summary>
    /// <param name="authenticable">Entity to authenticate.</param>
    /// <returns>JWT token of the result.</returns>
    public async Task<Result<string>> LoginAsync(IAuthenticable authenticable)
    {
        var issuer = "issuer";
        var audience = "audience";
        var key = Encoding.ASCII.GetBytes("key");
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, authenticable.Username),
                new Claim(JwtRegisteredClaimNames.Email, authenticable.Username),
                new Claim(JwtRegisteredClaimNames.Jti,
                    Guid.NewGuid().ToString())
            }),
            Expires = DateTime.UtcNow.AddMinutes(5),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials
            (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = tokenHandler.WriteToken(token);
        var stringToken = tokenHandler.WriteToken(token);
        
        return Result.Ok(stringToken);
    }
}